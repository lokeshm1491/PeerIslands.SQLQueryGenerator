using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Domain.Models
{
    [Serializable]
    public class Table
    {
        public string TableName { get; set; }
        public List<Column> Columns { get; set; }
    }
}
