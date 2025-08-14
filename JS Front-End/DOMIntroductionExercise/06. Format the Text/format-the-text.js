function solve() {
      const textAreaEl = document.getElementById('input');
      const outputEl = document.getElementById('output');

      const text = textAreaEl.value.trim();
      const sentences = text.split('.').filter(s => s.length > 0);
      
      let currPara = '';

      for (let i = 0; i < sentences.length; i++) {
          currPara += sentences[i].trim() + '.';

          if ((i + 1) % 3 === 0 || i === sentences.length - 1) {
              outputEl.innerHTML += `<p>${currPara}</p>`;
              currPara = '';
          }
      }
}