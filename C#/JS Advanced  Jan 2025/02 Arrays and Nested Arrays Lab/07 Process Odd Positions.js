function solve (numbers){
    const result = [];

    for (let i = 0; i < numbers.length; i++) {
        if (i % 2 != 0) {
            const element = numbers[i] * 2;

            result.unshift(element);
        }
    }

    return result;
}

const firstNumbers = [10, 15, 20, 25];
const secondNumbers = [3, 0, 10, 4, 7, 3];

console.log(solve(secondNumbers));