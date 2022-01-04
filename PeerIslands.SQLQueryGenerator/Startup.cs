using Newtonsoft.Json;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using PeerIslands.SQLQueryGenerator.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator
{
    public class Startup : IStartup
    {
        private readonly IGenerateSQLQuery _generateSQL;

        public Startup(IGenerateSQLQuery generateSQL)
        {
            _generateSQL = generateSQL;
        }

        public void Run()
        {
            Console.WriteLine("Program has been started");

            string genaretedQuery = string.Empty;
            string fileJson = string.Empty;

            Console.WriteLine("==============ProblemOne Output Start===================");
            fileJson = FileReader.ReadFile(@"ProblemOne.json");
            Table _Table = JsonConvert.DeserializeObject<Table>(fileJson);
            genaretedQuery = _generateSQL.GenerateQuery(_Table, "*");
            Console.WriteLine(genaretedQuery);
            Console.WriteLine("==============ProblemOne Output Start===================");

            Console.WriteLine("==============ProblemTwo Output Start===================");
            fileJson = FileReader.ReadFile(@"ProblemTwo.json");
            List<Table> Tables = JsonConvert.DeserializeObject<List<Table>>(fileJson);
            genaretedQuery = _generateSQL.GenerateJoinQuery(Tables, "*");
            Console.WriteLine(genaretedQuery);
            Console.WriteLine("==============ProblemTwo Output Start===================");

            Console.WriteLine("Program has ended, enter any key to close");
            Console.Read();
        }
    }
}
