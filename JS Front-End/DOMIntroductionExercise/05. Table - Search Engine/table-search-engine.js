function solve() {
      const tdEls = document.querySelectorAll('tbody td');
      const inputEl = document.getElementById('searchField');
      
      let trEls = document.querySelectorAll('tbody tr');

      trEls.forEach(trEl => {
         trEl.classList.remove('select');
      });

      const input = inputEl.value.trim().toLowerCase();

      if (!input)
         return;

      tdEls.forEach(tdEl => {
         if (tdEl.textContent.toLowerCase().includes(input)) {
            const parent = tdEl.parentElement;
            parent.classList.add('select');
         }
      });

      inputEl.value = '';
}