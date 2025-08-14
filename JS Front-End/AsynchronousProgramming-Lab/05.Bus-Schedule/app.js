function solve() {
    const infoEl = document.querySelector('.info');
    const departBtnEl = document.getElementById('depart');
    const arriveBtnEl = document.getElementById('arrive');

    let stopId = 'depot';
    let currStop = '';

    function depart() {
        fetch (`http://localhost:3030/jsonstore/bus/schedule/${stopId}`)
            .then(res => res.json())
            .then(stopObj => {
                currStop = stopObj.name
                infoEl.textContent = `Next stop ${currStop}`;
                stopId = stopObj.next;

                departBtnEl.disabled = true;
                arriveBtnEl.disabled = false;
            })
            .catch(err => infoEl.textContent = 'Error');
    }

    function arrive() {
        infoEl.textContent = `Arriving at ${currStop}`;

        departBtnEl.disabled = false;
        arriveBtnEl.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();