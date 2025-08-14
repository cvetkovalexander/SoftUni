

function towns(arr) {

    let towns = [];
    for (const  str of arr) {
        let [name, latitude, longitude] = str.split(" | ");
        let town = {
            name,
            latitude,
            longitude
        }
        towns.push(town);
    }

    for (const town of towns) {
        console.log(`{ town: '${town.name}', latitude: '${Number(town.latitude).toFixed(2)}', longitude: '${Number(town.longitude).toFixed(2)}' }`);
    }

}

towns(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);