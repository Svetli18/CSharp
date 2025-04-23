using System;

namespace FightingArena
{
    public class Warrior
    {
        private const int MIN_ATTACK_HP = 30;

        private string name;
        private int damage;
        private int hp;
        //ok
        public Warrior(string name, int damage, int hp)
        {
            this.Name = name;
            this.Damage = damage;
            this.HP = hp;
        }
        //ok
        public string Name
        {   //ok
            get
            {
                return this.name;
            }
            private set
            {   //ok
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty or whitespace!");
                }
                //ok
                this.name = value;
            }
        }
        //ok
        public int Damage
        {   //ok
            get
            {
                return this.damage;
            }
            private set
            {   //ok
                if (value <= 0)
                {
                    throw new ArgumentException("Damage value should be positive!");
                }
                //ok
                this.damage = value;
            }
        }
        //ok
        public int HP
        {   //ok
            get
            {
                return this.hp;
            }
            private set
            {   //ok
                if (value < 0)
                {
                    throw new ArgumentException("HP should not be negative!");
                }
                //ok
                this.hp = value;
            }
        }
        //tessting...
        public void Attack(Warrior warrior)
        {   //ok
            if (this.HP <= MIN_ATTACK_HP)
            {
                throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
            }
            //ok
            if (warrior.HP <= MIN_ATTACK_HP)
            {
                throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
            }
            //ok
            if (this.HP < warrior.Damage)
            {
                throw new InvalidOperationException($"You are trying to attack too strong enemy");
            }
            //ok
            this.HP -= warrior.Damage;
            //ok
            if (this.Damage > warrior.HP)
            {
                warrior.HP = 0;
            }//ok
            else
            {
                warrior.HP -= this.Damage;
            }
        }
    }
}
