

function mathOperations(a, b, operator) {
    // if (operator == `+`) console.log(a + b);
    // if (operator == `-`) console.log(a - b);
    // if (operator == `*`) console.log(a * b);
    // if (operator == `/`) console.log(a / b);
    // if (operator == `%`) console.log(a % b);
    // if (operator == `**`) console.log(a**b);

    let res;
    switch (operator) {
        case `+`: res = a + b; break;
        case `-`: res = a - b; break;
        case `*`: res = a * b; break;
        case `/`: res = a / b; break;
        case `%`: res = a % b; break;
        case `**`: res = a ** b; break;
    }

    console.log(res);
}

mathOperations(5, 6, '**');