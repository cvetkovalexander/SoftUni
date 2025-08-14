
function roadRadar(speed, location) {
    let limit = 0;
    switch (location) {
        case `residential`:
            limit = 20;
            break;
        case `city`:
            limit = 50;
            break;
        case `interstate`:
            limit = 90;
            break;
        case `motorway`:
            limit = 130;
            break;
    }

    if (speed > limit) {
        let status = ``;
        let difference = speed - limit;
        if (difference <= 20) status = `speeding`;
        else if (difference <= 40) status = `excessive speeding`;
        else status = `reckless driving`;
        console.log(`The speed is ${speed - limit} km/h faster than the allowed speed of ${limit} - ${status}`) 
    }
    else {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    }
}

roadRadar(40, `city`);