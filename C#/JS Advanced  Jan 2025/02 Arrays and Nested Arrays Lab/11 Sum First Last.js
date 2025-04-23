function solve(input){
    let firstElement = Number(input[0]);
    let lastElement = Number(input[input.length - 1]);
    let result = firstElement + lastElement;

    return result;
}

const input = ['20', '30', '40'];
const input2 = ['5', '10'];

const result = solve(input2);

console.log(result);