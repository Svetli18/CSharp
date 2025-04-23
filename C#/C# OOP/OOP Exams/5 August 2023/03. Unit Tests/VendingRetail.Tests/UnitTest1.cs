namespace VendingRetail.Tests
{
    using NUnit.Framework;
    using System.Xml.Linq;

    public class Tests
    {
        private CoffeeMat coffeeMat;


        [SetUp]
        public void Setup()
        {
            this.coffeeMat = new CoffeeMat(1000, 3);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void IsConstructorWorksCorrectly()
        {
            int expectedWaterCapacity = 1000;
            int actualWaterCapacity = this.coffeeMat.WaterCapacity;

            int expectedButtons = 3;
            int actualButtons = this.coffeeMat.ButtonsCount;

            double expectedIncome = 0;
            double actualIncome = this.coffeeMat.Income;

            Assert.AreEqual(expectedWaterCapacity, actualWaterCapacity);
            Assert.AreEqual(expectedButtons, actualButtons);
            Assert.AreEqual(expectedIncome, actualIncome);
        }

        [Test]
        public void FillWaterTankFromZeroToFull()
        {
            string expectedFillWaterTankInfo = $"Water tank is filled with {1000}ml";
            string actualFillWaterTankInfo = this.coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedFillWaterTankInfo, actualFillWaterTankInfo);

            this.coffeeMat.AddDrink("Coffee", 0.80);
            this.coffeeMat.BuyDrink("Coffee");

            string expectedFillWaterTankInfo2 = $"Water tank is filled with {80}ml";
            string actualFillWaterTankInfo2 = this.coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedFillWaterTankInfo2, actualFillWaterTankInfo2);
        }

        [Test]
        public void FillWaterTankToFull()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 0.80);
            this.coffeeMat.BuyDrink("Coffee");

            string expectedFillWaterTankInfo2 = $"Water tank is filled with {80}ml";
            string actualFillWaterTankInfo2 = this.coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedFillWaterTankInfo2, actualFillWaterTankInfo2);
        }

        [Test]
        public void TryToFillWaterTankIfItsFull()
        {
            this.coffeeMat.FillWaterTank();

            string expectedFillWaterTankInfo2 = "Water tank is already full!";
            string actualFillWaterTankInfo2 = this.coffeeMat.FillWaterTank();

            Assert.AreEqual(expectedFillWaterTankInfo2, actualFillWaterTankInfo2);
        }

        [Test]
        public void AddDrinc()
        {
            this.coffeeMat.FillWaterTank();
            
            bool expectedAddDrinc = true;
            bool actualAddDrinc = this.coffeeMat.AddDrink("Coffee", 0.80);

            Assert.AreEqual(expectedAddDrinc, actualAddDrinc);
        }

        [Test]
        public void AddDrincWhoExist()
        {
            this.coffeeMat.FillWaterTank();
            this.coffeeMat.AddDrink("Coffee", 0.80);

            bool expectedAddDrinc = false;
            bool actualAddDrinc = this.coffeeMat.AddDrink("Coffee", 1.20);

            Assert.AreEqual(expectedAddDrinc, actualAddDrinc);
        }

        [Test]
        public void BuyDrink()
        {
            this.coffeeMat.FillWaterTank();
            string expectedBill = $"Your bill is {0.80:f2}$";
            this.coffeeMat.AddDrink("Coffee", 0.80);
            string actualBill = this.coffeeMat.BuyDrink("Coffee");

            Assert.AreEqual(expectedBill, actualBill);
        }

        [Test]
        public void NotAvailableDrink()
        {
            this.coffeeMat.FillWaterTank();
            string expectedString = $"Tea is not available!";
            this.coffeeMat.AddDrink("Coffee", 0.80);
            string actualString = this.coffeeMat.BuyDrink("Tea");

            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void BuyDrinkButNotEnoughMilliliters()
        {
            CoffeeMat mat = new CoffeeMat(120, 2);

            mat.FillWaterTank();
            mat.AddDrink("Coffee", 0.80);
            mat.BuyDrink("Coffee");

            string expectedStr = "CoffeeMat is out of water!";
            string actualStr = mat.BuyDrink("Coffee");

            Assert.AreEqual(expectedStr, actualStr);
        }

        [Test]
        public void CollectIncome()
        {
            CoffeeMat mat = new CoffeeMat(400, 2);

            mat.FillWaterTank();
            mat.AddDrink("Coffee", 0.80);
            mat.AddDrink("Tea", 0.70);

            mat.BuyDrink("Coffee");
            mat.BuyDrink("Tea");

            double expectedIncome = 1.5;
            double actualIncome = mat.CollectIncome();

            Assert.AreEqual(expectedIncome, actualIncome);
        }
    }
}