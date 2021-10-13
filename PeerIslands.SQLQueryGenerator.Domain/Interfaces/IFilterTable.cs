using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Domain.Interfaces
{
    public interface IFilterTable
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}
