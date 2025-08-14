

function printCharsRange(first, second) {
    let start = first.charCodeAt(0);
    let end = second.charCodeAt(0);

    if (start > end) [start, end] = [end ,start];

    let res = []
    for (let i = start + 1; i < end; i++)
        res.push(String.fromCharCode(i));

    console.log(res.join(' '));
}

printCharsRange('a', 'd');