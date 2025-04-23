function solve(input, firstName, secondName){
    const firstIndex = input.indexOf(firstName);
    const secondIndex = input.indexOf(secondName);

    const result = input.slice(firstIndex, secondIndex + 1)
    return result;
}

//['Key Lime Pie', 'Cherry Pie', 'Lemon Meringue Pie']
const array1 = ['Pumpkin Pie', 'Key Lime Pie', 'Cherry Pie', 'Lemon Meringue Pie', 'Sugar Cream Pie'];
const array1Name1 = 'Key Lime Pie';
const array1Name2 = 'Lemon Meringue Pie';

//['Pot Pie', 'Steak and Cheese Pie', 'Butter Chicken Pie', 'Smoked Fish Pie']   
const array2 = ['Apple Crisp', 'Mississippi Mud Pie', 'Pot Pie', 'Steak and Cheese Pie', 'Butter Chicken Pie', 'Smoked Fish Pie'];
const array2Name1 = 'Pot Pie';
const array2Name2 = 'Smoked Fish Pie';
   
solve(array2, array2Name1, array2Name2);   