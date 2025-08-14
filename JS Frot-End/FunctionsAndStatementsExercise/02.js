

function sum(a, b, c) {
    
    let d = a + b;
    subtract(d, c);

    function subtract(d, c) {
        console.log(d - c);
    }
}

sum(23, 6, 10);
