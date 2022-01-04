using Autofac;
using PeerIslands.SQLQueryGenerator.Domain.Interfaces;
using PeerIslands.SQLQueryGenerator.Repository;
using PeerIslands.SQLQueryGenerator.Repository.OperatorRepositories;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PeerIslands.SQLQueryGenerator
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Startup>().As<IStartup>();
            builder.RegisterType<GenerateSQLQuery>().As<IGenerateSQLQuery>();
            builder.RegisterType<OperatorRepository>().As<IOperatorRepository>();
            builder.RegisterType<FilterEqualRepository>().As<IFilterEqualRepository>();
            builder.RegisterType<FilterNotEqualRepository>().As<IFilterNotEqualRepository>();
            builder.RegisterType<FilterGreaterThanRepository>().As<IFilterGreaterThanRepository>();
            builder.RegisterType<FilterLessThanRepository>().As<IFilterLessThanRepository>();
            builder.RegisterType<FilterLikeRepository>().As<IFilterLikeRepository>();
            builder.RegisterType<FilterInRepository>().As<IFilterInRepository>();
            builder.RegisterType<FilterBetweenRepository>().As<IFilterBetweenRepository>();

            //builder.RegisterAssemblyTypes(Assembly.Load(nameof(PeerIslands.SQLQueryGenerator.Repository)))
            //    .Where(t => t.Namespace.EndsWith("Repositories")).As<IFilterTable>();

            return builder.Build();
        }
    }
}
