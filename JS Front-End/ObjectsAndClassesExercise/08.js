

function piccolo(arr) {
    let numbers = new Set();

    for (const str of arr) {
        let [dir, num] = str.split(', ');

        if (dir === 'IN')
            numbers.add(num);
        else
            numbers.delete(num);
    }

    if (numbers.size === 0)
        console.log("Parking Lot is Empty");
    else {
        let arr = Array.from(numbers);
        arr.sort((a, b) => a.localeCompare(b));
        arr.forEach(n => console.log(n));
    }
}

piccolo([
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
]);