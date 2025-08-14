document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const encodeForm = document.getElementById('encode');
    const decodeForm = document.getElementById('decode');

    const senderArea = encodeForm.querySelector('textarea');
    const receiverArea = decodeForm.querySelector('textarea');

    encodeForm.addEventListener('submit', encodeMessage);
    decodeForm.addEventListener('submit', decodeMessage);

    function encodeMessage(e) {
        e.preventDefault();

        const message = senderArea.value;
        senderArea.value = '';

        let encodedMsg = '';
        for (const char of message) {
            let currAscii = char.charCodeAt();
            currAscii += 1;
            let newChar = String.fromCharCode(currAscii);
            encodedMsg += newChar;
        }

        receiverArea.value = encodedMsg;
    }

    function decodeMessage(e) {
        e.preventDefault();

        const message = receiverArea.value;
        let decodedMsg = '';
        
        for (const char of message) {
            let currAscii = char.charCodeAt();
            currAscii -= 1;
            let newChar = String.fromCharCode(currAscii);
            decodedMsg += newChar;
        }

        receiverArea.value = decodedMsg; 
    }
}