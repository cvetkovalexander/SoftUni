function solve() {
    const numEl = document.getElementById('input');
    const menuEl = document.getElementById('selectMenuTo');
    const outputEl = document.getElementById('result');

    let num = Number(numEl.value.trim());
    
    if (menuEl.value === 'binary') {
        outputEl.value = num.toString(2);
    }
    else if (menuEl.value === 'hexadecimal') {
        outputEl.value = num.toString(16).toUpperCase();
    }
}