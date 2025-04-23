function solve(matrix){

    let fromLeftSum = 0;
    let fromRightSum = 0;
    for (let i = 0; i < matrix.length; i++) {
        const element = matrix[i];
        
        fromLeftSum += element[i];
        fromRightSum += element[element.length - 1 - i];
    }

    let result = fromLeftSum + ' ' + fromRightSum;

    console.log(result);
}

const matrix1 = [[20, 40], [10, 60]];
const matrix2 = [[3, 5, 17], [-1, 7, 14], [1, -8, 89]];

solve(matrix1);