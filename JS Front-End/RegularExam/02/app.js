window.addEventListener("load", solve);

function solve() {
    const registerBtnEl = document.getElementById('register-btn');
    const registeredUlEl = document.getElementById('registered-list');
    const confirmedUlEl = document.getElementById('confirmed-list');
    const typeInputEl = document.getElementById('type');
    const ageInputEl = document.getElementById('age');
    const genderSelectEl = document.getElementById('gender');

    registerBtnEl.addEventListener('click', handleRegisteringBlood);

    function handleRegisteringBlood(e) {
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
        pTypeEl.textContent = `Blood Type: ${type}`;

        const pGenderEl = document.createElement('p');
        pGenderEl.textContent = `Gender: ${gender}`;

        const pAgeEl = document.createElement('p');
        pAgeEl.textContent = `Age: ${age}`;

        articleEl.appendChild(pTypeEl);
        articleEl.appendChild(pGenderEl);
        articleEl.appendChild(pAgeEl);

        const btnsDivEl = document.createElement('div');
        btnsDivEl.classList.add('buttons');

        const editBtnEl = document.createElement('button');
        editBtnEl.classList.add('edit-btn');
        editBtnEl.textContent = 'Edit';
        editBtnEl.addEventListener('click', handleEditingRecord);

        const doneBtnEl = document.createElement('button');
        doneBtnEl.classList.add('done-btn');
        doneBtnEl.textContent = 'Confirm';
        doneBtnEl.addEventListener('click', handleConfirmingRecord);

        btnsDivEl.appendChild(editBtnEl);
        btnsDivEl.appendChild(doneBtnEl);

        liEl.appendChild(articleEl);
        liEl.appendChild(btnsDivEl);

        registeredUlEl.appendChild(liEl);

        function handleEditingRecord() {
            console.log('ky');
            typeInputEl.value = type;
            ageInputEl.value = age;
            genderSelectEl.value = gender;

            liEl.remove();
        }
        function handleConfirmingRecord() {
            liEl.remove();
            btnsDivEl.remove();

            const clearBtnEl = document.createElement('button');
            clearBtnEl.classList.add('clear-btn');
            clearBtnEl.textContent = 'Clear';
            clearBtnEl.addEventListener('click', handleClearingRecord);

            liEl.append(clearBtnEl);

            confirmedUlEl.appendChild(liEl);

            function handleClearingRecord() {
                liEl.remove();
            }
        }
    }
}
