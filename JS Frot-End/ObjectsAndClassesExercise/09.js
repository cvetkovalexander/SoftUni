

function solve(arr) {
    let dictionary = {};

    for (const jsonStr of arr) {
        let termObj = JSON.parse(jsonStr);
        let entries = Object.entries(termObj);
        let [term, info] = entries[0];
        dictionary[term] = info;
    }

    let entries = Object.entries(dictionary);
    for (const [term, info] of entries.sort((a, b) => a[0].localeCompare(b[0]))) {
        console.log(`Term: ${term} => Definition: ${info}`);
    }
}

solve([
    '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
    '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
    '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
    '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
    '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}'
]
);