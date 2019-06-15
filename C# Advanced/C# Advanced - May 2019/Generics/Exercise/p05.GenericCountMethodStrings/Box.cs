using System;
using System.Collections.Generic;
using System.Text;

namespace p05.GenericCountMethodStrings
{
    class Box<TItem>
        where TItem : IComparable<TItem>
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

        public void Compare(TItem item)
        {
            foreach (var currentItem in this.box)
            {
                if (currentItem.CompareTo(item) > 0)
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