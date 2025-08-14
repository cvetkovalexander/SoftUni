

function NxN(num) {
    for (let i = 0; i < num; i++) {
        let row = [];
        for (let j = 0; j < num; j++) {
            row.push(num);
        }
        console.log(row.join(' '));
    }
}

NxN(7);