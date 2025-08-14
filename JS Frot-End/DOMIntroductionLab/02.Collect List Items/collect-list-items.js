function extractText() {
    const liEls = document.querySelectorAll('li');
    const textAreaEl = document.getElementById('result');
    
    for (const liEl of liEls) {
        textAreaEl.textContent += liEl.textContent + '\n';
    }
}