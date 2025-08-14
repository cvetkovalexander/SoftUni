

function addressBook(arr) {

    let addresses = [];
    for (const str of arr) {
        let [name, address] = str.split(':');
        addresses[name] = address;
    }

    let entries = Object.entries(addresses);
    for (const [name, address] of entries.sort((a, b) => a[0].localeCompare(b[0]))) {
        console.log(`${name} -> ${address}`);
    }

}

addressBook(['Tim:Doe Crossing',
 'Bill:Nelson Place',
 'Peter:Carlyle Ave',
 'Bill:Ornery Rd']
);