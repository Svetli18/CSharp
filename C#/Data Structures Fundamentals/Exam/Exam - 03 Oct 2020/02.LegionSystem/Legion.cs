namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using _02.LegionSystem.Interfaces;
    using _02.LegionSystem.Models;

    public class Legion : IArmy
    {
        private int minAttack;
        private int maxAttack;
        private SortedDictionary<int, IEnemy> _enemys;

        public Legion()
        {
            this._enemys = new SortedDictionary<int, IEnemy>();
            this.minAttack = int.MaxValue;
            this.maxAttack = int.MinValue;
        }

        public int Size => this._enemys.Count;

        public void Create(IEnemy enemy)
        {
            if (!this._enemys.ContainsKey(enemy.AttackSpeed))
            {
                this._enemys[enemy.AttackSpeed] = enemy;

                if (enemy.AttackSpeed < this.minAttack)
                {
                    this.minAttack = enemy.AttackSpeed;
                }

                if (this.maxAttack < enemy.AttackSpeed)
                {
                    this.maxAttack = enemy.AttackSpeed;
                }
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            IEnemy enemy = null;

            if (this._enemys.ContainsKey(speed))
            {
                enemy = this._enemys[speed];
            }

            return enemy;
        }

        public bool Contains(IEnemy enemy)
        {
            return this._enemys.ContainsKey(enemy.AttackSpeed);
        }

        public IEnemy GetFastest()
        {
            if (this._enemys.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            return this._enemys[this.maxAttack];
        }

        public IEnemy GetSlowest()
        {
            if (this._enemys.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            return this._enemys[this.minAttack];
        }

        public void ShootFastest()
        {
            if (this._enemys.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            this._enemys.Remove(this.maxAttack);
        }

        public void ShootSlowest()
        {
            if (this._enemys.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }

            this._enemys.Remove(this.minAttack);
        }

        public IEnemy[] GetOrderedByHealth()
        {
            PriorityQueue<Enemy> queue = new PriorityQueue<Enemy>();


            foreach (var enemy in _enemys.Values)
            {
                queue.Add(enemy as Enemy);
            }

            IEnemy[] result = new IEnemy[queue.Size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = queue.Dequeue();
            }

            return result;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            List<IEnemy> result = new List<IEnemy>();

            foreach (var enemy in this._enemys.Values)
            {
                if (speed < enemy.AttackSpeed)
                {
                    result.Add(enemy);
                }
            }

            return result;
        }

        public List<IEnemy> GetSlower(int speed)
        {
            List<IEnemy> result = new List<IEnemy>();

            foreach (var enemy in this._enemys.Values)
            {
                if (enemy.AttackSpeed < speed)
                {
                    result.Add(enemy);
                }
            }

            return result;
        }
    }
}
