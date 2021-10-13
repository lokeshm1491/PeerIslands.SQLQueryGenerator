using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public class OperatorFactory
    {
        public IFilterTable selectOperatorRepository(string operatorType)
        {
            IFilterTable filterTable;
            switch (operatorType.ToLower())
            {
                case "equal":
                    filterTable = new FilterEqualRepository();
                    break;
                default:
                    filterTable = null;
                    break;
            }
            return filterTable;
        }
    }
}
