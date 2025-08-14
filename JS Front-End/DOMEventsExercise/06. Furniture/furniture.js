document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const inputForm = document.querySelector('#input');
    const shopForm = document.querySelector('#shop');
    const resAreaEl = shopForm.querySelector('textarea');

    inputForm.addEventListener('submit', generateFurniture);
    shopForm.addEventListener('submit', buyFurniture);

    function generateFurniture(e) {
        e.preventDefault();

        const tbodyEl = document.querySelector('#shop tbody')
        const furnitureObjs = JSON.parse(inputForm.querySelector('textarea').value.trim());

        for (const furnitureObj of furnitureObjs) {
            const newTrEl = document.createElement('tr');

            const imageTdEl = document.createElement('td');
            const imageEl = document.createElement('img');
            imageEl.src = furnitureObj.img;
            imageTdEl.appendChild(imageEl);
            newTrEl.appendChild(imageTdEl);
            
            const nameTdEl = document.createElement('td');
            let namePEl = document.createElement('p');
            namePEl.textContent = furnitureObj.name;
            nameTdEl.appendChild(namePEl);
            newTrEl.appendChild(nameTdEl);

            const priceTdEl = document.createElement('td');
            let pricePEl = document.createElement('p');
            pricePEl.textContent = furnitureObj.price;
            priceTdEl.appendChild(pricePEl);
            newTrEl.appendChild(priceTdEl);

            const dfTdEl = document.createElement('td');
            let dfPEl = document.createElement('p');
            dfPEl.textContent = furnitureObj.decFactor;
            dfTdEl.appendChild(dfPEl);
            newTrEl.appendChild(dfTdEl);

            const markTdEl = document.createElement('td');
            const markEl = document.createElement('input');
            markEl.type = 'checkbox';
            markTdEl.appendChild(markEl);
            newTrEl.appendChild(markTdEl);

            tbodyEl.appendChild(newTrEl);
        }
    }

    function buyFurniture(e) {
        e.preventDefault();
        
        const allCheckedEls = Array.from(shopForm.querySelectorAll('input:checked'));
        const allCheckedTrEls = allCheckedEls.map(el => el.closest('tr'));
        
        const allNames = allCheckedTrEls.map(el => el.querySelector('td:nth-child(2) p').textContent);
        const allPrices = allCheckedTrEls.map(el => Number(el.querySelector('td:nth-child(3) p').textContent));
        const totalPrice = allPrices.reduce((acc, val) => acc + val);
        
        const allDecFacs = allCheckedTrEls.map(el => Number(el.querySelector('td:nth-child(4) p').textContent));
        const avgDecFac = allDecFacs.reduce((acc, val) => acc + val) / allDecFacs.length;
        
        resAreaEl.value += `Bought furniture: ${allNames.join(', ')}\n`;
        resAreaEl.value += `Total price: ${totalPrice}\n`;
        resAreaEl.value += `Average decoration factor: ${avgDecFac}`;
    }
}