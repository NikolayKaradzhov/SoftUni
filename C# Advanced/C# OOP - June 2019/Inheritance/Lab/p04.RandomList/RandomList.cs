namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();

            int index = rnd.Next(0, this.Count);
            string randomString = this[index];
            this.Remove(randomString);
            return randomString;
        }
    }
}