namespace FightingArena.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior attacker;
        private Warrior deffender;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
            this.warrior = new Warrior("Svetli", 10, 100);
            this.attacker = new Warrior("Attacker", 40, 100);
            this.deffender = new Warrior("Deffender", 20, 100);
        }

        [Test]
        public void TestArenaConstructor() 
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void EnrollWarriorInData() 
        {
            this.arena.Enroll(this.warrior);

            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }

        [Test]
        public void GetCountFromData()
        {
            Assert.IsTrue(this.arena.Count == 0);

            this.arena.Enroll(this.warrior);

            Assert.IsTrue(this.arena.Count == 1);
        }

        [Test]
        public void ThrowsExeptionIfEnrollWarriorInDataWhoAlreadyExistWithTheSameName()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(new Warrior("Svetli", 50, 50));
            });
        }

        [Test]
        public void ThrowsExeptionIfEnrollWarriorWhoAlreadyExistInData()
        {
            this.arena.Enroll(this.warrior);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.warrior);
            });
        }

        [Test]
        public void TestFightingWithMissingAttaker()
        {
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.deffender);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }

        [Test]
        public void TestFightingWithMissingDeffender()
        {
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.attacker);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight(this.attacker.Name, this.deffender.Name);
            });
        }

        [Test]
        public void TestFightingWorksCorrectly()
        {
            this.arena.Enroll(this.warrior);
            this.arena.Enroll(this.attacker);
            this.arena.Enroll(this.deffender);

            int expectedAttakerHP = this.attacker.HP - this.deffender.Damage;
            int expectedDeffenderHP = this.deffender.HP - this.attacker.Damage;

            this.arena.Fight(this.attacker.Name, this.deffender.Name);

            Assert.AreEqual(expectedAttakerHP, this.attacker.HP);
            Assert.AreEqual(expectedDeffenderHP, this.deffender.HP);
        }
    }
}
