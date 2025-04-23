namespace Database.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = { 1, 2, 3 };

        [SetUp]
        public void SetUp()
        {
            this.database = new Database(initialData);
        }

        [TestCase(new int[] { })]
        [TestCase(new[] { 1, 2 })]
        public void TestIfConstructorWorksCorrectly(int[] data)
        {
            this.database = new Database(data);

            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ShouldThrowExeptionIfTryAddElementInFullDAta(int[] data)
        {
            this.database = new Database(data);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(17);
            });
        }

        [Test]
        public void TestIfCorrectlyAddElementInData()
        {
            int expectedCount = this.database.Count + 1;

            this.database.Add(4);

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { })]
        public void ShouldThrowExeptionIfTryRemoveElementFromEmptyData(int[] data)
        {
            this.database = new Database(data);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void TestIfCorrectlyRemoveElementFromData()
        {
            int expectedCount = this.database.Count - 1;

            this.database.Remove();

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void FetchSholdReturnCopyOfData(int[] expectedData)
        {
            this.database = new Database(expectedData);

            int[] actualData = this.database.Fetch();

            CollectionAssert.AreEqual(expectedData, actualData);
        }
    }
}
