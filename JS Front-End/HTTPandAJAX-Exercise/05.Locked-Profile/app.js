async function lockedProfile() {
    const mainEl = document.getElementById('main');

    const profilesRes = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
    const profilesData = await profilesRes.json();
    const profilesArr = Object.values(profilesData);

    let count = 1;
    
    profilesArr.forEach(profile => {
        console.log(profile);
        const profileDivEl = document.createElement('div');
        profileDivEl.classList.add('profile');

        const imgEl = document.createElement('img');
        imgEl.src = 'iconProfile2.png';
        imgEl.classList.add('userIcon');
        profileDivEl.appendChild(imgEl);

        const lockLabelEl = document.createElement('label');
        lockLabelEl.textContent = 'Lock';
        profileDivEl.appendChild(lockLabelEl);

        const lockInputEl = document.createElement('input');
        lockInputEl.type = 'radio';
        lockInputEl.name = `user${count}Locked`;
        lockInputEl.value = 'lock';
        profileDivEl.appendChild(lockInputEl);
        lockInputEl.checked = true;

        const unlockLabelEl = document.createElement('label');
        unlockLabelEl.textContent = 'Unlock';
        profileDivEl.appendChild(unlockLabelEl);

        const unlockInputEl = document.createElement('input');
        unlockInputEl.type = 'radio';
        unlockInputEl.name = `user${count}Locked`;
        unlockInputEl.value = 'unlock';
        profileDivEl.appendChild(unlockInputEl);
        unlockInputEl.checked = false;

        const brEl = document.createElement('br');
        profileDivEl.appendChild(brEl);

        const hrEl = document.createElement('hr');
        profileDivEl.appendChild(hrEl);

        const usernameLabel = document.createElement('label');
        usernameLabel.textContent = 'Username';
        profileDivEl.appendChild(usernameLabel);

        const usernameInputEl = document.createElement('input');
        usernameInputEl.type = 'text';
        usernameInputEl.name = `user${count}Username`;
        usernameInputEl.value = profile.username;
        usernameInputEl.disabled = true;
        usernameInputEl.readOnly = true;
        profileDivEl.appendChild(usernameInputEl);

        const hiddenInfoDivEl = document.createElement('div');
        hiddenInfoDivEl.classList.add('user1Username');
        hiddenInfoDivEl.style.display = 'none';

        hiddenInfoDivEl.appendChild(hrEl);
        
        const emailLabel = document.createElement('label');
        emailLabel.textContent = 'Email:';
        
        const emailInputEl = document.createElement('input');
        emailInputEl.type = 'email';
        emailInputEl.name = `user1Email`;
        emailInputEl.value = profile.email;
        emailInputEl.disabled = true;
        emailInputEl.readOnly = true;
        
        const ageLabel = document.createElement('label');
        ageLabel.textContent = 'Age:';
        
        const ageInputEl = document.createElement('input');
        ageInputEl.type = 'number';
        ageInputEl.name = `user1Age`;
        ageInputEl.value = profile.age;
        ageInputEl.disabled = true;
        ageInputEl.readOnly = true;
        
        hiddenInfoDivEl.appendChild(emailLabel);
        hiddenInfoDivEl.appendChild(emailInputEl);
        hiddenInfoDivEl.appendChild(ageLabel);
        hiddenInfoDivEl.appendChild(ageInputEl);

        const buttonEl = document.createElement('button');
        buttonEl.textContent = 'Show more';

        buttonEl.addEventListener('click', handleBtnFunctionality);

        function handleBtnFunctionality() {
            if (buttonEl.textContent === 'Show more' && unlockInputEl.checked === true) {
                hiddenInfoDivEl.style.display = 'block';
                buttonEl.textContent = 'Hide it';
                hiddenInfoDivEl.appendChild(buttonEl);
            } else if ( unlockInputEl.checked === true) {
                profileDivEl.appendChild(buttonEl);
                hiddenInfoDivEl.style.display = 'none';
                buttonEl.textContent = 'Show more';
            }
        }

        profileDivEl.appendChild(buttonEl);
        profileDivEl.appendChild(hiddenInfoDivEl);
        mainEl.appendChild(profileDivEl);

        count++;
    });
}