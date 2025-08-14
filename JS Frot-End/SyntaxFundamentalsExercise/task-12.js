


function cooking(a, first, second, third, fourth, fifth) {
    const commands = [first, second, third, fourth, fifth];
    for (let i = 0; i < commands.length; i++) {
        switch (commands[i]) {
            case `chop`:
                a /= 2;
                break;
            case `dice`:
                a = Math.sqrt(a);
                break;
            case `spice`:
                a += 1;
                break;
            case `bake`:
                a *= 3;
                break;
            case `fillet`:
                a -= a * 0.2;
                break; 
        }
        console.log(a);
    }
}

