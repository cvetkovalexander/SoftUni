const loadBtnEl = document.getElementById('btnLoad');
const createBtnEl = document.getElementById('btnCreate');
const phonebookUlEl = document.getElementById('phonebook');
const personInputEl = document.getElementById('person');
const phoneInputEl = document.getElementById('phone');

function attachEvents() {
    loadBtnEl.addEventListener('click', getPhonebookEntries);
    createBtnEl.addEventListener('click', createPhonebookEntry);
}

attachEvents();

async function getPhonebookEntries() {
    const phonebookRes = await fetch('http://localhost:3030/jsonstore/phonebook');
    const phonebookData = await phonebookRes.json();

    const phonebookArr = Object.values(phonebookData);
    phonebookUlEl.innerHTML = '';
    phonebookArr.forEach(el => {
        const liEl = document.createElement('li');
        liEl.textContent = `${el.person}: ${el.phone}`;
        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.textContent = 'Delete';
        deleteBtnEl.addEventListener('click', deletePhonebookEntry);
        liEl.appendChild(deleteBtnEl);
        phonebookUlEl.appendChild(liEl);

        async function deletePhonebookEntry() {
            await fetch(`http://localhost:3030/jsonstore/phonebook/${el._id}`, {
                method: 'DELETE'
            });
            getPhonebookEntries();
        }
    });
}

async function createPhonebookEntry() {
    const person = personInputEl.value.trim();
    const phone = phoneInputEl.value.trim();

    personInputEl.value = '';
    phoneInputEl.value = '';

    const entry = { person, phone };

    await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(entry)
    });

    getPhonebookEntries();
}