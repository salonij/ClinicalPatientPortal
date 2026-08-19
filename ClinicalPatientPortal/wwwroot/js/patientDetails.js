const loadedTabs = new Set();

document.addEventListener('DOMContentLoaded', () => {
    loadDemographics();
    loadedTabs.add('demographics');

    document.querySelectorAll('.tab-btn').forEach(btn => {
        btn.addEventListener('click', () => switchTab(btn.dataset.tab));
    });
});

function switchTab(tabName) {
    document.querySelectorAll('.tab-btn').forEach(b => b.classList.remove('active'));
    document.querySelectorAll('.tab-content').forEach(c => c.classList.remove('active'));
    document.querySelector(`[data-tab="${tabName}"]`).classList.add('active');
    document.getElementById(tabName).classList.add('active');

    if (!loadedTabs.has(tabName)) {
        loadedTabs.add(tabName);
        if (tabName === 'allergies') loadAllergiesAndAlerts();
        if (tabName === 'medications') loadMedications();
        if (tabName === 'documents') loadDocuments();
    }
}

// ---------- Demographics ----------
function loadDemographics() {
    fetch(`/api/patients/${patientId}`)
        .then(r => r.json())
        .then(data => {
            document.getElementById('patientName').textContent = `${data.firstName} ${data.lastName}`;
            document.getElementById('patientMeta').textContent =
                `MRN: ${data.mrn} | DOB: ${new Date(data.dob).toLocaleDateString()} | ${data.gender}`;
            document.getElementById('demographics').innerHTML = renderDemographics(data);
        })
        .catch(() => {
            document.getElementById('demographics').innerHTML =
                '<p class="empty-state">Unable to load demographics.</p>';
        });
}
function renderDemographics(p) {
    return `
        <div class="detail-card">
            <dl class="detail-grid">
                <div><dt>MRN</dt><dd>${p.mrn}</dd></div>
                <div><dt>Date of Birth</dt><dd>${new Date(p.dob).toLocaleDateString()}</dd></div>
                <div><dt>Gender</dt><dd>${p.gender}</dd></div>
                <div><dt>Phone</dt><dd>${p.phoneNumber || '—'}</dd></div>
                <div><dt>Address</dt><dd>${p.addressLine1 || ''}, ${p.city || ''}, ${p.state || ''} ${p.zipCode || ''}</dd></div>
            </dl>
        </div>`;
}

// ---------- Allergies & Alerts ----------

function loadAllergiesAndAlerts() {
    Promise.all([
        fetch(`/api/patients/${patientId}/allergies`).then(r => r.json()),
        fetch(`/api/patients/${patientId}/alerts`).then(r => r.json())
    ])
        .then(([allergies, alerts]) => {
            document.getElementById('allergies').innerHTML = renderAllergiesAndAlerts(allergies, alerts);
        })
        .catch(() => {
            document.getElementById('allergies').innerHTML =
                '<p class="empty-state">Unable to load allergies and alerts.</p>';
        });
}
function renderAllergiesAndAlerts(allergies, alerts) {
    const allergyRows = allergies.length
        ? allergies.map(a => `
            <div class="detail-grid" style="margin-bottom:0.75rem;">
                <div><dt>Allergen</dt><dd>${a.allergyName}</dd></div>
                <div><dt>Severity</dt><dd><span class="badge badge-${(a.severity || '').toLowerCase()}">${a.severity}</span></dd></div>
                <div><dt>Status</dt><dd><span class="badge badge-${(a.status || '').toLowerCase()}">${a.status}</span></dd></div>
                <div><dt>Recorded</dt><dd>${new Date(a.recordedDate).toLocaleDateString()}</dd></div>
            </div>`).join('<hr>')
        : '<p class="empty-state">No known allergies.</p>';

    const alertRows = alerts.length
        ? alerts.map(a => `
            <div class="detail-grid" style="margin-bottom:0.75rem;">
                <div><dt>Type</dt><dd>${a.alertType}</dd></div>
                <div><dt>Description</dt><dd>${a.description}</dd></div>
                <div><dt>Severity</dt><dd><span class="badge badge-${(a.severity || '').toLowerCase()}">${a.severity}</span></dd></div>
                <div><dt>Created</dt><dd>${new Date(a.createdDate).toLocaleDateString()}</dd></div>
            </div>`).join('<hr>')
        : '<p class="empty-state">No active alerts.</p>';
    return `
        <div class="detail-card">
            <h3>Allergies</h3>
            ${allergyRows}
        </div>
        <div class="detail-card">
            <h3>Alerts</h3>
            ${alertRows}
        </div>`;
}

// ---------- Medications ----------

function loadMedications() {
    fetch(`/api/patients/${patientId}/medications`)
        .then(r => r.json())
        .then(data => {
            document.getElementById('medications').innerHTML = renderMedications(data);
        })
        .catch(() => {
            document.getElementById('medications').innerHTML =
                '<p class="empty-state">Unable to load medications.</p>';
        });
}

function renderMedications(meds) {
    if (!meds.length) {
        return '<div class="detail-card"><p class="empty-state">No medications on record.</p></div>';
    }

    return meds.map(m => `
        <div class="detail-card">
            <dl class="detail-grid">
                <div><dt>Medication</dt><dd>${m.medicationName} ${m.strength || ''}</dd></div>
                <div><dt>Dosage</dt><dd>${m.dosageInstructions || '—'}</dd></div>
                <div><dt>Frequency</dt><dd>${m.frequency || '—'}</dd></div>
                <div><dt>Route</dt><dd>${m.route || '—'}</dd></div>
                <div><dt>Start Date</dt><dd>${new Date(m.startDate).toLocaleDateString()}</dd></div>
                <div><dt>End Date</dt><dd>${m.endDate ? new Date(m.endDate).toLocaleDateString() : 'Ongoing'}</dd></div>
                <div><dt>Prescribing Provider</dt><dd>${m.prescribingProvider || '—'}</dd></div>
                <div><dt>Status</dt><dd><span class="badge badge-${(m.status || '').toLowerCase()}">${m.status}</span></dd></div>
            </dl>
        </div>`).join('');
}