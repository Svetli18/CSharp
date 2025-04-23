namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private const int INITIAL_MEMEORY_CAPACITY = 100;

        private Device device;
        private int expectedTestValue;

        [SetUp]
        public void Setup()
        {
            this.device = new Device(INITIAL_MEMEORY_CAPACITY);
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.IsNotNull(this.device);
        }

        [Test]
        public void MemoryCapacity()
        {
            this.expectedTestValue = INITIAL_MEMEORY_CAPACITY;

            Assert.AreEqual(this.expectedTestValue, this.device.MemoryCapacity);
        }

        [Test]
        public void AvailableMemory()
        {
            this.expectedTestValue = INITIAL_MEMEORY_CAPACITY;

            Assert.AreEqual(this.expectedTestValue, this.device.AvailableMemory);
        }

        [Test]
        [TestCase(8)]
        public void TakePhoto(int photoSize)
        {
            Assert.AreEqual(0, this.device.Photos);

            bool expected = this.device.TakePhoto(photoSize);
            this.expectedTestValue = INITIAL_MEMEORY_CAPACITY - photoSize;

            Assert.IsTrue(expected);
            Assert.AreEqual(1, this.device.Photos);
            Assert.AreEqual(this.expectedTestValue, this.device.AvailableMemory);
        }

        [Test]
        [TestCase(108)]
        public void TakePhotoBiggerSizeThanIsAvailable(int photoSize)
        {
            bool expected = this.device.TakePhoto(photoSize);

            Assert.IsFalse(expected);
        }

        [Test]
        public void InstallAppCorrectly()
        {
            Assert.AreEqual(INITIAL_MEMEORY_CAPACITY, this.device.AvailableMemory);
            Assert.AreEqual(0, this.device.Applications.Count);

            string expectedString = $"Svetli is installed successfully. Run application?";
            string actualString = this.device.InstallApp("Svetli", 18);

            this.expectedTestValue = INITIAL_MEMEORY_CAPACITY - 18;


            Assert.AreEqual(expectedTestValue, this.device.AvailableMemory);
            Assert.AreEqual(1, this.device.Applications.Count);
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void ThowExceptionInstallAppWithBiggerAppSize()
        {
            string exceptionMassege = "Not enough available memory to install the app.";

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.device.InstallApp("Svetli", 118);
            }, exceptionMassege);
        }

        [Test]
        public void FormatDevice()
        {
            Assert.AreEqual(0, this.device.Applications.Count);
            Assert.AreEqual(this.device.MemoryCapacity, this.device.AvailableMemory);
            string expectedString = $"Svetli is installed successfully. Run application?";
            string actualString = this.device.InstallApp("Svetli", 18);
            Assert.AreNotEqual(this.device.MemoryCapacity, this.device.AvailableMemory);
            Assert.AreEqual(expectedString, actualString);
            Assert.AreEqual(1, this.device.Applications.Count);

            this.device.FormatDevice();
            Assert.AreEqual(0, this.device.Applications.Count);
            Assert.AreEqual(this.device.MemoryCapacity, this.device.AvailableMemory);
        }

        [Test]
        public void GetDeviceStatus()
        {
            StringBuilder sb1 = new StringBuilder();

            sb1.AppendLine($"Memory Capacity: {this.device.MemoryCapacity} MB, Available Memory: {this.device.AvailableMemory} MB");
            sb1.AppendLine($"Photos Count: {this.device.Photos}");
            sb1.AppendLine("Applications Installed: ");
            string expectedFirstString = sb1.ToString().TrimEnd();

            Assert.AreEqual(expectedFirstString, this.device.GetDeviceStatus());

            this.device.TakePhoto(10);
            this.device.InstallApp("Svetli", 20);
            this.device.InstallApp("Moni", 30);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Memory Capacity: {this.device.MemoryCapacity} MB, Available Memory: {this.device.AvailableMemory} MB");
            sb.AppendLine($"Photos Count: {this.device.Photos}");
            sb.AppendLine("Applications Installed: Svetli, Moni");
            string expectedString = sb.ToString().TrimEnd();

            Assert.AreEqual(expectedString, this.device.GetDeviceStatus());
        }
    }
}