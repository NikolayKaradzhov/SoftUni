using System;
using System.Collections.Generic;
using System.Text;

namespace p02.GenericBoxOfInt
{
    class Box<TItem>
    {
        private List<TItem> boxOfInt;

        public Box()
        {
            boxOfInt = new List<TItem>();   
        }

        public void Add(TItem item)
        {
            boxOfInt.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var number in boxOfInt)
            {
                sb.AppendLine($"{number.GetType().FullName}: {number}");
            }

            return sb.ToString();
        }
    }
}