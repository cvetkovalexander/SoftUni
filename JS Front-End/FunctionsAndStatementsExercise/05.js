

function isPalindrome(arr) {
    for (let num of arr) {
        
        let numStr = num.toString();
        let isPali = true;
        for (let i = 0; i < numStr.length / 2; i++) {
            if (numStr[i] !==    numStr[numStr.length - 1 - i]) {
                isPali = false;
                break;
            }
        }
        console.log(isPali);
    }
}

isPalindrome([123, 323, 421, 121]);