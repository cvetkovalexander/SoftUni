

function storeProvision(stock, products) {
    
    let storage = [];
    for (let i = 0; i < stock.length; i += 2) {
        let quantity = Number(stock[i + 1]);
        storage[stock[i]] = quantity;
    }

    for (let i = 0; i < products.length; i += 2) {
        let quantity = Number(products[i + 1]);
        if (products[i] in storage) 
            storage[products[i]] += quantity;
        else
            storage[products[i]] = quantity;
    }

    let entries = Object.entries(storage);

    for (const [product, quantity] of entries) 
        console.log(`${product} -> ${quantity}`);

}

storeProvision([
'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
[
'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
]
);