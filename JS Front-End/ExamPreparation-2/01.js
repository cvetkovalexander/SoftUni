

function solve(input) {
    let res = input.shift();

    let command = input.shift();
    while (command !== 'End') {
        if (command === 'RemoveEven') {
            let modified = '';
            for (let i = 0; i < res.length; i+=2) {
                modified += res[i];
            }
            res = modified;
            console.log(res);
        } else {
            const tokens = command.split('!');
            if (tokens[0] === 'TakePart') {
                res = res.slice(tokens[1], tokens[2]);
                console.log(res);
            } else {
                if (res.includes(tokens[1])) {
                    const reversed = tokens[1].split('').reverse().join('');
                    res = res.replace(tokens[1], '');
                    res = res.concat(reversed);
                    
                    console.log(res);
                } else {
                    console.log('Error')
                }
            }
        }
        command = input.shift();
    }

    console.log(`The concealed spell is: ${res}`)
}

solve(["asAsl2adkda2mdaczsa", 
"RemoveEven",
"TakePart!1!9",
"Reverse!maz",
"End"]);