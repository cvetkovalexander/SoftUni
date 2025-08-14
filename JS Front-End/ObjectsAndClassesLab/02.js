

function printObj(obj) {
    let entries = Object.entries(obj);

    for (const entry of entries) {
        console.log(`${entry[0]} -> ${entry[1]}`)
    }
}

printObj({
    name: "Sofia",
    area: 492,
    population: 1238438,
    country: "Bulgaria",
    postCode: "1000"
})

