using PeerIslands.SQLQueryGenerator.Domain.Models;
using PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public class GenerateSQLQuery : IGenerateSQLQuery
    {
        private readonly IOperatorRepository _operatorRepository;

        public GenerateSQLQuery(IOperatorRepository operatorRepository)
        {
            _operatorRepository = operatorRepository;
        }

        public string GenerateQuery(Table table, string selectedColumns)
        {
            StringBuilder query = new StringBuilder("select " + selectedColumns + " from ");

            query.Append(table.TableName + " Where ");

            int columnCount = table.Columns.Count();
            for (int i = 0; i < columnCount; i++)
            {
                var fitlerColumn = table.Columns[i];
                var generatedQuery = _operatorRepository.GenerateFilterQuery(fitlerColumn.Operator, fitlerColumn);
                query.Append(generatedQuery);

                if (i < columnCount - 1 && fitlerColumn.Condition != null)
                    query.Append(" " + fitlerColumn.Condition + " ");
            }
            return query.ToString();
        }

        public string GenerateJoinQuery(List<Table> tables, string selectedColumns)
        {
            StringBuilder query = new StringBuilder("select " + selectedColumns + " from");

            int tablesCount = tables.Count();
            Table currenttable;
            Table nexttable = null;
            for (int i = 0; i < tablesCount; i++)
            {
                currenttable = tables[i];
                if (i < tablesCount - 1 & tablesCount > 1)
                    nexttable = tables[1];
                if (nexttable != null && nexttable.JoinType != null && !string.IsNullOrEmpty(nexttable.JoinType))
                    query.Append(" (" + GenerateQuery(currenttable, "*") + " ) " + currenttable.TableName + " " + nexttable.JoinType + " ");
                else
                    query.Append(" (" + GenerateQuery(currenttable, "*") + " ) " + currenttable.TableName + " ");

                if (i > 0 && tablesCount > 1 && currenttable.JoinConditions != null && currenttable.JoinConditions.Count > 0
                    && currenttable != null && currenttable.JoinType != null && !string.IsNullOrEmpty(currenttable.JoinType))
                {
                    query.Append(" ON ");
                    int columnCount = currenttable.JoinConditions.Count;
                    for (int j = 0; j < columnCount; j++)
                    {
                        var fitlerColumn = currenttable.JoinConditions[j];
                        var generatedQuery = _operatorRepository.GenerateFilterQuery(fitlerColumn.Operator, fitlerColumn);
                        query.Append(generatedQuery.Replace("'", ""));

                        if (j < columnCount - 1 && fitlerColumn.Condition != null)
                            query.Append(" " + fitlerColumn.Condition + " ");
                    }
                }
                nexttable = null;
            }
            return query.ToString();
        }
    }
}
