function slove(n1, n2, operator){
    let result;
    switch (operator) {
        case '+': result = n1 + n2; break;
        case '-': result = n1 - n2; break;
        case '*': result = n1 * n2; break;
        case '/': result = n1 / n2; break;
        case '%': result = n1 % n2; break;
        case '**': result = n1 ** n2; break;
    }

    console.log(result);
}

let n1 = 3;
let n2 = 5.5;
let operator = '*';

slove(n1, n2, operator);