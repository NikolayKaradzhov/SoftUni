using System;
using System.Collections.Generic;

namespace p09.Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string command = Console.ReadLine();

                if (command == "4")
                {
                    text = stack.Pop();
                }
                else
                {
                    string[] tokens = command.Split(" ");

                    if (tokens[0] == "1")
                    {
                        stack.Push(text);
                        text += tokens[1];
                    }
                    else if (tokens[0] == "2")
                    {
                        int index = int.Parse(tokens[1]);
                        stack.Push(text);
                        text = text.Substring(0, text.Length - index);
                    }
                    else if (tokens[0] == "3")
                    {
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(text[index - 1]);
                    }
                }
            }
        }
    }
}
