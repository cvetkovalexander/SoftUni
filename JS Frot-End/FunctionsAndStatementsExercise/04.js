

function oddEvenSum(num) {
    let numStr = num.toString();

    let odd = 0;
    let even = 0;

    for (let i = 0; i < numStr.length; i++) {
        let curr = Number(numStr[i]);
        if (curr === 0) continue;
        if (curr % 2 === 0) even += curr;
        else odd += curr;
    }

    console.log(`Odd sum = ${odd}, Even sum = ${even}`);
}

oddEvenSum(1000435);