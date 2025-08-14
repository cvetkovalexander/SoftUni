function extract(targetId) {
    const targetEl = document.getElementById(targetId);
    const content = targetEl.textContent;

    const pattern = /\(.+?\)/g;
    const matches = content.match(pattern);

    const filtered = matches.map(m => m.substring(1, m.length - 1));

    return filtered.join('; ');
}

let text = extract("content");
console.log(text);