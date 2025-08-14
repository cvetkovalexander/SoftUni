


function fruit(fruit, grams, price) {
    let cost = price * grams / 1000;
    console.log(`I need $${cost.toFixed(2)} to buy ${(grams / 1000).toFixed(2)} kilograms ${fruit}.`);
}

fruit(`orange`, 2500, 1.80);