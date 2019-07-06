using System;
using System.Collections.Generic;
using System.Linq;

namespace p09.SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> scheduleOfLessonsAndExercise = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();

            while (command != "course start")
            {
                List<string> operation = command.Split(":").ToList();

                if (operation[0] == "Add")
                {
                    if (!scheduleOfLessonsAndExercise.Contains(operation[1]))
                    {
                        scheduleOfLessonsAndExercise.Add(operation[1]);
                    }
                }
                else if (operation[0] == "Insert")
                {
                    if (!scheduleOfLessonsAndExercise.Contains(operation[1]))
                    {
                        int givenIndex = int.Parse(operation[2]);
                        scheduleOfLessonsAndExercise.Insert(givenIndex, operation[1]);
                    }
                }
                else if (operation[0] == "Remove")
                {
                    if (scheduleOfLessonsAndExercise.Contains(operation[1]) &&
                        scheduleOfLessonsAndExercise.Contains(operation[1] + "-Exercise"))
                    {
                        scheduleOfLessonsAndExercise.Remove(operation[1]);
                        scheduleOfLessonsAndExercise.Remove(operation[1] + "-Exercise");
                    }
                    else
                    {
                        scheduleOfLessonsAndExercise.Remove(operation[1]);
                    }
                }
                else if (operation[0] == "Swap")
                {
                    int firstElemIndex = -1;
                    int secondElemIndex = -1;
                    string firstElemToSwap = operation[1];
                    string firstExerciseToSwap = operation[1] + "-Exercise";
                    string secondElemToSwap = operation[2];
                    string secondExerciseToSwap = operation[2] + "-Exercise";
                    string tempLesson = firstElemToSwap;
                    string tempExercise = firstExerciseToSwap;

                    for (int i = 0; i < scheduleOfLessonsAndExercise.Count; i++)
                    {
                        if (scheduleOfLessonsAndExercise[i] == operation[1])
                        {
                            firstElemIndex = i;
                            break;
                        }
                    }
                    for (int j = 0; j < scheduleOfLessonsAndExercise.Count; j++)
                    {
                        if (scheduleOfLessonsAndExercise[j] == operation[2])
                        {
                            secondElemIndex = j;
                            break;
                        }
                    }

                    if ((scheduleOfLessonsAndExercise.Contains(operation[1]) &&
                        scheduleOfLessonsAndExercise.Contains(operation[1] + "-Exercise")) &&
                        (scheduleOfLessonsAndExercise.Contains(operation[2]) &&
                        scheduleOfLessonsAndExercise.Contains(operation[2] + "-Exercise")))
                    {
                        scheduleOfLessonsAndExercise.RemoveAt(firstElemIndex);
                        scheduleOfLessonsAndExercise.RemoveAt(firstElemIndex + 1);
                        scheduleOfLessonsAndExercise.Insert(firstElemIndex, secondElemToSwap);
                        scheduleOfLessonsAndExercise.Insert(firstElemIndex + 1, secondExerciseToSwap);
                        scheduleOfLessonsAndExercise.RemoveAt(secondElemIndex);
                        scheduleOfLessonsAndExercise.RemoveAt(secondElemIndex + 1);
                        scheduleOfLessonsAndExercise.Insert(secondElemIndex, firstElemToSwap);
                        scheduleOfLessonsAndExercise.Insert(secondElemIndex + 1, firstExerciseToSwap);
                    }
                    else if ((scheduleOfLessonsAndExercise.Contains(operation[1]) &&
                        scheduleOfLessonsAndExercise.Contains(operation[1] + "-Exercise")) &&
                        (scheduleOfLessonsAndExercise.Contains(operation[2])))
                    {
                        scheduleOfLessonsAndExercise.RemoveAt(secondElemIndex);
                        scheduleOfLessonsAndExercise.Insert(secondElemIndex, tempLesson);
                        scheduleOfLessonsAndExercise.RemoveAt(firstElemIndex);
                        scheduleOfLessonsAndExercise.Insert(firstElemIndex, secondElemToSwap);
                        scheduleOfLessonsAndExercise.RemoveAt(firstElemIndex + 1);
                        scheduleOfLessonsAndExercise.Insert(secondElemIndex + 1, firstExerciseToSwap);
                    }
                    else if ((scheduleOfLessonsAndExercise.Contains(operation[2]) &&
                        scheduleOfLessonsAndExercise.Contains(operation[2] + "-Exercise")) &&
                        (scheduleOfLessonsAndExercise.Contains(operation[1])))
                    {
                        scheduleOfLessonsAndExercise.RemoveAt(secondElemIndex);
                        scheduleOfLessonsAndExercise.Insert(secondElemIndex, tempLesson);
                        scheduleOfLessonsAndExercise.RemoveAt(firstElemIndex);
                        scheduleOfLessonsAndExercise.Insert(firstElemIndex, secondElemToSwap);
                        scheduleOfLessonsAndExercise.RemoveAt(secondElemIndex + 1);
                        scheduleOfLessonsAndExercise.Insert(firstElemIndex + 1, secondExerciseToSwap);
                    }
                    else if (scheduleOfLessonsAndExercise.Contains(operation[1])
                         && scheduleOfLessonsAndExercise.Contains(operation[2]))
                    {
                        scheduleOfLessonsAndExercise.RemoveAt(firstElemIndex);
                        scheduleOfLessonsAndExercise.Insert(firstElemIndex, secondElemToSwap);
                        scheduleOfLessonsAndExercise.RemoveAt(secondElemIndex);
                        scheduleOfLessonsAndExercise.Insert(secondElemIndex, firstElemToSwap);
                    }
                }
                else if (operation[0] == "Exercise")
                {
                    int getLessonIndex = -1;

                    for (int i = 0; i < scheduleOfLessonsAndExercise.Count; i++)
                    {
                        if (scheduleOfLessonsAndExercise[i] == operation[1])
                        {
                            getLessonIndex = i;
                            break;
                        }
                    }
                    if (scheduleOfLessonsAndExercise.Contains(operation[1])
                        && !(scheduleOfLessonsAndExercise.Contains(operation[1] + "-Exercise")))
                    {
                        scheduleOfLessonsAndExercise.Insert(getLessonIndex + 1, operation[1] + "-Exercise");
                    }

                    else if (!scheduleOfLessonsAndExercise.Contains(operation[1]))
                    {
                        scheduleOfLessonsAndExercise.Add(operation[1]);
                        scheduleOfLessonsAndExercise.Add(operation[1] + "-Exercise");
                    }
                }
                command = Console.ReadLine();
            }
            for (int i = 0; i < scheduleOfLessonsAndExercise.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{scheduleOfLessonsAndExercise[i]}");
            }
        }
    }
}
