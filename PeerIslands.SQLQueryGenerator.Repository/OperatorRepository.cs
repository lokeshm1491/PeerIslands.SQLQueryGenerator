using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public class OperatorRepository : IOperatorRepository
    {
        private readonly IFilterEqualRepository _filterEqual;
        private readonly IFilterNotEqualRepository _filterNotEqual;
        private readonly IFilterGreaterThanRepository _filterGreaterThan;
        private readonly IFilterLessThanRepository _filterLessThan;
        private readonly IFilterLikeRepository _filterLike;
        private readonly IFilterInRepository _filterIn;
        private readonly IFilterBetweenRepository _filterBetween;

        public OperatorRepository(IFilterEqualRepository filterEqual, IFilterNotEqualRepository filterNotEqual,
            IFilterGreaterThanRepository filterGreaterThan, IFilterLessThanRepository filterLessThan,
            IFilterLikeRepository filterLike, IFilterInRepository filterIn, IFilterBetweenRepository filterBetween)
        {
            _filterEqual = filterEqual;
            _filterNotEqual = filterNotEqual;
            _filterGreaterThan = filterGreaterThan;
            _filterLessThan = filterLessThan;
            _filterLike = filterLike;
            _filterIn = filterIn;
            _filterBetween = filterBetween;
        }

        public string GenerateFilterQuery(string operatorType, Column filterColumn)
        {
            string generatedQuery;
            switch (operatorType.ToLower())
            {
                case "equal":
                    generatedQuery = _filterEqual.GenerateFilterQuery(filterColumn);
                    break;
                case "notequal":
                    generatedQuery = _filterNotEqual.GenerateFilterQuery(filterColumn);
                    break;
                case "greaterthan":
                    generatedQuery = _filterGreaterThan.GenerateFilterQuery(filterColumn);
                    break;
                case "lessthan":
                    generatedQuery = _filterLessThan.GenerateFilterQuery(filterColumn);
                    break;
                case "like":
                    generatedQuery = _filterLike.GenerateFilterQuery(filterColumn);
                    break;
                case "in":
                    generatedQuery = _filterIn.GenerateFilterQuery(filterColumn);
                    break;
                case "between":
                    generatedQuery = _filterBetween.GenerateFilterQuery(filterColumn);
                    break;
                default:
                    generatedQuery = string.Empty;
                    break;
            }
            return generatedQuery;
        }
    }
}
