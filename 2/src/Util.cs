using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab
{
    class Util
    {
        public static void ParseInput(
            byte fileNumber,
            out uint[] permutation, 
            out uint numberOfChars, 
            out string text)
        {
            var sr = new StreamReader($"./txt/Scrambled_{fileNumber}.txt");

            sr.ReadLine();

            string[] p = Regex.Split(sr.ReadLine().Trim(), @"\s+");
            permutation = new uint[p.Length];
            for (int i = 0; i < p.Length; i++)
                permutation[i] = uint.Parse(p[i]);

            sr.ReadLine();

            numberOfChars = uint.Parse(sr.ReadLine());

            sr.ReadLine();

            text = "";

            while (!sr.EndOfStream)
                text += sr.ReadLine() + '\n';

            sr.Close();
        }

        public static uint[] ReversedPermutation(uint[] permutation)
        {
            var revPermutation= new uint[permutation.Length];

            for (int i = 0; i < permutation.Length; i++)
                revPermutation[permutation[i]] = (uint)i;

            return revPermutation;
        }

        public static List<string> TextFragments(string text)
        {
            var fragments = new List<string>();

            for (int i = 0; i < text.Length; i += 20)
            {
                try
                {
                    fragments.Add(text.Substring(i, 20));
                }
                catch (ArgumentOutOfRangeException)
                {
                    fragments.Add(text.Substring(i));
                }
            }

            fragments[fragments.Count - 1] = fragments[fragments.Count - 1].Trim('\n');

            return fragments;
        }
        
        public static List<string> DecryptedFragments(List<string> textFragments, uint[] permutation)
        {
            var decrypted = new List<string>();

            foreach (string f in textFragments)
            {
                string decryptedFragment = "";
                
                for (int i = 0; i < f.Length; i++)
                {
                    int j = i;

                    if (f.Length < 20)
                    {
                        while (permutation[j] >= f.Length)
                        {
                            j = (int)permutation[j];
                        }
                    }

                    decryptedFragment += f[(int)permutation[j]];
                }

                decrypted.Add(decryptedFragment);
            }

            return decrypted;
        }

        public static void WriteToFile(
            byte fileNumber, 
            uint numberOfChars, 
            uint[] permutation, 
            List<string> text)
        {
            var file = new FileStream($"./txt/Unscrambled_{fileNumber}.txt", FileMode.OpenOrCreate);
            var sw = new StreamWriter(file);

            var separator = new string('+', 64);

            sw.WriteLine(separator);
            sw.Write($"Decrypting {numberOfChars} characters\nUsing:\t\t");

            for (uint i = 0; i < permutation.Length; i++)
                sw.Write($"{i}".PadLeft(2, ' ') + ' ');
            sw.WriteLine();

            sw.Write("\t\t");
            foreach (uint e in permutation)
                sw.Write($"{e}".PadLeft(2, ' ') + ' ');
            sw.WriteLine("\n");

            foreach (string e in text)
                sw.Write(e);

            sw.WriteLine();
            sw.WriteLine(separator);

            sw.Close();
        }
    }
}
