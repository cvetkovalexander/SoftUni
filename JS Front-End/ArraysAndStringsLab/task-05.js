

function solve(text, censored) {
    let censor = `*`.repeat(censored.length);
    console.log(text.replaceAll(censored, censor));
}

solve('A small sentence with some words', 'small');