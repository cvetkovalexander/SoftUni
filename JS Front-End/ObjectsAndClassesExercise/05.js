

function heroRegister(input) {
    let inventory = [];

    for (const str of input) {
        let [name, level, items] = str.split(' / ');
        let hero = {
            name: name,
            level: level,
            items: items
        }
        inventory.push(hero);
    }

    for (const hero of inventory.sort((a, b) => a.level - b.level)) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items  }`);
    }

}

heroRegister([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);