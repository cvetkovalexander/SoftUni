


function solve(a) {
    let areSame = true;
    let numStr = String(a);
    let sum = Number(numStr[0]);

    for (let i = 1; i < numStr.length; i++) {
        if (numStr[0] != numStr[i]) areSame = false;
        sum += Number(numStr[i]);
    }

    console.log(areSame);
    console.log(sum);
}

solve(2222222);