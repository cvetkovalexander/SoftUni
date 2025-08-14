

function solve(nums) {
    nums.sort((a, b) => a - b);
    let filtered = [];
    while (nums.length > 0) {
        filtered.push(nums.shift());
        if (nums.length > 0) filtered.push(nums.pop());
    }

    return filtered;
}

let arr = [1, 65, 3, 52, 48, 63, 31, -3, 18, 56];
console.log(solve(arr).join(` `));