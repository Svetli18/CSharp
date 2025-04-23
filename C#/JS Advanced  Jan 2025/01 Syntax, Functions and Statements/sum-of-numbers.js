function sum(numb1, numb2){
    let result = 0;
    let n1 = Number(numb1);
    let n2 = Number(numb2);

    for (let index = n1; index <= n2; index++) {
        result = result + index;
    }

    console.log(result);
}

sum(1, 5);