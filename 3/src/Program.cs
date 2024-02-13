using System;

namespace Lab
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Задание №1\n----------");

            Console.Write("Введите первую строку:\n> ");
            string s1 = Console.ReadLine();
            Console.Write("Введите вторую строку:\n> ");
            string s2 = Console.ReadLine();

            Task1.Solve(s1, s2);

            Console.WriteLine("\nЗадание №2\n----------");

            Util.WriteRandomNumbers("./txt/2.input.txt");

            Console.Write("Введите число a:\n> ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число b:\n> ");
            int b = int.Parse(Console.ReadLine());

            Task2.Solve("./txt/2.input.txt", a, b);

            Task3.Solve("./txt/3.input.txt", "./txt/3.output.txt");
        }
    }
}
