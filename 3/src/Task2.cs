using System;
using System.Collections.Generic;
using System.IO;

namespace Lab
{
    class Task2
    {
        public static void Solve(string inputFile, int a, int b)
        {
            string[] text = File.ReadAllText(inputFile).TrimEnd().Split();
            var numbers = new int[text.Length];

            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = int.Parse(text[i]);

            var inRange = new Queue<int>();
            var lessThanA = new Queue<int>();
            var moreThanB = new Queue<int>();

            foreach (int n in numbers)
            {
                if (a <= n && n <= b)
                {
                    inRange.Enqueue(n);
                }
                else if (n < a)
                {
                    lessThanA.Enqueue(n);
                }
                else
                {
                    moreThanB.Enqueue(n);
                }
            }

            Console.WriteLine($"Числа от {a} до {b}:");

            for (int i = 0; i < inRange.Count; i++)
                Console.Write($"{inRange.Dequeue()} ");
            Console.WriteLine();

            Console.WriteLine($"Числа меньше {a}:");

            for (int i = 0; i < lessThanA.Count; i++)
                Console.Write($"{lessThanA.Dequeue()} ");
            Console.WriteLine();

            Console.WriteLine($"Числа больше {b}:");

            for (int i = 0; i < moreThanB.Count; i++)
                Console.Write($"{moreThanB.Dequeue()} ");
            Console.WriteLine();
        }
    }
}
