const loadBtnEl = document.getElementById('load-movies');
const addBtnEl = document.getElementById('add-movie');
const editBtnEl = document.getElementById('edit-movie');
const moviesDivEl = document.getElementById('movie-list');
const titleInputEl = document.getElementById('title');
const directorInputEl = document.getElementById('director');
const yearInputEl = document.getElementById('year');

const BASE_URL = 'http://localhost:3030/jsonstore/movies/';
let selectedMovieId = null;

addBtnEl.addEventListener('click', handleAddingMovie);
loadBtnEl.addEventListener('click', handleLoadingMovies);
editBtnEl.addEventListener('click', handleEditingMovie);

async function handleLoadingMovies() {
    const moviesRes = await fetch(BASE_URL);
    const moviesData = await moviesRes.json();
    const moviesArr = Object.values(moviesData);
    // console.log(moviesArr);

    moviesDivEl.innerHTML = '';

    moviesArr.forEach(movie => {
        const movieDivEl = document.createElement('div');
        movieDivEl.classList.add('movie');

        const contentDivEl = document.createElement('div');
        contentDivEl.classList.add('content');

        const pTitleEl = document.createElement('p');
        pTitleEl.textContent = movie.title;

        const pDirectorEl = document.createElement('p');
        pDirectorEl.textContent = movie.director;

        const pYearEl = document.createElement('p');
        pYearEl.textContent = movie.year;

        contentDivEl.appendChild(pTitleEl);
        contentDivEl.appendChild(pDirectorEl);
        contentDivEl.appendChild(pYearEl);

        const btnsContainerDivEl = document.createElement('div');
        btnsContainerDivEl.classList.add('buttons-container');

        const changeBtnEl = document.createElement('button');
        changeBtnEl.classList.add('change-btn');
        changeBtnEl.textContent = 'Change';
        changeBtnEl.addEventListener('click', handleChangingMovie);

        const deleteBtnEl = document.createElement('button');
        deleteBtnEl.classList.add('delete-btn');
        deleteBtnEl.textContent = 'Delete';
        deleteBtnEl.addEventListener('click', handleDeletingMovie);

        btnsContainerDivEl.appendChild(changeBtnEl);
        btnsContainerDivEl.appendChild(deleteBtnEl);

        movieDivEl.appendChild(contentDivEl);
        movieDivEl.appendChild(btnsContainerDivEl);

        moviesDivEl.appendChild(movieDivEl);

        function handleChangingMovie() {
            movieDivEl.remove();

            titleInputEl.value = movie.title;
            directorInputEl.value = movie.director;
            yearInputEl.value = movie.year;

            editBtnEl.disabled = false;
            addBtnEl.disabled = true;

            selectedMovieId = movie._id;
        }

        async function handleDeletingMovie() {
            await fetch(`${BASE_URL}${movie._id}`, {
                method: 'DELETE'
            });

            await handleLoadingMovies();
        }
    });
}

async function handleAddingMovie() {
    const title = titleInputEl.value.trim();
    const director = directorInputEl.value.trim();
    const year = yearInputEl.value.trim();

    titleInputEl.value = '';
    directorInputEl.value = '';
    yearInputEl.value = '';

    await fetch(BASE_URL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title, director, year })
    });

    await handleLoadingMovies();
}

async function handleEditingMovie() {
    const title = titleInputEl.value.trim();
    const director = directorInputEl.value.trim();
    const year = yearInputEl.value.trim();

    titleInputEl.value = '';
    directorInputEl.value = '';
    yearInputEl.value = '';

    await fetch(`${BASE_URL}${selectedMovieId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title, director, year })
    });

    addBtnEl.disabled = false;
    editBtnEl.disabled = true;

    await handleLoadingMovies();
}