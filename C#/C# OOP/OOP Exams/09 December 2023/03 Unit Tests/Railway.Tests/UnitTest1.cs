namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using static System.Collections.Specialized.BitVector32;

    public class Tests
    {
        private RailwayStation station;
        private Queue<string> arrivalTrains;
        private Queue<string> departureTrains;

        [SetUp]
        public void Setup()
        {
            this.station = new RailwayStation("London: Platform: 3/4");
            this.arrivalTrains = new Queue<string>();
            this.departureTrains = new Queue<string>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void IsConstructorWorksCorrectly() 
        {
            RailwayStation st = new RailwayStation("Sofia");

            Assert.IsNotNull(st);
        }

        [Test]
        public void ThrowsExceptionIfClassNameGetsNull() 
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation st = new RailwayStation(null);
            });
        }

        [Test]
        public void ThrowsExceptionIfClassNameGetsStringEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation st = new RailwayStation("");
            });
        }

        [Test]
        public void ThrowsExceptionIfClassNameGetsWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RailwayStation st = new RailwayStation("     ");
            });
        }

        [Test]
        [TestCase("Hogwarts Express")]
        public void NewArrivalOnBoard(string name)
        {
            Assert.AreEqual(0, this.station.ArrivalTrains.Count);

            this.station.NewArrivalOnBoard(name);

            Assert.AreEqual(1, this.station.ArrivalTrains.Count);
            
        }

        [Test]
        [TestCase("Sofia Express")]
        public void WrongTrainHasArrived(string name)
        {
            string expectedMassege = $"There are other trains to arrive before {name}.";

            this.station.NewArrivalOnBoard("Hogwarts Express");

            string result = this.station.TrainHasArrived(name);

            Assert.AreEqual(expectedMassege, result);
        }

        [Test]
        [TestCase("Hogwarts Express")]
        public void TrainHasArrived(string name)
        {
            string expectedMassege = $"{name} is on the platform and will leave in 5 minutes.";

            this.station.NewArrivalOnBoard("Hogwarts Express");

            string result = this.station.TrainHasArrived(name);

            Assert.AreEqual(1, this.station.DepartureTrains.Count);
            Assert.AreEqual(expectedMassege, result);
        }

        [Test]
        [TestCase("Sofia Express")]
        public void WrongTrainHasLeft(string name)
        {
            this.station.NewArrivalOnBoard("Hogwarts Express");

            this.station.TrainHasArrived("Hogwarts Express");

            Assert.IsFalse(this.station.TrainHasLeft(name));
        }

        [Test]
        [TestCase("Hogwarts Express")]
        public void TrainHasLeft(string name)
        {
            this.station.NewArrivalOnBoard(name);

            this.station.TrainHasArrived(name);

            Assert.IsTrue(this.station.TrainHasLeft("Hogwarts Express"));
        }
    }
}