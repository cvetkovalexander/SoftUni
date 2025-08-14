function solve() {
    const checkEls = document.querySelectorAll('input[type="checkbox"]');
    const trEls = document.querySelectorAll('tbody tr');
    const outputEl = document.getElementById('output');

    const checkedCols = [];

    checkEls.forEach((el, idx) => {
        if (el.checked) {
            checkedCols.push({
                index: idx,
                name: el.name
            })
        }
    });

    let report = [];

    trEls.forEach(trEl => {
        const tdEls = trEl.children;
        let rowData = {};

        checkedCols.forEach(col => {
            const propName = col.name;
            const index = col.index;
            const propValue = tdEls[index].textContent;
            rowData[propName] = propValue;
        });
        
        report.push(rowData);
    });

    outputEl.value = JSON.stringify(report);
}