document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const allForms = document.querySelectorAll('form');
    const daysInput = document.getElementById('days-input');
    const hoursInput = document.getElementById('hours-input');
    const minutesInput = document.getElementById('minutes-input');
    const secondsInput = document.getElementById('seconds-input');

    allForms.forEach(form => form.addEventListener('submit', handleEvent));

    function handleEvent(e) {
        e.preventDefault();
        
        const currForm = e.target;
        const currInput = currForm.querySelector('input[type="number"]');
        const value = Number(currInput.value.trim());
        
        if (currForm.id === 'days') {
            hoursInput.value = (value * 24).toFixed(2);
            minutesInput.value = (value * 1440).toFixed(2);
            secondsInput.value = (value * 86400).toFixed(2);
        } else if (currForm.id === 'hours') {
            let toDays = value / 24;
            daysInput.value = toDays.toFixed(2);
            minutesInput.value = (toDays * 1440).toFixed(2);
            secondsInput.value = (toDays * 86400).toFixed(2);
        } else if (currForm.id === 'minutes') {
            let toDays = value / 1440;
            daysInput.value = toDays.toFixed(2);
            hoursInput.value = (toDays * 24).toFixed(2);
            secondsInput.value = (toDays * 86400).toFixed(2);
        } else if (currForm.id === 'seconds') {
            let toDays = value / 86400;
            daysInput.value = toDays.toFixed(2);
            hoursInput.value = (toDays * 24).toFixed(2);
            minutesInput.value = (toDays * 1440).toFixed(2);
        }
    }
}