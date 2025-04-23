namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice myTV;
        private string brand = "Sony";
        private double price = 2400;
        private int screenWidth = 48;
        private int screenHeigth = 27;

        [SetUp]
        public void Setup()
        {
            myTV = new TelevisionDevice(brand, price, screenWidth, screenHeigth);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestConstructorWorksCorrectly()
        {
            string actualBrand = myTV.Brand;
            double actualPrice = myTV.Price;
            int actualScreenWidth = myTV.ScreenWidth;
            int actualScreenHeigth = myTV.ScreenHeigth;

            Assert.IsNotNull(myTV);
            Assert.AreEqual(myTV.Brand, actualBrand);
            Assert.AreEqual(myTV.Price, actualPrice);
            Assert.AreEqual(myTV.ScreenWidth, actualScreenWidth);
            Assert.AreEqual(myTV.ScreenHeigth, actualScreenHeigth);
        }

        [Test]
        [TestCase(22)]
        public void TestIfChangeChannelWorksCorrectly(int newChannel)
        {
            int expectedStartChannel = 0;

            Assert.AreEqual(expectedStartChannel, myTV.CurrentChannel);

            int expectedNewChannel = newChannel;
            myTV.ChangeChannel(expectedNewChannel);

            Assert.AreEqual(expectedNewChannel, myTV.CurrentChannel);
        }

        [Test]
        [TestCase(-8)]
        public void ThrowExeptionIfChangeChannelDontWorksCorrectly(int newChannel)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                myTV.ChangeChannel(newChannel);
            });
        }

        [Test]
        [TestCase(5)]
        public void TestIfChangeVolumeWorksCorrectly(int newVolume)
        {
            int expectedStartVolume = 13;

            Assert.AreEqual(expectedStartVolume, myTV.Volume);

            int expectedNewVolumeUp = myTV.Volume + newVolume;
            myTV.VolumeChange("UP", newVolume);

            Assert.AreEqual(expectedNewVolumeUp, myTV.Volume);

            int expectedNewVolumeDown = myTV.Volume - newVolume;
            myTV.VolumeChange("DOWN", newVolume);

            Assert.AreEqual(expectedNewVolumeDown, myTV.Volume);
        }

        [Test]
        [TestCase(108)]
        public void TestIfChangeVolumeWorksCorrectlyInEdgeCase(int newVolume)
        {
            int expectedMinVolume = 0;
            myTV.VolumeChange("DOWN", newVolume);

            Assert.AreEqual(expectedMinVolume, myTV.Volume);

            int expectedMaxVolume = 100;
            myTV.VolumeChange("UP", newVolume);

            Assert.AreEqual(expectedMaxVolume, myTV.Volume);
        }

        [Test]
        public void TesIfTVMuteWorksCorrectly()
        {
            Assert.IsFalse(myTV.IsMuted);

            myTV.MuteDevice();

            Assert.IsTrue(myTV.IsMuted);
        }

        [Test]
        public void TestIfSwitchOnWorksCorrectly()
        {
            string sound = myTV.IsMuted ? "Off" : "On";

            string expectedTVInfo = $"Cahnnel {0} - Volume {13} - Sound {sound}";

            string actualTVInfo = myTV.SwitchOn();

            Assert.AreEqual(expectedTVInfo, actualTVInfo);

            bool test = myTV.MuteDevice();
            sound = myTV.IsMuted ? "Off" : "On";

            expectedTVInfo = $"Cahnnel {0} - Volume {13} - Sound {sound}";
            actualTVInfo = myTV.SwitchOn();

            Assert.AreEqual(expectedTVInfo, actualTVInfo);
        }

        [Test] 
        public void TestIfToStrigWorksCorrectly()
        {
            string expectedToString = $"TV Device: {brand}, Screen Resolution: {screenWidth}x{screenHeigth}, Price {price}$";

            Assert.AreEqual(expectedToString, myTV.ToString());
        }
    }
}