

function calcPrice(day, age) {
    let res = 0;
    switch (day) {
        case "Weekday":
            if (0 <= age && age <= 18) res = 12;
            else if (18 < age && age <= 64) res = 18;
            else if (64 < age && age <= 122) res = 12;
            break;
        case "Weekend":
            if (0 <= age && age <= 18) res = 15;
            else if (18 < age && age <= 64) res = 20;
            else if (64 < age && age <= 122) res = 15;
            break;
        case "Holiday":
            if (0 <= age && age <= 18) res = 5;
            else if (18 < age && age <= 64) res = 12;
            else if (64 < age && age <= 122) res = 10;
            break;
    }

    if (res === 0) console.log(`Error!`);
    else console.log(`${res}$`);
}

calcPrice("Weekday", 5);