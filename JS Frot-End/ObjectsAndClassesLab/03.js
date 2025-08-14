

function convertToObj(json) {
    let obj = JSON.parse(json);

    let entries = Object.entries(obj);

    for (const [prop, value] of entries) {
        console.log(`${prop}: ${value}`)
    }
}

convertToObj('{"name": "George", "age": 40, "town": "Sofia"}');