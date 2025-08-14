window.addEventListener("load", solve);

function solve() {
    const typeInputEl = document.getElementById('type');
    const ageInputEl = document.getElementById('age');
    const genderSelectEl = document.getElementById('gender');
    const infoUlEl = document.getElementById('adoption-info');
    const listUlEl = document.getElementById('adopted-list');
    const adoptBtnEl = document.getElementById('adopt-btn');

    adoptBtnEl.addEventListener('click', handleAdoption);

    function handleAdoption(e) {
        e.preventDefault();

        const type = typeInputEl.value.trim();
        const age = ageInputEl.value.trim();
        const gender = genderSelectEl.value;

        typeInputEl.value = '';
        ageInputEl.value = '';
        genderSelectEl.value = '';

        if (!type || !age || !gender) return;

        const liEl = document.createElement('li');
        const articleEl = document.createElement('article');
        const pTypeEl = document.createElement('p');
        pTypeEl.textContent = `Pet:${type}`;
        const pGenderEl = document.createElement('p');
        pGenderEl.textContent = `Gender:${gender}`;
        const pAgeEl = document.createElement('p');
        pAgeEl.textContent = `Age:${age}`;

        articleEl.appendChild(pTypeEl);
        articleEl.appendChild(pGenderEl);
        articleEl.appendChild(pAgeEl);

        liEl.appendChild(articleEl);

        const buttonsDivEl = document.createElement('div');
        buttonsDivEl.classList.add('buttons');

        const editBtnEl = document.createElement('button');
        editBtnEl.classList.add('edit-btn');
        editBtnEl.textContent = 'Edit';
        editBtnEl.addEventListener('click', handleEditInfo);

        const doneBtnEl = document.createElement('button');
        doneBtnEl.classList.add('done-btn');
        doneBtnEl.textContent = 'Done';
        doneBtnEl.addEventListener('click', handleFinishAdoption);

        buttonsDivEl.appendChild(editBtnEl);
        buttonsDivEl.appendChild(doneBtnEl);

        liEl.appendChild(buttonsDivEl);

        infoUlEl.appendChild(liEl);

        function handleEditInfo() {
            liEl.remove();
            typeInputEl.value = type;
            ageInputEl.value = age;
            genderSelectEl.value = gender;
        }

        function handleFinishAdoption() {
            liEl.remove();
            buttonsDivEl.remove();

            const clearBtnEl = document.createElement('button');
            clearBtnEl.classList.add('clear-btn');
            clearBtnEl.textContent = 'Clear';
            clearBtnEl.addEventListener('click', handleClearInfo);

            liEl.appendChild(clearBtnEl);

            listUlEl.appendChild(liEl);

            function handleClearInfo() {
                liEl.remove();
            }
        }
    }
}
  