
function solve(input) {
    const n = input.shift();
    let warriors = {};

    for (let i = 0; i < n; i++) {
        const tokens = input.shift().split('-');
        warriors[tokens[0]] = { weapons: [tokens[1]] ,strength: Number(tokens[2]) };
    }

    let command = input.shift();

    while (command !== 'The Saga Ends') {
        const tokens = command.split(' -> ');
        const name = tokens[1];
        if (warriors[name].strength <= 0) return;

        if (tokens[0] === 'Raid') {
            if (warriors[name].weapons.includes(tokens[2]) && warriors[name].strength >= Number(tokens[3])) {
                warriors[name].strength -= Number(tokens[3]);
                console.log(`${name} fought bravely with ${tokens[2]} and now has ${warriors[name].strength} strength!`);
            } else {
                console.log(`${name} couldn't join the raid with ${tokens[2]}!`);
            }
        } else if (tokens[0] === 'Train') {
            if (warriors[name].strength === 100) {
                console.log(`${name} is already at full strength!`)
            } else {
                const amount = Number(tokens[2]);

                if (warriors[name].strength + amount > 100) {
                    console.log(`${name} trained hard and gained ${100 - warriors[name].strength} strength!`);
                    warriors[name].strength = 100;
                } else {
                    warriors[name].strength += amount;
                    console.log(`${name} trained hard and gained ${amount} strength!`);
                }
            }
        } else {
            if (warriors[name].weapons.includes(tokens[2])) {
                console.log(`${name} already wields ${tokens[2]}.`);
            } else {
                warriors[name].weapons.push(tokens[2]);
                console.log(`${name} has forged a new weapon: ${tokens[2]}!`);
            }
        }

        command = input.shift();
    }

    const entries = Object.entries(warriors);
    
    for (const [name, stats] of entries) {
        console.log(`Warrior: ${name}`);
        console.log(` - Weapons: ${stats.weapons.join(', ')}`);
        console.log(` - Strength: ${stats.strength}`);
    }
}

solve([
    "3",
    "Ragnar-Axe-80",
    "Lagertha-Spear-95",
    "Bjorn-Sword-100",
    "Raid -> Ragnar -> Axe -> 30",
    "Forge -> Ragnar -> Shield",
    "Train -> Lagertha -> 10",
    "Train -> Bjorn -> 5",
    "Forge -> Lagertha -> Spear",
    "The Saga Ends"
]);
