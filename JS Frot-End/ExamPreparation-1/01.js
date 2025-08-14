

function solve(input) {
    const n = Number(input.shift());

    let heroes = {};
    let gunnedHeroes = [];
    
    for (let i = 0; i < n; i++) {
        const data = input.shift().split(' ');
        let hero = {
            name: data[0],
            hp: Number(data[1]),
            bullets: Number(data[2])
        };

        heroes[hero.name] = hero;
    }

    for (let i = 0; i < input.length; i++) {
        if (input[i] === 'Ride Off Into Sunset') {
            for (const hero of Object.values(heroes)) {
                if (!(gunnedHeroes.includes(hero.name))) {
                    console.log(hero.name);
                    console.log(` HP: ${hero.hp}`);
                    console.log(` Bullets: ${hero.bullets}`);
                }
            }
            return;
        }

        const tokens = input[i].split(' - ');
        let hero = heroes[tokens[1]];
        
        if (tokens[0] === 'FireShot') {
            if (hero.bullets > 0) {
                hero.bullets -= 1;
                console.log(`${hero.name} has successfully hit ${tokens[2]} and now has ${hero.bullets} bullets!`);
            } else {
                console.log(`${hero.name} doesn't have enough bullets to shoot at ${tokens[2]}!`);
            }
        } else if (tokens[0] === 'TakeHit') {
            const damage = Number(tokens[2]);
            hero.hp -= damage;

            if (hero.hp > 0) {
                console.log(`${hero.name} took a hit for ${damage} HP from ${tokens[3]} and now has ${hero.hp} HP!`);
            } else {
                console.log(`${hero.name} was gunned down by ${tokens[3]}!`);
                gunnedHeroes.push(hero.name);
            }
        } else if (tokens[0] === 'Reload') {
            if (hero.bullets < 6) {
                console.log(`${hero.name} reloaded ${6 - hero.bullets} bullets!`);
                hero.bullets = 6
            } else {
                console.log(`${hero.name}'s pistol is fully loaded!`);
            }
        } else if (tokens[0] === 'PatchUp') {
            if (hero.hp === 100) {
                console.log(`${hero.name} is in full health!`);
            } else {
                const amount = Number(tokens[2]);
                if (hero.hp + amount > 100) {
                    console.log(`${hero.name} patched up and recovered ${100 - hero.hp} HP!`);
                    hero.hp = 100;
                } else {
                    console.log(`${hero.name} patched up and recovered ${amount} HP!`);
                    hero.hp += amount;
                }
            }
        }
    }
}

solve(["2",
   "Gus 100 0",
   "Walt 100 6",
   "FireShot - Gus - Bandit",
   "TakeHit - Gus - 100 - Bandit",
   "Reload - Walt",
   "Ride Off Into Sunset"]
);