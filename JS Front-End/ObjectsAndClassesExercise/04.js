function solve(data) {
    let movies = [];

    for (const str of data) {
        if (str.includes('addMovie')) {
            let [_, name] = str.split('addMovie ');
            let movie = { name: name };
            movies.push(movie);
        }

        else if (str.includes('directedBy')) {      
            let [name, director] = str.split(' directedBy ');
            let current = movies.find(movie => movie.name === name);

            if (current) {
                current.director = director;
            }
        }

        else if (str.includes('onDate')) {
            let [name, date] = str.split(' onDate ');
            let current = movies.find(movie => movie.name === name);

            if (current) {
                current.date = date;
            }
        }
    }

    let validMovies = movies.filter(movie => movie.director && movie.date);
    validMovies.forEach(movie => console.log(JSON.stringify(movie)));

}

solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
);