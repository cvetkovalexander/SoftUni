const loadRecordsBtnEl = document.getElementById('load-records');
const recordsUlEl = document.getElementById('list');
const addRecordBtnEl = document.getElementById('add-record');
const editRecordBtnEl = document.getElementById('edit-record');
const nameInputEl = document.getElementById('p-name');
const stepsInputEl = document.getElementById('steps');
const caloriesInputEl = document.getElementById('calories');

loadRecordsBtnEl.addEventListener('click', handleLoadRecords);
addRecordBtnEl.addEventListener('click', handleAddRecord);
editRecordBtnEl.addEventListener('click', handleEditRecord);

const BASE_URL = 'http://localhost:3030/jsonstore/records/';
let selectedRecordId = null;

async function handleLoadRecords() {
    const allRecordsRes = await fetch(BASE_URL);
    const allRecordsData = await allRecordsRes.json();
    const recordsArr = Object.values(allRecordsData);
    // console.log(recordsArr);

    recordsUlEl.innerHTML = '';

    recordsArr.forEach(record => {
        const liEl = document.createElement('li');
        liEl.classList.add('record');
        
        const infoDivEl = document.createElement('div');
        infoDivEl.classList.add('info');

        const pNameEl = document.createElement('p');
        pNameEl.textContent = record.name;

        const pStepsEl = document.createElement('p');
        pStepsEl.textContent = record.steps;

        const pCaloriesEl = document.createElement('p');
        pCaloriesEl.textContent = record.calories;

        infoDivEl.appendChild(pNameEl);
        infoDivEl.appendChild(pStepsEl);
        infoDivEl.appendChild(pCaloriesEl);

        const btnWrapperEl = document.createElement('div');
        btnWrapperEl.classList.add('btn-wrapper');

        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';
        changeBtnEl.addEventListener('click', handleChangeRecord);

        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';
        deleteBtnEl.addEventListener('click', handleDeleteRecord);

        btnWrapperEl.appendChild(changeBtnEl);
        btnWrapperEl.appendChild(deleteBtnEl);

        liEl.appendChild(infoDivEl);
        liEl.appendChild(btnWrapperEl);

        recordsUlEl.appendChild(liEl);

        function handleChangeRecord() {
            nameInputEl.value = record.name;
            stepsInputEl.value = record.steps;
            caloriesInputEl.value = record.calories;

            addRecordBtnEl.disabled = true;
            editRecordBtnEl.disabled = false;

            selectedRecordId = record._id;
        }

        async function handleDeleteRecord() {
            await fetch(`${BASE_URL}${record._id}`, {
                method: 'DELETE'
            });

            await handleLoadRecords();
        }
    });
}

async function handleAddRecord() {
    const name = nameInputEl.value.trim();
    const steps = stepsInputEl.value.trim();
    const calories = caloriesInputEl.value.trim();

    nameInputEl.value = '';
    stepsInputEl.value = '';
    caloriesInputEl.value = '';

    await fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, steps, calories})
    });

    await handleLoadRecords();
}

async function handleEditRecord() {
    const name = nameInputEl.value.trim();
    const steps = stepsInputEl.value.trim();
    const calories = caloriesInputEl.value.trim();

    nameInputEl.value = '';
    stepsInputEl.value = '';
    caloriesInputEl.value = '';

    await fetch(`${BASE_URL}${selectedRecordId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, steps, calories })
    });

    await handleLoadRecords();

    addRecordBtnEl.disabled = false;
    editRecordBtnEl.disabled = true;
}