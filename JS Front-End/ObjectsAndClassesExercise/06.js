
function wordsTracker(input) {
    let words = input.shift().split(' ');
    let tracker = {};

    for (const word of words) {
        tracker[word] = 0;
    }

    for (const word of input) {
        if (words.includes(word))
            tracker[word]++;
    }

    let entries = Object.entries(tracker).sort((a, b) => b[1] - a[1]);

    for (const [word, occurrences] of entries) {
        console.log(`${word} - ${occurrences}`);
    }

}

wordsTracker([
    'this sentence', 
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 
    'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 
    'because', 'this', 'is', 'your', 'task'
]
);