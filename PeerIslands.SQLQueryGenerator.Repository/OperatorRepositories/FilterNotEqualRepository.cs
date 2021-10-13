using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public class FilterNotEqualRepository : IFilterTable
    {
        public string GenerateFilterQuery(Column filterColumn)
        {
            return $"{filterColumn.FieldName} <> '{filterColumn.FieldValue}'";
        }
    }
}
