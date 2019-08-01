using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount(decimal balance)
        {
            this.Balance = 50;
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value cannot be less than 0");
                }

                this.balance = value;
            }
        }

        public void Deposit(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum cannot be less than 0");
            }

            this.Balance += sum;
        }

        public void WithDraw(decimal sum)
        {
            if (sum <= 0)
            {
                throw new ArgumentException("Sum cannot be less than 0");
            }

            this.Balance -= sum;
        }
    }
}