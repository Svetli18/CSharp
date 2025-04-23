function solve(array){
    let sum = 0;
    let invertedSum = 0;
    let conkat = "";

    for (let i = 0; i < array.length; i++) {
        sum += array[i];
        invertedSum += 1 / array[i];
        conkat += array[i];
    }

    console.log(sum);
    console.log(invertedSum);
    console.log(conkat);
}

let array = [2, 4, 8, 16];

solve(array)