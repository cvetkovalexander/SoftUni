

function monthPrinter(n) {
    if (n < 1 || n > 12) {
        console.log(`Error!`);
    }
    else {
        if (n == 1) console.log(`January`);
        if (n == 2) console.log(`February`);
        if (n == 3) console.log(`March`);
        if (n == 4) console.log(`April`);
        if (n == 5) console.log(`May`);
        if (n == 6) console.log(`June`);
        if (n == 7) console.log(`July`);
        if (n == 8) console.log(`August`);
        if (n == 9) console.log(`September`);
        if (n == 10) console.log(`October`);
        if (n == 11) console.log(`November`);
        if (n == 12) console.log(`December`);
    }
}

monthPrinter(2);