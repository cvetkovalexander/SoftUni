


function employees(arr) {
    
    for (const name of arr) {
        let employee = {
            firstName: name,
            number: name.length
        }

        console.log(`Name: ${employee.firstName} -- Personal Number: ${employee.number}`);
    }

}


employees([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
]
);