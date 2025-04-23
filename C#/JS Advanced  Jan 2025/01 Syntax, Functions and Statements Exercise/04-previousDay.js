function solution(year, month, day, h = 0, m = 0){
    let date = new Date(year, month, day, h, m);
    date.setDate(date.getDate() -1);
    let result = `${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`;
    console.log(result);
}
solution(2016, 9, 30);
solution(2015, 5, 10, 0, 0);