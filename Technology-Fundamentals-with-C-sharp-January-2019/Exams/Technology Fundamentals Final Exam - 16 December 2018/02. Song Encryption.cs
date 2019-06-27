using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string pattern = @"^(?<artist>[A-Z][a-z ']*)(?<dots>:)(?<song>[A-Z ]*)$";

            int getCurrentSymbol = 0;
            char currentChar = ' ';

            Regex order = new Regex(pattern);

            StringBuilder sb = new StringBuilder();

            while (command != "end")
            {
                MatchCollection matches = order.Matches(command);
                bool isValid = false;

                foreach (Match match in matches)
                {
                    isValid = true;
                    string artist = match.Groups["artist"].Value;
                    string songName = match.Groups["song"].Value;

                    int encryptionKeyLength = artist.Length;

                    //EncryptArtist
                    foreach (var character in artist)
                    {
                        if (character == ' ' || character == '\'')
                        {
                            sb.Append(character);
                        }
                        else if (Char.IsUpper(character))
                        {
                            if (character + encryptionKeyLength > 90)
                            {
                                getCurrentSymbol = Math.Abs(90 - (character + encryptionKeyLength));
                                currentChar = (char)(64 + getCurrentSymbol);
                                sb.Append(currentChar);
                            }
                            else
                            {
                                sb.Append((char)(character + encryptionKeyLength));
                            }
                        }
                        else if (Char.IsLower(character))
                        {
                            if (character + encryptionKeyLength > 122)
                            {
                                getCurrentSymbol = Math.Abs(122 - (character + encryptionKeyLength));
                                currentChar = (char)(96 + getCurrentSymbol);
                                sb.Append(currentChar);
                            }
                            else
                            {
                                sb.Append((char)(character + encryptionKeyLength));
                            }
                        }
                    }
                    sb.Append("@");
                    //EncryptSong
                    foreach (var character in songName)
                    {
                        if (character == ' ' || character == '\'')
                        {
                            sb.Append(character);
                        }
                        else if (character + encryptionKeyLength > 90)
                        {
                            getCurrentSymbol = Math.Abs(90 - (character + encryptionKeyLength));
                            currentChar = (char)(64 + getCurrentSymbol);
                            sb.Append(currentChar);
                        }
                        else
                        {
                            sb.Append((char)(character + encryptionKeyLength));
                        }
                    }
                } 
                if (isValid)
                {
                    Console.WriteLine($"Successful encryption: {sb}");
                    sb.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }
    }
}
