

function solve(arr, n) {
    for (; n > 0; n--) {
        arr.push(arr.shift());
    }
    console.log(arr.join(` `));
}

solve([51, 47, 32, 61, 21], 2);