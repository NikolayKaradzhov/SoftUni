﻿using System;
using System.Collections.Generic;
using System.Text;

namespace p01.GenericBoxOfString
{
    class Box<TItem>
    {
        private List<TItem> boxCollection;

        public Box()
        {
            this.boxCollection = new List<TItem>();
        }

        public void Add(TItem item)
        {
            boxCollection.Add(item);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in boxCollection)
            {
                sb.AppendLine($"{item.GetType().FullName}: {item}");
            }

            return sb.ToString();
        }
    }       
}