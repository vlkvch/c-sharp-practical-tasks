using System;
using System.IO;

namespace Lab
{
    class Util
    {
        public static void WriteRandomNumbers(string outputFile)
        {
            if (File.Exists(outputFile))
                File.Delete(outputFile);

            var rand = new Random();

            var file = new FileStream(outputFile, FileMode.OpenOrCreate);
            var sw = new StreamWriter(file);

            for (int i = 0; i < 32; i++)
                sw.Write($"{rand.Next(100)} ");

            sw.Close();
        }
    }
}
