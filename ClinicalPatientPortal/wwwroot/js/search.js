document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('searchForm');
    const errorEl = document.getElementById('searchError');
    const resultsCard = document.getElementById('resultsCard');
    const resultsBody = document.getElementById('resultsBody');
    const noResultsMessage = document.getElementById('noResultsMessage');
    const resultsTable = document.getElementById('resultsTable');
    const resultsHeading = document.getElementById('resultsHeading');
    const clearBtn = document.getElementById('clearBtn');
    const paginationControls = document.getElementById('paginationControls');
    const prevPageBtn = document.getElementById('prevPageBtn');
    const nextPageBtn = document.getElementById('nextPageBtn');
    const pageInfo = document.getElementById('pageInfo');

    const pageSize = 5;
    let currentPage = 1;

    performSearch(1);

    form.addEventListener('submit', function (e) {
        debugger;
        e.preventDefault();
        const mrn = document.getElementById('mrn').value.trim();
        const dob = document.getElementById('dob').value.trim();
        const firstName = document.getElementById('firstName').value.trim();
        const lastName = document.getElementById('lastName').value.trim();
        if (!mrn && !dob && !firstName && !lastName) {
            showSearchMessage('Please enter at least one search field.')
            return; // don't call the API — table stays as it is
        }

        clearSearchMessage();
        performSearch(1);
    });

    clearBtn.addEventListener('click', function () {
        form.reset();
        performSearch(1);
    });

    prevPageBtn.addEventListener('click', function () {
        if (currentPage > 1) performSearch(currentPage - 1);
    });

    nextPageBtn.addEventListener('click', function () {
        performSearch(currentPage + 1);
    });

    async function performSearch(page) {
        clearSearchMessage();

        const mrn = document.getElementById('mrn').value.trim();
        const dob = document.getElementById('dob').value.trim();
        const firstName = document.getElementById('firstName').value.trim();
        const lastName = document.getElementById('lastName').value.trim();
        const hasCriteria = !!(mrn || dob || firstName || lastName);

        const params = new URLSearchParams();
        if (mrn) params.append('mrn', mrn);
        if (dob) params.append('dob', dob);
        if (firstName) params.append('firstName', firstName);
        if (lastName) params.append('lastName', lastName);
        params.append('page', page);
        params.append('pageSize', pageSize);

        try {
            const response = await fetch(`/api/patients/search?${params.toString()}`);

            if (!response.ok) {
                const message = await response.text();
                showSearchMessage(message || 'Something went wrong while loading patients. Please try again.');
                resultsCard.style.display = 'none';
                return;
            }

            const result = await response.json();
            currentPage = result.page;
            renderResults(result, hasCriteria);
        } catch (err) {
            showSearchMessage('Unable to reach the server. Please try again.');
        }
    }

    function renderResults(result, hasCriteria) {
        const patients = result.items;
        resultsBody.innerHTML = '';
        resultsCard.style.display = 'block';
        resultsHeading.textContent = hasCriteria ? 'Search Results' : 'All Patients';

        if (!patients || patients.length === 0) {
            noResultsMessage.style.display = 'block';
            resultsTable.style.display = 'none';
            paginationControls.style.display = 'none';
            return;
        }

        noResultsMessage.style.display = 'none';
        resultsTable.style.display = 'table';

        patients.forEach(function (p) {
            const row = document.createElement('tr');
            row.classList.add('result-row');
            row.innerHTML = `
                <td>${escapeHtml(p.lastName)}</td>
                <td>${escapeHtml(p.firstName)}</td>
                <td>${escapeHtml(p.mrn)}</td>
                <td>${formatDate(p.dob)}</td>
                <td>${escapeHtml(p.gender || '')}</td>
            `;
            row.addEventListener('click', function () {
                alert('Patient Details page coming next: ' + p.firstName + ' ' + p.lastName);
            });
            resultsBody.appendChild(row);
        });

        paginationControls.style.display = 'flex';
        pageInfo.textContent = `Page ${result.page} of ${result.totalPages} (${result.totalCount} total patients)`;
        prevPageBtn.disabled = result.page <= 1;
        nextPageBtn.disabled = result.page >= result.totalPages;
    }

    function formatDate(dateString) {
        const d = new Date(dateString);
        return d.toLocaleDateString('en-US', { year: 'numeric', month: 'short', day: 'numeric' });
    }

    function escapeHtml(str) {
        const div = document.createElement('div');
        div.textContent = str;
        return div.innerHTML;
    }

    function showSearchMessage(text) {
        errorEl.textContent = text;
        errorEl.style.display = 'block';
    }

    function clearSearchMessage() {
        errorEl.textContent = '';
        errorEl.style.display = 'none';
    }
});