

function solve(input) {
    let occurrences = new Map();
    let tokens = input.toLowerCase().split(' ');

    for (const token of tokens) {
        if (!(occurrences.has(token)))
            occurrences.set(token, 0);
        let count = occurrences.get(token);
        occurrences.set(token, count + 1);
    }

    let res = [];
    let entries = occurrences.entries();
    
    for (const [word, count] of entries) {
        if (count % 2 !== 0)
            res.push(word);
    }

    console.log(res.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');