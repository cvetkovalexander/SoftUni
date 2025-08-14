function deleteByEmail() {
    const inputEl = document.querySelector('label input');
    const resultEl = document.getElementById('result');
    const trEls = document.querySelectorAll('tbody tr');

    const email = inputEl.value.trim();
    let isDeleted = false;
    
    trEls.forEach(trEl => {
        const tdEl = trEl.querySelector('td:nth-child(2)');
        if (tdEl.textContent === email) {
            trEl.remove();
            resultEl.textContent = 'Deleted.';
            isDeleted = true;
        }
    });

    if (!isDeleted) {
        resultEl.textContent = 'Not found.'
    }
}
