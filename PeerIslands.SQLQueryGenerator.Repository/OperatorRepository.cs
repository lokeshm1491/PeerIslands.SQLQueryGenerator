using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public class OperatorRepository
    {
        public IFilterTable SelectOperatorRepository(string operatorType)
        {
            IFilterTable filterTable;
            switch (operatorType.ToLower())
            {
                case "equal":
                    filterTable = new FilterEqualRepository();
                    break;
                case "notequal":
                    filterTable = new FilterNotEqualRepository();
                    break;
                case "greaterthan":
                    filterTable = new FilterGreaterThanRepository();
                    break;
                case "lessthan":
                    filterTable = new FilterLessThanRepository();
                    break;
                case "like":
                    filterTable = new FilterLikeRepository();
                    break;
                case "in":
                    filterTable = new FilterInRepository();
                    break;
                case "between":
                    filterTable = new FilterBetweenRepository();
                    break;
                default:
                    filterTable = null;
                    break;
            }
            return filterTable;
        }
    }
}
