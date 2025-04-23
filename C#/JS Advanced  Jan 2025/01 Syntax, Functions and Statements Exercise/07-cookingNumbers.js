// function solve(numb, p1, p2, p3, p4, p5){
//     function calculator(numb, p){
//         let n = Number(numb);
//         switch (p) {
//             case "dice" : for (let index = n; index > 0; index--) {
//                 if (index * index === n) {
//                     n = index;
//                     break;
//                 }
//             }; break;
//             case "chop" : n = n / 2; break;
//             case "spice" : n = n + 1 ; break;
//             case "bake" : n = n * 3 ; break;
//             case "fillet" : n = (n * 0.8).toFixed(1) ; break;
//         }
//         console.log(n);
        
//         return n;
//     }
    
//     let n = Number(numb)
//     n = calculator(n, p1);
//     n = calculator(n, p2);
//     n = calculator(n, p3);
//     n = calculator(n, p4);
//     n = calculator(n, p5);
// }

function solve(numb, p1, p2, p3, p4, p5){
    
    let n = Number(numb)
    switch (p1) {
        case "dice" : for (let index = n; index > 0; index--) {
            if (index * index === n) {
                n = index;
                break;
            }
        }; break;
        case "chop" : n = n / 2; break;
        case "spice" : n = n + 1 ; break;
        case "bake" : n = n * 3 ; break;
        case "fillet" : n = (n * 0.8).toFixed(1) ; break;
    }
    console.log(n);
    switch (p2) {
        case "dice" : for (let index = n; index > 0; index--) {
            if (index * index === n) {
                n = index;
                break;
            }
        }; break;
        case "chop" : n = n / 2; break;
        case "spice" : n = n + 1 ; break;
        case "bake" : n = n * 3 ; break;
        case "fillet" : n = (n * 0.8).toFixed(1) ; break;
    }
    console.log(n);
    switch (p3) {
        case "dice" : for (let index = n; index > 0; index--) {
            if (index * index === n) {
                n = index;
                break;
            }
        }; break;
        case "chop" : n = n / 2; break;
        case "spice" : n = n + 1 ; break;
        case "bake" : n = n * 3 ; break;
        case "fillet" : n = (n * 0.8).toFixed(1) ; break;
    }
    console.log(n);
    switch (p4) {
        case "dice" : for (let index = n; index > 0; index--) {
            if (index * index === n) {
                n = index;
                break;
            }
        }; break;
        case "chop" : n = n / 2; break;
        case "spice" : n = n + 1 ; break;
        case "bake" : n = n * 3 ; break;
        case "fillet" : n = (n * 0.8).toFixed(1) ; break;
    }
    console.log(n);
    switch (p5) {
        case "dice" : for (let index = n; index > 0; index--) {
            if (index * index === n) {
                n = index;
                break;
            }
        }; break;
        case "chop" : n = n / 2; break;
        case "spice" : n = n + 1 ; break;
        case "bake" : n = n * 3 ; break;
        case "fillet" : n = (n * 0.8).toFixed(1) ; break;
    }
    console.log(n);
    
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop')
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet')