

function phoneBook(arr) {

    let assocArr = [];

    for (const str of arr) {
        let [name, number] = str.split(' ');
        assocArr[name] = number;
    }

    let entries = Object.entries(assocArr);

    for (const [name, number] of entries) {
        console.log(`${name} -> ${number}`);
    }

}

phoneBook(['Tim 0834212554',
 'Peter 0877547887',
 'Bill 0896543112',
 'Tim 0876566344']
);