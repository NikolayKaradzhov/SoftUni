using System;
using System.Collections.Generic;
using System.Text;

namespace p06.GenericCountMethodDouble
{
    class Box<TItem>
        where TItem : IComparable
    {
        private List<TItem> box;

        public Box()
        {
            box = new List<TItem>();
        }

        public int CountGreater { get; private set; }

        public void Add(TItem item)
        {
            box.Add(item);
        }

        public void Compare(TItem number)
        {
            foreach (var currentNumber in this.box)
            {
                if (currentNumber.CompareTo(number) > 0)
                {
                    CountGreater++;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var text in box)
            {
                sb.AppendLine($"{text.GetType().FullName}: {text}");
            }

            return sb.ToString();
        }
    }
}