using System;
using System.Collections;

namespace Lab
{
    class Task1
    {
        public static void Solve(string s1, string s2)
        {
            var stack = new Stack();

            foreach (char с in s2)
                stack.Push(с);

            bool isReverse = true;

            foreach (char с in s1)
            {
                if (с != (char)stack.Pop())
                {
                    isReverse = false;
                    break;
                }
            }

            Console.WriteLine($"Строка s2 {isReverse ? "" : "не "}является обратной s1.");
        }
    }
}
