

function simpleCalc(a, b, operator) {
    const operations = {
        'add': () => a + b,
        'subtract': () => a - b,
        'multiply': () => a * b,
        'divide': () => a / b
    };

    const operation = operations[operator];
    return operation();
}

console.log(simpleCalc(5, 5, '+'));