function solve(matrix){
    let result = matrix[0][0];

    for (let i = 0; i < matrix.length; i++) {

        const curentArray = matrix[i];

        for (let j = 0; j < curentArray.length; j++) {

            const curentElement = curentArray[j];

            if (result < curentElement) {
                result = curentElement;
            }
        }
    }

    return result;
}

const matrix1 = [[20, 50, 10], [8, 33, 145]];
const matrix2 = [[3, 5, 7, 12], [-1, 4, 33, 2], [8, 3, 0, 4]];
console.log(solve(matrix2));