using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IAbstractQueue<T> : IEnumerable<T>
    {
        int Count { get; }

        void Enqueue(T item);

        T Dequeue();

        T Peek();

        T[] ToArray();
    }
}
