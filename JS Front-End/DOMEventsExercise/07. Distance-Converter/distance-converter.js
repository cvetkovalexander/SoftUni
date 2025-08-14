document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const inputDistanceEl = document.querySelector('#inputDistance');
    const outputDistanceEl = document.querySelector('#outputDistance');
   
    const convertButtonEl = document.querySelector('#convert');

    convertButtonEl.addEventListener('click', convertDistances);

    const unitsToMeters = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    };

    function convertDistances(e) {
        const inputUnits = document.querySelector('#inputUnits').value;
        const outputUnits = document.querySelector('#outputUnits').value;
        const inputDistance = Number(inputDistanceEl.value.trim());

        const distanceToM = inputDistance * unitsToMeters[inputUnits];
        const result = distanceToM / unitsToMeters[outputUnits];

        outputDistanceEl.value = result;
    }
}