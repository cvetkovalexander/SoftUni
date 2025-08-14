function getInfo() {
    const stopIdEl = document.getElementById('stopId');
    const stopNameEl = document.getElementById('stopName');
    const busesEl = document.getElementById('buses');
    busesEl.innerHTML = '';

    const stopId = stopIdEl.value.trim();
    
    fetch (`http://localhost:3030/jsonstore/bus/businfo/${stopId}`)
        .then(res => res.json())
        .then(stopObj => {
            stopNameEl.textContent = stopObj.name;

            const busEntries = Object.entries(stopObj.buses);
            for (const [bus, time] of busEntries) {
                const liEl = document.createElement('li');
                liEl.textContent = `Bus ${bus} arrives in ${time} minutes`;
                busesEl.appendChild(liEl);
            }
        })
        .catch (err => {
            stopNameEl.textContent = 'Error';
        })
}