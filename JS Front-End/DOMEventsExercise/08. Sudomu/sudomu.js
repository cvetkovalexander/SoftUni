document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const tableEl = document.querySelector('table');
    const clearBtnEl = document.querySelector('input[type="reset"]');
    const checkBtnEl = document.querySelector('input[type="submit"]');
    const resEl = document.querySelector('#check');
    const allTdInputEls = document.querySelectorAll('#solutionCheck td input');
    
    clearBtnEl.addEventListener('click', clearCells);
    checkBtnEl.addEventListener('click', checkCells);

    function clearCells(e) {
        allTdInputEls.forEach(tdEl => tdEl.textContent = "");
    }

    function checkCells(e) {
        e.preventDefault();
        const inputValues = Array.from(allTdInputEls).map(tdEl => tdEl.value);
        const dividedEls = [];

        for (let i = 0; i < inputValues.length; i += 3) {
            dividedEls.push(inputValues.slice(i, i + 3));
        }

        const isSudomu = verifySudomu(dividedEls);

        if (isSudomu) {
            resEl.textContent = "Success!";
            tableEl.style.border = "2px solid green";
        } else {
            resEl.textContent = "Keep trying...";
            tableEl.style.border = "2px solid red";
        }

    }

    function verifySudomu(elements) {
        for (let i = 0 ; i < elements.length; i++) {
            for (let j = 1; j < elements[i].length; j++) {
                let curr = elements[i][j];
                if (curr < 0 && curr > 3) return false;
                if (curr === elements[i][j - 1]) return false;
                if (elements[j][i] === elements[j - 1][i]) return false;
            }
        }

        return true;
    }
}