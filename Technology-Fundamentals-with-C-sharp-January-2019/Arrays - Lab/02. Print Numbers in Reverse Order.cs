using System;

namespace p02.Print_numbers_in_reverse_order
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                int readNumbers = int.Parse(Console.ReadLine());
                arr[i] = readNumbers;
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
}
