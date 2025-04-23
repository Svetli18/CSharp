namespace _02.LegionSystem.Models
{
    using System;
    using _02.LegionSystem.Interfaces;

    public class Enemy : IEnemy, IComparable<IEnemy>
    {
        public Enemy(int attackSpeed, int health)
        {
            this.AttackSpeed = attackSpeed;
            this.Health = health;
        }

        public int AttackSpeed { get; set; }

        public int Health { get; set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(IEnemy other)
        {
            return this.Health - other.Health;
        }
    }
}
