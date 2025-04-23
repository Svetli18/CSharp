function solve(n, k){
    let numbers = [n];
    numbers[0] = 1;

    for (let i = 1; i < n; i++) {
        let sum = 0;
        let startIndex = Math.max(0, i - k);

        for (let j = startIndex; j < i; j++) {
            sum += numbers[j];
        }

        numbers[i] = sum;
    }
    return numbers;
}

//const n = 6;
const n = 8;
//const k = 3;
const k = 2;

solve(n, k);