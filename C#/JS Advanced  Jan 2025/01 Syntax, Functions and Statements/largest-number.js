function getLargestNumber(n1, n2, n3){
    let result = Math.max(n1, n2, n3);

    return `The largest number is ${result}.`;
}

let n1 = 5;
let n2 = -3;
let n3 = 16;

let result = getLargestNumber(n1, n2, n3);

console.log(result)