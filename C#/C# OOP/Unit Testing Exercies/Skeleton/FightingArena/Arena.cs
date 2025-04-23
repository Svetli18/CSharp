using System;
using System.Collections.Generic;
using System.Linq;

namespace FightingArena
{
    public class Arena
    {
        private readonly List<Warrior> warriors;
        //ok
        public Arena()
        {
            this.warriors = new List<Warrior>();
        }
        //ok
        public IReadOnlyCollection<Warrior> Warriors =>
            this.warriors;
        //ok
        public int Count => this.warriors.Count;
        //ok
        public void Enroll(Warrior warrior)
        {   //ok
            if (this.warriors.Any(w => w.Name == warrior.Name))
            {
                throw new InvalidOperationException("Warrior is already enrolled for the fights!");
            }
            //ok
            this.warriors.Add(warrior);
        }
        //ok
        public void Fight(string attackerName, string defenderName)
        {
            Warrior attacker = this.warriors
                .FirstOrDefault(w => w.Name == attackerName);
            Warrior defender = this.warriors
                .FirstOrDefault(w => w.Name == defenderName);

            if (attacker == null || defender == null)
            {
                string missingName = attackerName;

                if (defender == null)
                {
                    missingName = defenderName;
                }

                throw new InvalidOperationException($"There is no fighter with name {missingName} enrolled for the fights!");
            }

            attacker.Attack(defender);
        }
    }
}
