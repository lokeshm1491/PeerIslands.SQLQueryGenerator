using Newtonsoft.Json;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using PeerIslands.SQLQueryGenerator.Repository;
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
            Table problemOneTable = JsonConvert.DeserializeObject<Table>(problemOneJson);

            GenerateSQLQuery generateSQL = new GenerateSQLQuery();
            string problemOneQuery = generateSQL.GenerateQuery(problemOneTable);

            Console.WriteLine(problemOneQuery);

            Console.WriteLine("=================================");
            Console.WriteLine("Program has ended, enter any key to close");
            Console.Read();
        }
    }
}
