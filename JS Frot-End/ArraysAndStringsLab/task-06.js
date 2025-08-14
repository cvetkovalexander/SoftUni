

function solve(text, word) {
    let arr = text.split(` `);
    let count = 0;
    for (let w of arr) {
        if (w == word) count++;
    }

    console.log(count);
}

solve('This is a word and it also is a sentence', 'is');