using System;
using System.Collections.Generic;
using System.Linq;

namespace p02.Chat_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> chat = new List<string>();

            while (command != "end")
            {
                List<string> tokens = command.Split().ToList();

                string chatCommand = tokens[0];
                string message = tokens[1];

                if (chatCommand == "Chat")
                {
                    chat.Add(message);
                }
                else if (chatCommand == "Delete")
                {
                    if (chat.Contains(message))
                    {
                        chat.Remove(message);
                    }
                }
                else if (chatCommand == "Edit")
                {
                    string messageToEdit = tokens[1];
                    string editedVersion = tokens[2];
                    int indexOfMessageToEdit = chat.IndexOf(messageToEdit);
                    chat[indexOfMessageToEdit] = editedVersion;
                }
                else if (chatCommand == "Pin")
                {
                    int indexOfGivenMessage = chat.IndexOf(message);
                    chat.RemoveAt(indexOfGivenMessage);
                    chat.Add(message);
                }
                else if (chatCommand == "Spam")
                {
                    for (int i = 1; i < tokens.Count; i++)
                    {
                        chat.Add(tokens[i]);
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var word in chat)
            {
                Console.WriteLine(word);
            }
        }
    }
}
