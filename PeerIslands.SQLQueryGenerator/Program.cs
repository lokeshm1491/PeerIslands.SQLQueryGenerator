using System;

namespace PeerIslands.SQLQueryGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Program has been started");
            Console.WriteLine("=================================");

            string problemOneJson = FileReader.ReadFile(@"ProblemOne.json");

            Console.WriteLine(problemOneJson);

            Console.WriteLine("=================================");
            Console.WriteLine("Program has ended, enter any key to close");
            Console.Read();
        }
    }
}
