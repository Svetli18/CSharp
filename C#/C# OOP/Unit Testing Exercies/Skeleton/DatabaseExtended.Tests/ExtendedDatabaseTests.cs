namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        private Person[] initialData = new Person[]
        {
            new Person(1, "Moni"),
            new Person(2, "Svetli")
        };

        private Person[] fullData = new Person[]
            {
                new Person(1, "Moni"),
                new Person(2, "Svetli"),
                new Person(3, "Zoicheto"),
                new Person(4, "Velizar"),
                new Person(5, "Cvetomir"),
                new Person(6, "Iskrenna"),
                new Person(7, "Iliqn"),
                new Person(8, "Viki"),
                new Person(9, "Petq"),
                new Person(10, "Niki"),
                new Person(11, "Svetleto"),
                new Person(12, "Mitko"),
                new Person(13, "Tanq"),
                new Person(14, "Ivan"),
                new Person(15, "Elviza"),
                new Person(16, "Marti")
            };

        private Person[] biggerThanFullData = new Person[]
            {
                new Person(1, "Moni"),
                new Person(2, "Svetli"),
                new Person(3, "Zoicheto"),
                new Person(4, "Velizar"),
                new Person(5, "Cvetomir"),
                new Person(6, "Iskrenna"),
                new Person(7, "Iliqn"),
                new Person(8, "Viki"),
                new Person(9, "Petq"),
                new Person(10, "Niki"),
                new Person(11, "Svetleto"),
                new Person(12, "Mitko"),
                new Person(13, "Tanq"),
                new Person(14, "Ivan"),
                new Person(15, "Elviza"),
                new Person(16, "Marti"),
                new Person(17, "Gogo")
            };

        [SetUp]
        public void SetUp()
        {
            this.database = new Database(this.initialData);
        }

        [Test]
        public void TestDatabaseConstructorWorksCorrectly()
        {
            int expectedPeopleCount = 2;

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedPeopleCount, actualCount);
        }

        [Test]
        public void ThrowsExeptionIfTryToPutBiggerDataThanCapacity()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.database = new Database(this.biggerThanFullData);
            });
        }

        [Test]
        public void ThrowsExeptionAddPersonInFullData()
        {
            this.database = new Database(this.fullData);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(17, "Gogo"));
            });
        }

        [Test]
        public void ThrowsExeptionAddPersonWithIdAlreadyExists()
        {
            this.database = new Database(this.initialData);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(1, "Zoicheto"));
            });
        }

        [Test]
        public void ThrowsExeptionAddPersonWithNameAlreadyExists()
        {
            this.database = new Database(this.initialData);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Add(new Person(3, "Moni"));
            });
        }

        [Test]
        public void AddPersonWorksCorrectly()
        {
            this.database.Add(new Person(3, "Zoicheto"));

            int expectedDataCount = 3;

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedDataCount, actualCount);
        }

        [Test]
        public void ThrowsExeptionRemovePersonFromEmptyData()
        {
            this.database.Remove();
            this.database.Remove();

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.Remove();
            });
        }

        [Test]
        public void RemovePersonWorksCorrectly()
        {
            this.database.Remove();

            int expectedDataCount = 1;

            int actualCount = this.database.Count;

            Assert.AreEqual(expectedDataCount, actualCount);
        }

        [Test]
        public void ThrowsExeptionFindByUsernameWithNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(null);
            });
        }

        [Test]
        public void ThrowsExeptionFindByUsernameWithEmptyString()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.database.FindByUsername(string.Empty);
            });
        }

        [Test]
        public void ThrowsExeptionFindByUsername()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindByUsername("Velizar");
            });
        }

        [Test]
        public void FindByUsernameWorksCorrectly()
        {
            string expectedName = "Moni";

            Person person = this.database.FindByUsername(expectedName);

            string actualName = person.UserName;

            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        public void ThrowsExeptionFindByNegativeId()
        {
            long negativeId = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                this.database.FindById(negativeId);
            });
        }

        [Test]
        public void ThrowsExeptionFindByNonExistPersonAndId()
        {
            long nonExistId = 6;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database.FindById(nonExistId);
            });
        }

        [Test]
        public void FindByIdWorksCorrectly()
        {
            long expectedId = 1;

            Person person = this.database.FindById(expectedId);

            long actualId = person.Id;

            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        public void PersonConstructorWorksCorrectly()
        {
            long expectedId = 3;
            string expextedName = "Velizar";

            Person person = new Person(expectedId, expextedName);

            long actualId = person.Id;
            string actualName = person.UserName;

            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expextedName, actualName);
        }
    }
}