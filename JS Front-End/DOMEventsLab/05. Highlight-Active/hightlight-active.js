document.addEventListener('DOMContentLoaded', focused);

function focused() {
    const inputEls = document.querySelectorAll('input');
    
    inputEls.forEach(inputEl => {
        inputEl.addEventListener('focus', handleEventFocus);
        inputEl.addEventListener('blur', handleEventBlur); 
    });

    function handleEventFocus(e) {
        const outerEl = e.target.closest('.panel');
        outerEl.classList.add('focused');
    }

    function handleEventBlur(e) {
        const outerEl = e.target.closest('.panel');
        outerEl.classList.remove('focused');
    }
}
