

function meetings(arr) {

    let scheduledDays = [];

    for (const str of arr) {
        let [day, name] = str.split(' ');


        if (day in scheduledDays) {
            console.log(`Conflict on ${day}!`);
        }
        else {
            scheduledDays[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }

    let entries = Object.entries(scheduledDays);

    for (const [day, name] of entries) {
        console.log(`${day} -> ${name}`);
    }

}


meetings(['Monday Peter',
 'Wednesday Bill',
 'Monday Tim',
 'Friday Tim']
);