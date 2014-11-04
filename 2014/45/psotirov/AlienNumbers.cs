using System;
using System.Text;
using System.IO;

namespace AlienNumbers
{
    class Program
    {
        const int MaxOutputLength = 94;
        static StreamWriter outFile = null;

        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                outFile = new StreamWriter(args[1]);
                Console.SetOut(outFile);
                Console.SetIn(new StreamReader(args[0])); 
            }

            int N = int.Parse(Console.ReadLine());
            for (int caseNr = 1; caseNr <= N; caseNr++)
            {
                var line = Console.ReadLine().Split(' ');
                Console.WriteLine(  "Case #{0}: {1}", 
                                    caseNr, 
                                    ConvertNumber(line[0], line[1], line[2]) );
            }

            if (outFile != null) outFile.Close();
        }

        static string ConvertNumber(string number, string sourceLang, string targetLang)
        {
            StringBuilder result = new StringBuilder(MaxOutputLength);

            int sourceBase = sourceLang.Length;
            int targetBase = targetLang.Length;
            int toDecimal = 0;

            for (int i = 0; i < number.Length; i++)
            {
                toDecimal = toDecimal * sourceBase + sourceLang.IndexOf(number[i]);
            }

            while (toDecimal > 0)
            {
                result.Insert(0, targetLang[toDecimal % targetBase]);
                toDecimal /= targetBase;
            }

            return result.ToString();
        }
    }
}
