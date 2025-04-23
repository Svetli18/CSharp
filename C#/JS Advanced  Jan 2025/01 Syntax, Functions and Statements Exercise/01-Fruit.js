function result(fruit, grams, price){
    let productName = fruit;
    let gramsOfProduct = Number(grams);
    let priceOfProduct = Number(price);

    let totalPrice = ((gramsOfProduct * priceOfProduct) / 1000).toFixed(2);

    console.log(`I need $${totalPrice} to buy ${(gramsOfProduct / 1000).toFixed(2)} kilograms ${productName}.`)
}

result('orange', 2500, 1.80);