using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> elements;

        public Box()
        {
            elements = new List<T>();
        }

        public int Count => elements.Count;

        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T indexOfLastElement = this.elements[this.Count - 1];
            elements.RemoveAt(Count - 1);

            return indexOfLastElement;
        }
    }
}