using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterGreaterThanRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}