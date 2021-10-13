using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public class FilterBetweenRepository : IFilterTable
    {
        public string GenerateFilterQuery(Column filterColumn)
        {
            var values = filterColumn.FieldValue.Split(';').ToList();
            return $"{filterColumn.FieldName} BETWEEN '{values.FirstOrDefault()}' AND '{values.LastOrDefault()}'";
        }
    }
}
