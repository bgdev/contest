using System;
using System.Text;
using System.IO;

namespace AlwaysTurnLeft
{
    class Program
    {
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
                Console.WriteLine(  "Case #{0}:",  caseNr);
                Console.Write(SolveMaze(line[0], line[1]));
            }

            if (outFile != null) outFile.Close();
        }


        static string SolveMaze(string straightWalk, string backWalk)
        {
            // remove first and last walks which are outside the maze
            straightWalk = straightWalk.Substring(1, straightWalk.Length - 2);
            backWalk = backWalk.Substring(1, backWalk.Length - 2);

            var maze = new Maze();
            foreach (var move in straightWalk)
            {
                maze.Walk(move);
            }    
            // update maze exit
            maze.CreateExit();
            foreach (var move in backWalk)
            {
                maze.Walk(move);
            }    

            return maze.GetState();
        }
    }
}
