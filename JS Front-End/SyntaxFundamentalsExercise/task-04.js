


function startEndSum(start, end) {
    let msg = ``;
    let sum = 0;
    for (; start <= end; start++) {
        sum += start;
        msg += `${start} `
    }

    console.log(msg);
    console.log(`Sum: ${sum}`);
}

startEndSum(5, 10);