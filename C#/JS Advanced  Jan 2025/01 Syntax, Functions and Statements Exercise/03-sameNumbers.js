function solution(numbers){
    let sum = 0;
    let prevNumner = numbers % 10;
    let isSame = true

    while(0 < numbers){
        let currNumb = numbers % 10
        sum += currNumb;
        numbers = Math.floor(numbers / 10);
        if(prevNumner !== currNumb){
            isSame = false;
        }

        prevNumner = currNumb;
    }

    console.log(isSame);
    console.log(sum);
}

solution(1234);
solution(2222222);