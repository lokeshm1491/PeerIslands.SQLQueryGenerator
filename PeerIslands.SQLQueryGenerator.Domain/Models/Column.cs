using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Domain.Models
{
    [Serializable]
    public class Column
    {
        public string Operator { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
    }
}
