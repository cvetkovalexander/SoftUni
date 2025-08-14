const tbodyEl = document.querySelector('tbody');
const formEl = document.querySelector('#form');

const firstNameInputEl = document.querySelector('input[name="firstName"]');
const lastNameInputEl = document.querySelector('input[name="lastName"]');
const facultyNumberInputEl = document.querySelector('input[name="facultyNumber"]');
const gradeInputEl = document.querySelector('input[name="grade"]');

formEl.addEventListener('submit', createStudent);

async function createStudent(e) {
    e.preventDefault();

    const firstName = firstNameInputEl.value.trim();
    const lastName = lastNameInputEl.value.trim();
    const facultyNumber = facultyNumberInputEl.value.trim();
    const grade = Number(gradeInputEl.value.trim());

   await fetch('http://localhost:3030/jsonstore/collections/students', {
        method: 'POST',
        header: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            firstName,
            lastName,
            facultyNumber,
            grade
        })
    });

    loadStudents();
}

async function loadStudents() {
    const studentsRes = await fetch('http://localhost:3030/jsonstore/collections/students');
    const studentsData = await studentsRes.json();
    const studentsArr = Object.values(studentsData);

    tbodyEl.innerHTML = '';

    studentsArr.forEach(student => {
        const trEl = document.createElement('tr');

        const firstNameTdEl = document.createElement('td');
        firstNameTdEl.textContent = student.firstName;
        trEl.appendChild(firstNameTdEl);

        const lastNameTdEl = document.createElement('td');
        lastNameTdEl.textContent = student.lastName;
        trEl.appendChild(lastNameTdEl);

        const facultyNumberTdEl = document.createElement('td');
        facultyNumberTdEl.textContent = student.facultyNumber;
        trEl.appendChild(facultyNumberTdEl);

        const gradeTdEl = document.createElement('td');
        gradeTdEl.textContent = student.grade;
        trEl.appendChild(gradeTdEl);

        tbodyEl.appendChild(trEl);
    });
}

loadStudents();