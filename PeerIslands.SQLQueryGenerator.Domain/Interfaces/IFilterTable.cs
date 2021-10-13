﻿using PeerIslands.SQLQueryGenerator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Domain.Interfaces
{
    interface IFilterTable
    {
        string GenerateFilterQuery(Column filterColumn);
    }
}
