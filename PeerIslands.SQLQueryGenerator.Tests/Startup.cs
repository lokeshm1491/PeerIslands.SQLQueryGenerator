using Autofac;
using Microsoft.Extensions.DependencyInjection;
using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Repository;
using PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PeerIslands.SQLQueryGenerator.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IGenerateSQLQuery, GenerateSQLQuery>();
            services.AddTransient<IOperatorRepository, OperatorRepository>();
            services.AddTransient<IFilterEqualRepository, FilterEqualRepository>();
            services.AddTransient<IFilterNotEqualRepository, FilterNotEqualRepository>();
            services.AddTransient<IFilterGreaterThanRepository, FilterGreaterThanRepository>();
            services.AddTransient<IFilterLessThanRepository, FilterLessThanRepository>();
            services.AddTransient<IFilterLikeRepository, FilterLikeRepository>();
            services.AddTransient<IFilterInRepository, FilterInRepository>();
            services.AddTransient<IFilterBetweenRepository, FilterBetweenRepository>();
        }
    }
}
