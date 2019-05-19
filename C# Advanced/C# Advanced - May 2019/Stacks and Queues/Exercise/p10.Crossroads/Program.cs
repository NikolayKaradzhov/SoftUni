using System;
using System.Collections.Generic;

namespace p10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int carsPassed = 0;

            bool isHitted = false;
            string hitCar = string.Empty;
            char hittedSymbol = '\0';

            Queue<string> queueOfCars = new Queue<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "green")
                {
                    int currentGreenLightDuration = greenLightDuration;

                    while (currentGreenLightDuration > 0 && queueOfCars.Count > 0)
                    {
                        string carName = queueOfCars.Dequeue();
                        int carLenght = carName.Length;

                        if (currentGreenLightDuration - carLenght >= 0)
                        {
                            currentGreenLightDuration -= carLenght;
                            carsPassed++;
                        }
                        else
                        {
                            currentGreenLightDuration += freeWindowDuration;

                            if (currentGreenLightDuration - carLenght >= 0)
                            {
                                carsPassed++;
                                break; 
                            }
                            else
                            {
                                isHitted = true;
                                hitCar = carName;

                                hittedSymbol = carName[currentGreenLightDuration];
                                break;
                            }
                        }

                    }
                    if (isHitted == true)
                    {
                        break;
                    }
                }
                else
                {
                    queueOfCars.Enqueue(command);
                }

                command = Console.ReadLine();
            }
            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hitCar} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{carsPassed} total cars passed the crossroads.");
            }
        }
    }
}