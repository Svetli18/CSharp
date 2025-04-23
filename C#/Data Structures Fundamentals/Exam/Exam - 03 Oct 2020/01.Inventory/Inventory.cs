namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Inventory : IHolder
    {
        private IList<IWeapon> weapons;
        private IDictionary<int, List<IWeapon>> weaponsByCategory;

        public Inventory()
        {
            weapons = new List<IWeapon>();
            this.weaponsByCategory = new Dictionary<int, List<IWeapon>>();
        }
        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon)
        {
            if (!this.weaponsByCategory.ContainsKey((int)weapon.Category))
            {
                this.weaponsByCategory[(int)weapon.Category] = new List<IWeapon>();
            }

            this.weapons.Add(weapon);
            this.weaponsByCategory[(int)weapon.Category].Add(weapon);
        }

        public IWeapon GetById(int id)
        {
            for (int i = 0; i < this.weapons.Count; i++)
            {
                if (this.weapons[i].Id.Equals(id))
                {
                    return this.weapons[i];
                }
            }

            return null;
        }

        public bool Contains(IWeapon weapon)
        {
            foreach (var currWeapon in this.weaponsByCategory[(int)weapon.Category])
            {
                if (currWeapon.Equals(weapon))
                {
                    return true;
                }
            }

            return false;
        }
        
        public int Refill(IWeapon weapon, int ammunition)
        {
            int index = this.weapons.IndexOf(weapon);

            if (index < 0)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            IWeapon thwWeapon = this.weapons[index];

            if (thwWeapon.MaxCapacity < thwWeapon.Ammunition + ammunition)
            {
                thwWeapon.Ammunition = thwWeapon.MaxCapacity;
            }
            else
            {
                thwWeapon.Ammunition += ammunition;
            }

            return thwWeapon.Ammunition;
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            int index = this.weapons.IndexOf(weapon);

            if (index < 0)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
            
            IWeapon fireWepon = this.weapons[index];

            if (fireWepon.Ammunition < ammunition)
            {
                return false;
            }

            fireWepon.Ammunition -= ammunition;

            return true;
        }

        public IWeapon RemoveById(int id)
        {
            for (int i = 0; i < this.weapons.Count; i++)
            {
                if (this.weapons[i].Id.Equals(id))
                {
                    IWeapon weapon = this.weapons[i];
                    this.weapons.RemoveAt(i);
                    return weapon;
                }
            }

            throw new InvalidOperationException("Weapon does not exist in inventory!");
        }

        public void Clear()
        {
            this.weapons.Clear();
        }

        public List<IWeapon> RetrieveAll()
        {
            return new List<IWeapon>(this.weapons);
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            int indexOfFirst = this.weapons.IndexOf(firstWeapon);
            int indexOfSecond = this.weapons.IndexOf(secondWeapon);

            if (indexOfFirst == -1 || indexOfSecond == -1)
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            IWeapon weaponOne = this.weapons[indexOfFirst];
            IWeapon weaponTwo = this.weapons[indexOfSecond];

            if (weaponOne.Category.Equals(weaponTwo.Category))
            {
                IWeapon temp = this.weapons[indexOfFirst];
                this.weapons[indexOfFirst] = this.weapons[indexOfSecond];
                this.weapons[indexOfSecond] = temp;
            }
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> result = new List<IWeapon>();

            for (int i = 0; i < this.weapons.Count; i++)
            {
                if ((int)lower <= (int)this.weapons[i].Category && (int)this.weapons[i].Category <= (int)upper)
                {
                    result.Add(weapons[i]);
                }
            }

            return result;
        }
        public void EmptyArsenal(Category category)
        {
            foreach (var weapon in this.weaponsByCategory[(int)category])
            {
                weapon.Ammunition = 0;
            }
        }

        public int RemoveHeavy()
        {
            int cnt = 0;

            for (int i = 0; i < this.weapons.Count; i++)
            {
                if ((int)this.weapons[i].Category == 2)
                {
                    this.weapons.RemoveAt(i);
                    cnt++;
                    i--;
                }
            }

            return cnt;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.weapons.Count; i++)
            {
                yield return this.weapons[i];
            }
        }
    }
}
