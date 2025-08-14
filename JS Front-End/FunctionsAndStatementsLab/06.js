

function signCheck(a, b, c) {
    let count = 0;
    if (a < 0) count++;
    if (b < 0) count++;
    if (c < 0) count++;

    if (count % 2 === 0) console.log(`Positive`);
    else console.log(`Negative`);
}

signCheck(-5, -12, -15);