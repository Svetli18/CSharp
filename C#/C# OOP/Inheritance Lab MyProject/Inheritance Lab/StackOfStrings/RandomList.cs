namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class RandomList<T> : List<T>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }

        public T GetRandomElement()
        {
            var index = random.Next(0, Count);
            return this[index];
        }

        public void RemoveRandomElement()
        {
            var index = random.Next(0, Count);
            RemoveAt(index);
        }
    }
}

