

function solve(words, text) {
    let allWords = words.split(`, `).sort((a, b) => b.length - a.length);

    for (let word of allWords) {
        let template = `*`.repeat(word.length);
        text = text.replace(template, word);
    }

    console.log(text);
}

solve('great, learning',
'softuni is ***** place for ******** new programming languages'
);