function solve(input){
    let result = input.sort((a, b) => a - b);
    
    return result.slice(Math.floor(result.length / 2));
}

const input1 = [4, 7, 2, 5];
const input2 = [3, 19, 14, 7, 2, 19, 6];

console.log(solve(input2));