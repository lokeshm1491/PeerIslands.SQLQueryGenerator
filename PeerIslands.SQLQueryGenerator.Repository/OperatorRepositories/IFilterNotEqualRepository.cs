using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterNotEqualRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}