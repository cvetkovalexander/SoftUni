function solve() {
   const liEls = document.querySelectorAll('#towns li');
   const searchEl = document.getElementById('searchText');
   const resEl = document.getElementById('result');

   const search = searchEl.value.trim();
   let matches = 0;

   liEls.forEach(liEl => {
      if (liEl.textContent.includes(search)) {
         liEl.style.fontWeight = 'bold';
         liEl.style.textDecoration = 'underline';
         matches++;
      }
      else {
         liEl.style.fontWeight = 'normal';
         liEl.style.textDecoration = 'none';
      }
   });

   resEl.textContent = `${matches} matches found`;
}