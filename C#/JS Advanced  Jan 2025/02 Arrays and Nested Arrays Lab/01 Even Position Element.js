function solve(input){
    let result = "";

    for (let index = 0; index < input.length; index++) {
        if (index % 2 === 0) {
            if (index == 0) {
                result = input[index];
            }
            else {
                result += ` ${input[index]}`;
            }
        }
    }

    console.log(result);
}

const input = ['20', '30', '40', '50', '60'];

solve(input);