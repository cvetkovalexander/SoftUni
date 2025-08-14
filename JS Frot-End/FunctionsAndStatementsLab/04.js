function calculateOrder(product, count) {
    let dict = {
        coffee: 1.5,
        water: 1,
        coke: 1.4,
        snacks: 2
    };

    console.log(`${(dict[product] * count).toFixed(2)}`);
}

calculateOrder(`water`, 5);