function solve (numbers) {
    let result = [];
    while (result.length < 2) {
        
        let smallestNumber = Number.MAX_SAFE_INTEGER;
        let index = -1;

        for (let i = 0; i < numbers.length; i++) {
            if (numbers[i] < smallestNumber && result[0] != i) {
                smallestNumber = numbers[i];
                index = i;
            }
        }
        
        result.push(index);

    }
    const strResult = numbers[result[0]] + " " + numbers[result[1]];
    console.log(strResult);
}

const numbers = [30, 15, 50, 5];
const numbers2 = [3, 0, 10, 4, 7, 3];
solve(numbers2);