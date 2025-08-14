

function login(arr) {
    let username = arr.shift();
    let password = username.split(``).reverse().join(``);
    let tries = 0;

    for (const guess of arr) {
        if (guess == password) {
            console.log(`User ${username} logged in.`);
            break;
        }

        tries++;
        if (tries === 4) {
            console.log(`User ${username} blocked!`);
            break;
        }

        console.log("Incorrect password. Try again.");
    }

}

login(['Acer','login','go','let me in','recA']);