function solution(first, second){
    
    let s = Math.min(first, second);
    let b = Math.max(first, second);

    while (b !== 0){
        let temp = b;
        b = s % b;
        s = temp;
    }

    console.log(s)

}

solution(2154, 458);
solution(15, 5);