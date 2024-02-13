using System;
using System.Collections.Generic;

namespace Lab
{
    class Program
    {
        static void Main()
        {
            for (byte i = 1; i < 4; i++)
            {
                uint[] permutation;
                uint numberOfChars;
                string text;

                Util.ParseInput(i, out permutation, out numberOfChars, out text);
                uint[] reversedPermutation = Util.ReversedPermutation(permutation);
                List<string> textFragments = Util.TextFragments(text);

                List<string> decrypted = Util.DecryptedFragments(textFragments, permutation);

                Util.WriteToFile(i, numberOfChars, reversedPermutation, decrypted);
            }
        }
    }
}
