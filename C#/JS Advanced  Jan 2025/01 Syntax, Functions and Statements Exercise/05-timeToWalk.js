function Walk(totalSteps, studentStep, studentSpeed){
    let distanceMeters = totalSteps * studentStep;
    let speedInMeterSec = studentSpeed / 3.6;
    let timeToRest = Math.floor(distanceMeters / 500);
    let timeHour = Math.floor((distanceMeters / speedInMeterSec) / 3600);
    let timeMin = Math.floor((distanceMeters / speedInMeterSec) / 60) + timeToRest;
    let timeSec = Math.round((distanceMeters / speedInMeterSec) % 60);

    if (60 <= timeMin) {
        timeHour += Math.floor(timeMin / 60);
        timeMin = timeMin % 60;
    }

    let result = (timeHour < 10 ? "0" : "") + timeHour + ":" + (timeMin < 10 ? "0" : "") + timeMin + ":" +(timeSec < 10 ? "0" : "") + timeSec;

    console.log(result)
}

Walk(4000, 0.60, 5);
Walk(2564, 0.70, 5.5);