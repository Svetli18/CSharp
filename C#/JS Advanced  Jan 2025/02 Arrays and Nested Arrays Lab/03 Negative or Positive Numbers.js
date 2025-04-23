function solve(input){
    const length = input.length;
    let result = [];

    for (let i = 0; i < length; i++) {
        if (Number(input[i]) < 0) {
            result.unshift(input[i]);
        }
        else {
            result.push(input[i]);
        }
    }

    console.log(result.join('\n'))
}

const input = [7, -2, 8, 9];

solve(input);