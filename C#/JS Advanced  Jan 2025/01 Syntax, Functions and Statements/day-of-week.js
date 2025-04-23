function dayOfWeek(day){
    let result;
    switch (day) {
        case day = 'Monday': result = 1; break;
        case day = 'Tuesday': result = 2; break; 
        case day = 'Wednesday': result = 3; break;
        case day = 'Thursday': result = 4; break;
        case day = 'Friday': result = 5; break;
        case day = 'Saturday': result = 6; break;
        case day = 'Sunday': result = 7; break;
        default: result = 'error'; break;
    }

    console.log(result);
}
let day = 'Invalid';

dayOfWeek(day);