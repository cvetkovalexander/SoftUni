document.addEventListener('DOMContentLoaded', solve);

function solve() {
      const inputEl = document.querySelector('#task-input input');
      const formEl = document.getElementById('task-input');
      const contentEl = document.getElementById('content');
      
      formEl.addEventListener('submit', handleSubmitEvent);
      
      function handleSubmitEvent(e) {
            e.preventDefault();
            const inputText = inputEl.value.trim();
            const sectionsText = inputText.split(', ');
         sectionsText.forEach(text => {
               const divEl = document.createElement('div');
               const pEl = document.createElement('p');
               pEl.textContent = text;
               pEl.style.display = 'none';
               divEl.appendChild(pEl);

               divEl.addEventListener('click', handleClickEvent);

               contentEl.appendChild(divEl);
         });
      }

      function handleClickEvent(e) {
            const pEl = e.target.querySelector('p');
            pEl.style.display = 'block';
      }
}