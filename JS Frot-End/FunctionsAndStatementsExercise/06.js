

function passValidator(pass) {

    let isValidLength = validateLength();
    let isAlphanumeric = validateAlphanumeric();
    let hasEnoughDigits = validateEnoughDigits();

    if (isValidLength && isAlphanumeric && hasEnoughDigits)
        console.log("Password is valid")


    function validateLength() {
        if (pass.length < 6 || pass.length > 10) {
            console.log("Password must be between 6 and 10 characters");
            return false;
        }
        return true;
    }

    function validateAlphanumeric() {
        let pattern = /^[A-Za-z0-9]+$/;

        if (!pattern.test(pass)){
            console.log("Password must consist only of letters and digits");
            return false;
        }
        return true;
    }

    function validateEnoughDigits() {
        let matches = pass.match(/\d/g);
        if (matches === null || matches.length < 2) {
            console.log("Password must have at least 2 digits");
            return false;
        }
        return true;
    }
}

passValidator('MyPass');