using System;
using System.Linq;

namespace StanNedelchev
{
    public class AlienNumbers
    {
        public static void Main(string[] args)
        {
            var cases = int.Parse(Console.ReadLine());
            for (int @case = 1; @case <= cases; @case++)
            {
                string[] rowContents = Console.ReadLine().Split(' ');
                string num = rowContents[0];
                string inputAlphabet = rowContents[1];
                string outputAlphabet = rowContents[2];

                int inputBase = inputAlphabet.Length;
                int outputBase = outputAlphabet.Length;

                int numInBase10 = ConvertToBase10(num, inputAlphabet, inputBase);
                string numInOutputBase = ConvertFromBase10(outputAlphabet, outputBase, numInBase10);

                Console.WriteLine("Case #{0}: {1}", @case, numInOutputBase);
            }
        }
 
        private static string ConvertFromBase10(string outputAlphabet, int outputBase, int numInBase10)
        {
            string numInOutputBase = string.Empty;
            while (numInBase10 > 0)
            {
                numInOutputBase = outputAlphabet[numInBase10 % outputBase].ToString() + numInOutputBase;
                numInBase10 /= outputBase;
            }
            return numInOutputBase;
        }
 
        private static int ConvertToBase10(string num, string inputAlphabet, int inputBase)
        {
            int sum = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                int add = inputAlphabet.IndexOf(num[num.Length - i - 1]) * (int)Math.Pow(inputBase, i);
                sum += add;
            }
            return sum;
        }
    }
}
