using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public class FilterInRepository : IFilterTable
    {
        public string GenerateFilterQuery(Column filterColumn)
        {
            var filterValues = GetFieldValue(filterColumn).FieldValue;
            return $"{filterColumn.FieldName} IN ({filterValues})";
        }

        private Column GetFieldValue(Column filterColumn)
        {
            var values = filterColumn.FieldValue.Split(';').ToList();
            filterColumn.FieldValue = "'" + string.Join("','", values) + "'";
            return filterColumn;
        }
    }
}
