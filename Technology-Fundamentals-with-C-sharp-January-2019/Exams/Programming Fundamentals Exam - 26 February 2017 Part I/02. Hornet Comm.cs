using System;
using System.Collections.Generic;
using System.Linq;

namespace p01.Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> broadCastMessages = new List<string>();
            List<string> privateMessages = new List<string>();
            string input = Console.ReadLine();

            bool onlyDigits = false;
            bool digitsAndOrLetters = false;
            bool anythingButDigits = false;

            while (input != "Hornet is Green")
            {
                bool isPrivate = false;
                bool isBroadcast = false;
                List<string> command = input.Split(new string[] { " <-> " }, StringSplitOptions.None).ToList();
                string firstQuery = command[0];
                string secondQuery = command[1];

                //Check if firstQuery consists only digits
                onlyDigits = firstQuery.All(Char.IsDigit);

                //Check if secondQuery consists digits and/or letters
                digitsAndOrLetters = secondQuery.All(Char.IsLetterOrDigit);

                //Check if firstQuery consists anything but digits

                foreach (char c in firstQuery)
                {
                    if (c >= '0' && c <= '9')
                    {
                        anythingButDigits = false;
                    }
                    else
                    {
                        anythingButDigits = true;
                    }
                }

                if (onlyDigits && digitsAndOrLetters)
                {
                    isPrivate = true;
                }
                else if (anythingButDigits && digitsAndOrLetters)
                {
                    isBroadcast = true;
                }
                else
                {
                    break;
                }

                if (isBroadcast)
                {
                    string newString = "";
                    foreach (char c in secondQuery)
                    {
                        if (char.IsLetter(c))
                        {
                            if (char.IsUpper(c))
                            {
                                newString += char.ToLower(c);
                            }
                            else if (char.IsLower(c))
                            {
                                newString += char.ToUpper(c);
                            }
                        }
                        else
                        {
                            newString += c;
                        }

                    }
                    broadCastMessages.Add($"{newString} -> {firstQuery}");
                }
                else if (isPrivate)
                {
                    string reversed = "";
                    for (int i = firstQuery.Length - 1; i >= 0; i--)
                        reversed += firstQuery[i];

                    privateMessages.Add($"{reversed} -> {secondQuery}");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadCastMessages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var broadcastMessage in broadCastMessages)
                {
                    Console.WriteLine(broadcastMessage);
                }
            }
            Console.WriteLine("Messages:");
            if (privateMessages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var privateMessage in privateMessages)
                {
                    Console.WriteLine(privateMessage);
                }
            }
        }
    }
}
