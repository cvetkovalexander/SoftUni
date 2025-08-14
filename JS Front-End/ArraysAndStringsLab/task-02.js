

function reverse(n, input) {
    let subArr = input.slice(0, n);
    console.log(subArr.reverse().join(` `));
}

reverse(3, [10, 20, 30, 40, 50]);