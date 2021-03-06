using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public class FilterLessThanRepository : IFilterLessThanRepository
    {
        public string GenerateFilterQuery(Column filterColumn)
        {
            return $"{filterColumn.FieldName} < '{filterColumn.FieldValue}'";
        }
    }
}
