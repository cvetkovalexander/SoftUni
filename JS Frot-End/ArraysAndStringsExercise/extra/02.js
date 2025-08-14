

function mining(shift) {
    let bitcoinPrice = 11949.16;
    let gramPrice = 67.51;

    let currentSum = 0;
    let day = 0;
    let purchasedDay = 0;
    let count = 0;

    for (let grams of shift) {
        day++;

        if (day % 3 === 0) {
            grams *= 0.7;
        }

        currentSum += grams * gramPrice;
        if (currentSum >= bitcoinPrice) {
            if (purchasedDay === 0) purchasedDay = day;
            while (currentSum >= bitcoinPrice) {
                count++;
                currentSum -= bitcoinPrice;
            }
        }
    }

    console.log(`Bought bitcoins: ${count}`);
    if (purchasedDay !== 0) {
        console.log(`Day of the first purchased bitcoin: ${purchasedDay}`);
    }  
    console.log(`Left money: ${currentSum.toFixed(2)} lv.`);
}

mining([3124.15, 504.212, 2511.124]);