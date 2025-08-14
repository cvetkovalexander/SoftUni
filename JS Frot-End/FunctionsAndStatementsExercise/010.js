

function factorialDivision(a, b) {

    let facA = getFactorial(a);
    let facB = getFactorial(b);

    console.log((facA / facB).toFixed(2));

    function getFactorial(num) {
        let factorial = num;
        for (let i = num - 1; i > 0; i--)
            factorial *= i;

        return factorial;
    }
}

factorialDivision(6, 2);