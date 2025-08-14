function toggle() {
    const infoEl = document.getElementById('extra');
    const buttEl = document.querySelector('.button');

    if (buttEl.textContent === 'More') {
        infoEl.style.display = 'block';
        buttEl.textContent = 'Less';
    }
    else {
        infoEl.style.display = 'none';
        buttEl.textContent = 'More';
    }
}