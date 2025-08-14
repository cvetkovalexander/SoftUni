
const loadGamesBtnEl = document.getElementById('load-games');
const gamesListDivEl = document.getElementById('games-list');
const addGameBtnEl = document.getElementById('add-game');
const editGameBtnEl = document.getElementById('edit-game');
const nameInputEl = document.getElementById('g-name');
const typeInputEl = document.getElementById('type');
const playersInputEl = document.getElementById('players');

loadGamesBtnEl.addEventListener('click', loadGames);
addGameBtnEl.addEventListener('click', addGame);
editGameBtnEl.addEventListener('click', editGame);

let selectedGameId = null;

async function loadGames() {
    const allGamesRes = await fetch('http://localhost:3030/jsonstore/games/');
    const allGamesData = await allGamesRes.json();
    const allGamesArr = Object.values(allGamesData);

    gamesListDivEl.innerHTML = '';

    allGamesArr.forEach(game => {
        const boardGameDivEl = document.createElement('div');
        boardGameDivEl.classList.add('board-game');

        const contentDivEl = document.createElement('div');
        contentDivEl.classList.add('content');

        const pNameEl = document.createElement('p');
        pNameEl.textContent = game.name;

        const pPlayersEl = document.createElement('p');
        pPlayersEl.textContent = game.players;

        const pTypeEl = document.createElement('p');
        pTypeEl.textContent = game.type;

        contentDivEl.appendChild(pNameEl);
        contentDivEl.appendChild(pPlayersEl);
        contentDivEl.appendChild(pTypeEl);

        const buttonsContainerDivEl = document.createElement('div');
        buttonsContainerDivEl.classList.add('buttons-container');

        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';

        changeBtnEl.addEventListener('click', changeGameInfo);

        function changeGameInfo() {
            nameInputEl.value = game.name;
            typeInputEl.value = game.type;
            playersInputEl.value = game.players;

            addGameBtnEl.disabled = true;
            editGameBtnEl.disabled = false;

            selectedGameId = game._id;
        }

        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';

        deleteBtnEl.addEventListener('click', deleteGame);

        async function deleteGame() {
            await fetch(`http://localhost:3030/jsonstore/games/${game._id}`, {
                method: 'DELETE'
            });

            await loadGames();
        }

        buttonsContainerDivEl.appendChild(changeBtnEl);
        buttonsContainerDivEl.appendChild(deleteBtnEl);

        boardGameDivEl.appendChild(contentDivEl);
        boardGameDivEl.appendChild(buttonsContainerDivEl);

        gamesListDivEl.appendChild(boardGameDivEl);
    });
}

async function addGame() {
    const name = nameInputEl.value.trim();
    const type = typeInputEl.value.trim();
    const players = playersInputEl.value.trim();

    nameInputEl.value = '';
    typeInputEl.value = '';
    playersInputEl.value = '';

    await fetch('http://localhost:3030/jsonstore/games/', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, type, players })
    });

    await loadGames();
}

async function editGame() {
    const name = nameInputEl.value.trim();
    const type = typeInputEl.value.trim();
    const players = playersInputEl.value.trim();

    await fetch(`http://localhost:3030/jsonstore/games/${selectedGameId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name, type, players})
    });

    nameInputEl.value = '';
    typeInputEl.value = '';
    playersInputEl.value = '';

    selectedGameId = null;

    addGameBtnEl.disabled = false;
    editGameBtnEl.disabled = true;

    await loadGames();
}