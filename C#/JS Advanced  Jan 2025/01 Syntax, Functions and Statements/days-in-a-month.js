function getDaysInMonth(month, year){
    return new Date(year, month, 0).getDate();
}

let month = 1;
let year = 2012;

let daysInMonth = getDaysInMonth(month, year);

console.log(daysInMonth);