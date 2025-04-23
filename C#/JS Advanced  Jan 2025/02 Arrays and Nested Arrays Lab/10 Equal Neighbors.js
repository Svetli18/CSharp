function solve(matrix){
    let cnt = Number(0);

    for (let i = 0; i < matrix.length; i++) {
        const currentArray = matrix[i];
        for (let j = 0; j < currentArray.length; j++) {
            const element = currentArray[j];
            let rightElement = "";
            let downElement = "";
            if (j + 1 < currentArray.length) {
                rightElement = currentArray[j + 1];
            }
            if (i + 1 < matrix.length) {
                const downArray = matrix[i + 1];
                downElement = downArray[j];
            }
            if (element === rightElement) {
                cnt += 1;
            }
            if (element === downElement) {
                cnt += 1;
            }
        }
    }
    return Number(cnt);
}
const matrix1 = [['2', '3', '4', '7', '0'], ['4', '0', '5', '3', '4'], ['2', '3', '5', '4', '2'], ['9', '8', '7', '5', '4']];
const matrix2 = [['test', 'yes', 'yo', 'ho'], ['well', 'done', 'yo', '6'], ['not', 'done', 'yet', '5']];
const matrix3 = [[2, 2, 5, 7, 4], [4, 0, 5, 3, 4], [2, 5, 5, 4, 2]];
const result = solve(matrix3);
const it = "hi";
console.log(result);