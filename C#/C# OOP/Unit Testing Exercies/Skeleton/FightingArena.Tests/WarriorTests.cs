namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class WarriorTests
    {
        private string name = "Svetli";

        private int damage = 10;

        private int hp = 100;

        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            this.warrior = new Warrior(name, damage, hp);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ThrowsExeptionIfNameIsNullOrStringEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => 
            {
                this.warrior = new Warrior(name, damage, hp);
            });
        }

        [Test]
        public void TestIfWariorConstructorWorksCorrectlyForName()
        {
            Assert.AreEqual(name, this.warrior.Name);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowsExeptionIfDamageIsZeroOrNegative(int dmg)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.warrior = new Warrior(this.name, dmg, this.hp);
            });
        }

        [Test]
        public void TestIfWariorConstructorWorksCorrectlyForDamage()
        {
            Assert.AreEqual(this.damage, this.warrior.Damage);
        }

        [TestCase(-1)]
        public void ThrowsExeptionIfHPIsNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.warrior = new Warrior(this.name, this.damage, hp);
            });
        }

        [Test]
        public void TestIfWariorConstructorWorksCorrectlyForHP()
        {
            Assert.AreEqual(this.hp, this.warrior.HP);
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttacingEnemyWithLowHPShouldThrowExeption(int attakerHP)
        {
            Warrior attacker = new Warrior(this.name, this.damage, attakerHP);
            Warrior defender = new Warrior("Deffender", this.damage, this.hp);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(20)]
        [TestCase(30)]
        public void AttacingEnemyWhoHaveLowHPShouldThrowExeption(int defenderHP)
        {
            Warrior attacker = new Warrior(this.name, this.damage, this.hp);
            Warrior defender = new Warrior("Deffender", 15, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void AttakingEnemyWhoHaveBiggerDamaheThanMyHP()
        {
            Warrior attaker = new Warrior(this.name, this.damage, 35);
            Warrior deffender = new Warrior("Deffender", 40, 100);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attaker.Attack(deffender);
            });
        }

        [Test]
        public void ShouldAttackCorrectly()
        {
            Warrior attaker = new Warrior(this.name, this.damage, this.hp);
            Warrior deffender = new Warrior("Deffender", 40, 100);

            int expectedAttakerHP = attaker.HP - deffender.Damage;
            int expectedDeffenderHP = deffender.HP - attaker.Damage;

            attaker.Attack(deffender);

            Assert.AreEqual(expectedAttakerHP, attaker.HP);
            Assert.AreEqual(expectedDeffenderHP, deffender.HP);
        }

        [Test]
        public void ShouldAttackCorrectlyAndEnemyDies()
        {
            Warrior attaker = new Warrior(this.name, 50, 100);
            Warrior deffender = new Warrior("Deffender", 10, 40);

            int expectedDeffenderHP = 0;

            attaker.Attack(deffender);

            Assert.AreEqual(expectedDeffenderHP, deffender.HP);
        }

        [Test]
        public void ShouldAttackCorrectlyAndEnemyMakeDamageOnMe()
        {
            Warrior attaker = new Warrior(this.name, 50, 100);
            Warrior deffender = new Warrior("Deffender", 10, 100);

            int expectedAttackerHP = attaker.HP - deffender.Damage;

            attaker.Attack(deffender);

            Assert.AreEqual(expectedAttackerHP, attaker.HP);
        }
    }
}