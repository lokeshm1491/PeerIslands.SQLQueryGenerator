using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories
{
    public interface IFilterLikeRepository
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}