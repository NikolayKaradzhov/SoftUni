namespace Telephony
{
    using System;

    public class SmartPhone : ICaller, IBrowser
    {
        private string phoneNumber;
        private string webAddress;

        public string PhoneNumber
        {
            get => this.phoneNumber;

            set
            {
                if (!this.CheckNumber(value))
                {
                    throw new ArgumentException("Invalid number!");
                }

                this.phoneNumber = value;
            }
        }

        public string WebAddress
        {
            get => this.webAddress;

            set
            {
                if (!this.CheckWebSite(value))
                {
                    throw new ArgumentException("Invalid URL!");
                }

                this.webAddress = value;
            }
        }

        public bool CheckWebSite(string value)
        {
            foreach (var letter in value)
            {
                if (char.IsDigit(letter))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckNumber(string value)
        {
            foreach (var digit in value)
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }

        public string CallNumbers()
        {
            return $"Calling... {this.PhoneNumber}";
        }

        public string BrowseSites()
        {
            return $"Browsing: {this.WebAddress}!";
        }
    }
}