

function loadingBar(num) {
    if (num === 100) {
        console.log(`100% Complete!`);
        console.log(`[%%%%%%%%%%]`);
        return;
    }

    let loadingBar = getBar(num);

    console.log(`${num}% ${loadingBar}`);
    console.log(`Still loading...`);

    function getBar(a) {
        let bar = `[..........]`;
        let barArr = bar.split('');

        for (let i = 1; i <= a / 10; i++) {
            barArr[i] = '%';
        }

        return barArr.join('');
    }
}

loadingBar(30);