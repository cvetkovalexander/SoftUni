


function solve(text) {
    let hashWords = text.split(` `).filter(w => w.startsWith(`#`) && w.length > 1);
    
    for (const hashWord of hashWords) {
        let word = hashWord.substring(1);
        let pattern = /^[A-Za-z]+$/;

        if (pattern.test(word))
            console.log(word);
    }
}

solve('Nowadays everyone uses # to tag a #special word in #socialMedia');