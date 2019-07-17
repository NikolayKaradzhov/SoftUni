namespace Telephony
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string numbersInput = Console.ReadLine();
            string sitesInput = Console.ReadLine();

            var phoneNumbers = numbersInput
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var webAddress = sitesInput
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            foreach (var phoneNumber in phoneNumbers)
            {
                try
                {
                    SmartPhone smartPhone = new SmartPhone { PhoneNumber = phoneNumber };
                    Console.WriteLine(smartPhone.CallNumbers());
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message.Message);
                }
            }

            foreach (var address in webAddress)
            {
                try
                {
                    SmartPhone smartPhone = new SmartPhone { WebAddress = address };
                    Console.WriteLine(smartPhone.BrowseSites());
                }
                catch (ArgumentException message)
                {
                    Console.WriteLine(message.Message);
                }
            }
        }
    }
}