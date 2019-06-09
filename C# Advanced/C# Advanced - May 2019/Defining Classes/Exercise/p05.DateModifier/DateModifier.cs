using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public class DateModifier
    {
        private DateTime firstDate;
        private DateTime secondDate;

        public DateModifier()
        {
            FirstDate = firstDate;
            SecondDate = secondDate;
        }

        public DateModifier(DateTime firstDate, DateTime secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }

        public DateTime FirstDate
        {
            get
            {
                return this.firstDate;
            }
            set
            {
                this.firstDate = value;
            }
        }

        public DateTime SecondDate
        {
            get
            {
                return this.secondDate;
            }
            set
            {
                this.secondDate = value;
            }
        }

        public int ShowDifferenceBetweenTwoDates()
        {
            int difference = Math.Abs((firstDate - secondDate).Days);

            return difference;
        }
    }
}