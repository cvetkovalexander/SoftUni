document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const formEl = document.querySelector('form');
    const textInput = formEl.querySelector('#newItemText');
    const valueInput = formEl.querySelector('#newItemValue');
    const selectEl = document.querySelector('#menu');

    formEl.addEventListener('submit', handleEvent);

    function handleEvent(e) {
        e.preventDefault();
        
        const optionEl = document.createElement('option');
        optionEl.text = textInput.value.trim();
        optionEl.value = valueInput.value.trim();

        selectEl.appendChild(optionEl);

        textInput.value = '';
        valueInput.value = '';
    }
}