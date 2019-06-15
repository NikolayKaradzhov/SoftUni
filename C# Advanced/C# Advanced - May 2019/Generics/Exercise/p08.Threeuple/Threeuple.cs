using System;
using System.Collections.Generic;
using System.Text;

namespace p08.Threeuple
{
    class Threeuple<TItem1, TItem2, TItem3>
    {
        public Threeuple(TItem1 item1, TItem2 item2, TItem3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }

        public TItem1 Item1 { get; }
        public TItem2 Item2 { get; }
        public TItem3 Item3 { get; }

        public string Print()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}