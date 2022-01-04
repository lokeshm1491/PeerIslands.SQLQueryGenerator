using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Domain.Models;

namespace PeerIslands.SQLQueryGenerator.Repository
{
    public interface IOperatorRepository
    {
        string GenerateFilterQuery(string operatorType, Column filterColumn);
    }
}