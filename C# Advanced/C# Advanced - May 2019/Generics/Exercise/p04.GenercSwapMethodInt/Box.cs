using System;
using System.Collections.Generic;
using System.Text;

namespace p04.GenercSwapMethodInt
{
    class Box<TItem>
    {
        private List<TItem> box;

        public Box()
        {
            box = new List<TItem>();
        }

        public void Add(TItem item)
        {
            box.Add(item);
        }

        public void SwapIndexes(int firstIndex, int secondIndex)
        {
            TItem tempValue = this.box[firstIndex];

            this.box[firstIndex] = this.box[secondIndex];
            this.box[secondIndex] = tempValue;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var number in box)
            {
                sb.AppendLine($"{number.GetType().FullName}: {number}");
            }

            return sb.ToString();
        }
    }
}