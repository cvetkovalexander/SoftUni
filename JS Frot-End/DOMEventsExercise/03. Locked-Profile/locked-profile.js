document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const allButtonsEls = document.querySelectorAll('button');

    allButtonsEls.forEach(b => b.addEventListener('click', handleEvent));

    function handleEvent(e) {
        const curr = e.target;
        const parentEl = curr.closest('.profile');
        const radioEl = parentEl.querySelector('input');
        const hiddenDivEl = parentEl.querySelector('.hidden-fields');
        
        if (radioEl.checked) {
            return;
        }

        if (curr.textContent === 'Show more') {
            hiddenDivEl.style.display = 'block';
            curr.textContent = 'Show less';
        } else {
            hiddenDivEl.style.display = 'none';
            curr.textContent = 'Show more';
        }
            
    }
}