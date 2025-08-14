function subtract() {
    const firstNumEl = document.getElementById('firstNumber');
    const secondNumEl = document.getElementById('secondNumber');
    const resEl = document.getElementById('result');

    const a = Number(firstNumEl.value);
    const b = Number(secondNumEl.value);

    resEl.textContent = a - b;
}