namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private string make = "BMW";

        private string model = "M3";

        private double fuelConsumption = 10;

        private double fuelAmount = 0;

        private double fuelCapacity = 50;

        private Car car;

        [SetUp]
        public void SetUp()
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void ThrowExeptionIfMakeIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = 
                new Car(null, this.model, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void ThrowExeptionIfMakeIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = 
                new Car(string.Empty, this.model, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void TestConstructorWorksCorrectlyGetMake()
        {
            string expectedMake = this.make;

            string actualMake = this.car.Make;

            Assert.AreEqual(expectedMake, actualMake);
        }

        [Test]
        public void ThrowExeptionIfModelIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = 
                new Car(this.make, null, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void ThrowExeptionIfModelIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = 
                new Car(this.make, string.Empty, this.fuelConsumption, this.fuelCapacity);
            });
        }

        [Test]
        public void TestConstructorWorksCorrectlyGetModel()
        {
            string expectedModel = this.model;

            string actualModel = this.car.Model;

            Assert.AreEqual(expectedModel, actualModel);
        }

        [Test]
        public void ThrowExeptionIfFuelConsumptionIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(this.make, this.model, 0, this.fuelCapacity);
            });
        }

        [Test]
        public void TestConstructorWorksCorrectlyGetFuelConsumption()
        {
            double expectedFuelConsumption = this.fuelConsumption;

            double actualFuelConsumption = this.car.FuelConsumption;

            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption);
        }

        [Test]
        public void ThrowExeptionIfFuelCapacityIsZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car = new Car(this.make, this.model, this.fuelConsumption, 0);
            });
        }

        [Test]
        public void TestConstructorWorksCorrectlyGetFuelCapacity()
        {
            double expectedFuelCapacity = this.fuelCapacity;

            double actualFuelCapacity = this.car.FuelCapacity;

            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity);
        }

        [Test]
        public void ThrowsExeptionIfTryToRefuilWithNegativeAmount()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(0);
            });
        }

        [Test]
        public void TestRefuilMethodWorksCorrectly()
        {
            double expectedRefuelAmount = 20;

            this.car.Refuel(expectedRefuelAmount);

            double actualRefuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedRefuelAmount, actualRefuelAmount);
        }

        [Test]
        public void TestRefuilMethodWorksCorrectlyIfAmountIsBiggerThanCapacity()
        {
            double expectedRefuelAmount = this.fuelCapacity;

            this.car.Refuel(60);

            double actualRefuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedRefuelAmount, actualRefuelAmount);
        }

        [Test]
        public void TestIfGiveFuelAmountCorrectly()
        {
            double expectedFuelAmount = 10;

            this.car.Refuel(expectedFuelAmount);

            if (this.car.FuelCapacity < expectedFuelAmount)
            {
                expectedFuelAmount = this.car.FuelCapacity;
            }

            double actualFuelAmoun = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmoun);
        }

        [Test]
        public void ThrowsExeptionIfYouFuealAmountForMethodDrive()
        {
            this.car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(200);
            });
        }

        [Test]
        public void TestIfMethosDriveWorksCorrectly()
        {
            this.car.Refuel(50);

            this.car.Drive(100);

            double expectedFuelAmount = 40;

            double actualFuelAmount = this.car.FuelAmount;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount);
        }
    }
}