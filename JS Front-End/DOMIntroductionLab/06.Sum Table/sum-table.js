function sumTable() {
    const tdElsPrices = Array.from(document.querySelectorAll('tbody tr td:nth-child(2)'));
    const tdElSum = tdElsPrices.pop();

    let sum = 0;

    for (const price of tdElsPrices) {
        sum += Number(price.textContent);
    }

    tdElSum.textContent = sum;

}