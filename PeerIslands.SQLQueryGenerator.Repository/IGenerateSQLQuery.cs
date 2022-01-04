using PeerIslands.SQLQueryGenerator.Domain.Models;
using System.Collections.Generic;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public interface IGenerateSQLQuery
    {
        string GenerateJoinQuery(List<Table> tables, string selectedColumns);
        string GenerateQuery(Table table, string selectedColumns);
    }
}