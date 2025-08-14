function attachGradientEvents() {
    const resEl = document.getElementById('result');
    const gradientEl = document.getElementById('gradient');
    
    gradientEl.addEventListener('mousemove', handleEvent);

    function handleEvent(e) {
        const percentage = Math.floor(e.offsetX / gradientEl.clientWidth * 100);
        resEl.textContent = `${percentage}%`;
    }
}
