using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterInRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}