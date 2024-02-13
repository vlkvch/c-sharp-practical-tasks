using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab
{
    class Task3
    {
        public static void Solve(string inputFile, string outputFile)
        {
            string[] lines = File.ReadAllText(inputFile).TrimEnd('\n').Split('\n');

            var numberOfOccurrences = new SortedDictionary<string, int>();
            var occurrenceLines = new Dictionary<string, List<int>>();

            int maxWordLength = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] words = Regex.Split(lines[i], @"[\s\.\?\!\,]+");

                foreach (string word in words)
                {
                    string w = word.ToLower();

                    if (w.Length > maxWordLength)
                    {
                        maxWordLength = w.Length;
                    }

                    if (!numberOfOccurrences.ContainsKey(w))
                    {
                        numberOfOccurrences.Add(w, 0);
                    }

                    if (!occurrenceLines.ContainsKey(w))
                    {
                        var x = new int[]{i + 1};
                        occurrenceLines.Add(w, new List<int>(x));
                    }

                    numberOfOccurrences[w]++;

                    if (!occurrenceLines[w].Contains(i + 1))
                    {
                        occurrenceLines[w].Add(i + 1);
                    }
                }
            }

            var output = new FileStream(outputFile, FileMode.OpenOrCreate);
            var sw = new StreamWriter(output);

            char firstLetter = ' ';

            foreach (KeyValuePair<string, int> kv in numberOfOccurrences)
            {
                if (kv.Key == "")
                {
                    continue;
                }

                if (kv.Key[0] != firstLetter)
                {
                    sw.WriteLine(Char.ToUpper(kv.Key[0]));
                    firstLetter = kv.Key[0];
                }

                sw.Write($"{kv.Key}".PadRight(maxWordLength + 3, '.') + $"{kv.Value}: ");

                foreach (int n in occurrenceLines[kv.Key])
                {
                    sw.Write($"{n}".PadRight(2));
                }

                sw.WriteLine();
            }

            sw.Close();
        }
    }
}
