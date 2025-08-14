document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const emailInputEl = document.getElementById('email');
    const pattern = /[a-z]+@[a-z]+\.[a-z]+/;

    emailInputEl.addEventListener('change', handleEvent);

    function handleEvent() {
        const email = emailInputEl.value.trim();

        if (!pattern.test(email)) {
            emailInputEl.classList.add('error');
        } else {
            emailInputEl.classList.remove('error');
        }
    }
}
