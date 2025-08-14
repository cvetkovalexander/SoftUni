

function vacation(people, group, day) {
    let multiplier = 0;
    let price;
    switch (group) {
        case `Students`:
            if (day === `Friday`) multiplier = 8.45;
            else if (day === `Saturday`) multiplier = 9.8;
            else if (day === `Sunday`) multiplier = 10.46;

            price = people * multiplier;
            if (people >= 30) price *= 0.85;

            break;
        case `Business`:
            if (day === `Friday`) multiplier = 10.9;
            else if (day === `Saturday`) multiplier = 15.6;
            else if (day === `Sunday`) multiplier = 16;

            if (people >= 100) people -= 10;
            price = people * multiplier;

            break;
        case `Regular`:
            if (day === `Friday`) multiplier = 15;
            else if (day === `Saturday`) multiplier = 20;
            else if (day === `Sunday`) multiplier = 22.5;

            price = people * multiplier;
            if (people >= 10 && people <= 20) price *= 0.95;

            break;
    }

    console.log(`Total price: ${price.toFixed(2)}`);
}