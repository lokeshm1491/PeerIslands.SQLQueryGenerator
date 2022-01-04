using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public class FilterInRepository : IFilterInRepository
    {
        public string GenerateFilterQuery(Column filterColumn)
        {
            var filterValues = GetFieldValue(filterColumn);
            return $"{filterColumn.FieldName} IN ({filterValues})";
        }

        private string GetFieldValue(Column filterColumn)
        {
            var values = filterColumn.FieldValue.Split(';').ToList();
            return "'" + string.Join("','", values) + "'";
        }
    }
}
