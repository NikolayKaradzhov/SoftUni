using System;
using System.Collections.Generic;
using System.Text;

namespace p07.Tuple
{
    public class Tuple<TItem1, TItem2>
    {
        public Tuple(TItem1 item1, TItem2 item2)
       {
            Item1 = item1;
            Item2 = item2;
        }

        public TItem1 Item1 { get; }
        public TItem2 Item2 { get; }

        public string Print()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}