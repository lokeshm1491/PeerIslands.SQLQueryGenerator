using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public class GenerateSQLQuery
    {
        public string GenerateQuery(Table table)
        {
            StringBuilder query = new StringBuilder("select * from ");

            query.Append(table.TableName + " Where ");

            int columnCount = table.Columns.Count();
            for (int i = 0; i < columnCount; i++)
            {
                var fitlerColumn = table.Columns[i];
                var operatorRepo = new OperatorRepository();
                var operatorType = operatorRepo.SelectOperatorRepository(fitlerColumn.Operator);
                var generatedQuery = operatorType.GenerateFilterQuery(fitlerColumn);
                query.Append(generatedQuery);

                if (i < columnCount - 1 && fitlerColumn.Condition != null)
                    query.Append(" " + fitlerColumn.Condition + " ");
            }
            return query.ToString();
        }
    }
}
