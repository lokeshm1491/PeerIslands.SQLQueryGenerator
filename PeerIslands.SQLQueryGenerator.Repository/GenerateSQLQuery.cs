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

            for (int i = 0; i < table.Columns.Count(); i++)
            {
                var queryFilter = table.Columns[i];
                var operatorFactory = new OperatorFactory();
                var operatorType = operatorFactory.selectOperatorRepository(queryFilter.Operator);
                var generatedQuery = operatorType.GenerateFilterQuery(queryFilter);

                query.Append(generatedQuery);
            }
            return query.ToString();
        }
    }
}
