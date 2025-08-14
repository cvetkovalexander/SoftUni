function solve() {
    const textVal = document.getElementById('text').value.trim().toLowerCase();
    const caseVal = document.getElementById('naming-convention').value.trim();
    
    const resEl = document.getElementById('result');
    
    let words = textVal.split(' ');

    if (caseVal === 'Camel Case') {
        resEl.textContent = words.shift() + words.map(word => word[0].toUpperCase() + word.slice(1)).join(''); 
    }

    else if (caseVal === 'Pascal Case') {
        resEl.textContent = words.map(word => word[0].toUpperCase() + word.slice(1)).join('');
    }

    else {
        resEl.textContent = 'Error!';
    }
}