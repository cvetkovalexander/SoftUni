

function convertToJSON(name, lastName, hairColor) {
    let obj = {
        name,
        lastName,
        hairColor
    };

    let json = JSON.stringify(obj);
    console.log(json);
}


convertToJSON('George', 'Jones', 'Brown');