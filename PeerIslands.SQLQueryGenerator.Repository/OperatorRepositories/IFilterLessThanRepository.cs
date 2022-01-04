using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterLessThanRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}