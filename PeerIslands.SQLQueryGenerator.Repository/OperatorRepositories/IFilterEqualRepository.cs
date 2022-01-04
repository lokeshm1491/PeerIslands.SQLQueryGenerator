using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterEqualRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}