using ClinicalPatientPortal.Data;
using ClinicalPatientPortal.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/");         // require login for every page by default
    options.Conventions.AllowAnonymousToPage("/Login"); // except the Login page itself
});

builder.Services.AddControllers();

//registering service to DI container
builder.Services.AddScoped<IPatientDataService, PatientDataService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false; // keeping it simple for a demo account; still needs upper/lower/digit
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.AccessDeniedPath = "/Login";
});

//adding free community version for QuestPDF
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// Runs at startup, Checks if any migration haven't been applied yet and applies them.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();

    //code to create demo user automatically when the app runs.
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    const string demoUserName = "Dr. Sarah Mitchell";
    const string demoEmail = "doctor@clinicalportal.com";
    const string demoPassword = "Clinician123";

    if (await userManager.FindByEmailAsync(demoEmail) == null)
    {
        var demoUser = new IdentityUser
        {
            UserName = demoUserName,
            Email = demoEmail,
            EmailConfirmed = true
        };
        await userManager.CreateAsync(demoUser, demoPassword);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
