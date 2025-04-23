function roadRadar(speed, zone){
    let result = "";
    switch (zone) {
        case "motorway": speed <= 130 ? result = `Driving ${speed} km/h in a 130 zone` : result = `The speed is ${speed - 130} km/h faster than the allowed speed of 130 - ${speed - 130 <= 20 ? "speeding" : speed - 130 <= 40 ? "excessive speeding" : "reckless driving"}`; break;
        case "interstate": speed <= 90 ? result = `Driving ${speed} km/h in a 90 zone` : result = `The speed is ${speed - 90} km/h faster than the allowed speed of 90 - ${speed - 90 <= 20 ? "speeding" : speed - 90 <= 40 ? "excessive speeding" : "reckless driving"}`; break;
        case "city": speed <= 50 ? result = `Driving ${speed} km/h in a 50 zone` : result = `The speed is ${speed - 50} km/h faster than the allowed speed of 50 - ${speed - 50 <= 20 ? "speeding" : speed - 50 <= 40 ? "excessive speeding" : "reckless driving"}`; break;
        case "residential": speed <= 20 ? result = `Driving ${speed} km/h in a 20 zone` : result = `The speed is ${speed - 20} km/h faster than the allowed speed of 20 - ${speed - 20 <= 20 ? "speeding" : speed - 20 <= 40 ? "excessive speeding" : "reckless driving"}`; break;
    }

    console.log(result)
}

roadRadar(40, 'city');
roadRadar(21, 'residential');
roadRadar(120, 'interstate');
roadRadar(200, "motorway");