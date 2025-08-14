window.addEventListener("load", solve);


function solve() {
    const nameInputEl = document.getElementById('name');
    const numberInputEl = document.getElementById('phone');
    const categorySelectEl = document.getElementById('category');
    const addBtnEl = document.getElementById('add-btn');
    const checkListEl = document.getElementById('check-list');
    const contactListEl = document.getElementById('contact-list');
    addBtnEl.addEventListener('click', addContact);

    function addContact(e) {

      e.preventDefault();

      const name = nameInputEl.value.trim();
      const number = numberInputEl.value.trim();
      const category = categorySelectEl.value;

      nameInputEl.value = '';
      numberInputEl.value = '';
      categorySelectEl.value = '';

      if (name === '' || number === '' || category === '') return;

      const liEl = document.createElement('li');
      const articleEl = document.createElement('article');

      const pNameEl = document.createElement('p');
      pNameEl.textContent = `name:${name}`;
      const pNumberEl = document.createElement('p');
      pNumberEl.textContent = `phone:${number}`;
      const pCategoryEl = document.createElement('p');
      pCategoryEl.textContent = `category:${category}`;

      articleEl.appendChild(pNameEl);
      articleEl.appendChild(pNumberEl);
      articleEl.appendChild(pCategoryEl);

      const buttonsDivEl = document.createElement('div');
      buttonsDivEl.classList.add('buttons');

      const editBtnEl = document.createElement('button');
      editBtnEl.classList.add('edit-btn');

      editBtnEl.addEventListener('click', editContact);

      function editContact() {
          nameInputEl.value = name;
          numberInputEl.value = number;
          categorySelectEl.value = category;

          checkListEl.removeChild(liEl);
      }

      const saveBtnEl = document.createElement('button');
      saveBtnEl.classList.add('save-btn');

      saveBtnEl.addEventListener('click', saveContact);

      function saveContact() {
          checkListEl.removeChild(liEl);

          liEl.removeChild(buttonsDivEl);
          const deleteBtnEl = document.createElement('button');
          deleteBtnEl.classList.add('del-btn');

          deleteBtnEl.addEventListener('click', () => {
              contactListEl.removeChild(liEl);
          });
          
          liEl.appendChild(deleteBtnEl);

          contactListEl.appendChild(liEl);
      }
      
      buttonsDivEl.appendChild(editBtnEl);
      buttonsDivEl.appendChild(saveBtnEl);

      liEl.appendChild(articleEl);
      liEl.appendChild(buttonsDivEl);

      checkListEl.appendChild(liEl);
  }
}
  