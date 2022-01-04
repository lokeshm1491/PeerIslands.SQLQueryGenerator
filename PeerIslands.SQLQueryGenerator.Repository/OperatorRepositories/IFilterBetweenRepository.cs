using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterBetweenRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}