

function sumDigits(a) {
    let sum = 0;
    let numStr = String(a);
    for (let i = 0; i < numStr.length; i++) {
        sum += Number(numStr[i]);
    }

    console.log(sum);
}

sumDigits(245678);

