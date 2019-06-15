using System;
using System.Collections.Generic;
using System.Text;

namespace p03.GenericSwapMethodStrings
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

            foreach (var text in box)
            {
                sb.AppendLine($"{text.GetType().FullName}: {text}");
            }

            return sb.ToString();
        }
    }
}