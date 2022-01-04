using Autofac;
using Newtonsoft.Json;
using PeerIslands.SQLQueryGenerator.Domain.Models;
using PeerIslands.SQLQueryGenerator.Repository;
using System;
using System.Collections.Generic;

namespace PeerIslands.SQLQueryGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = ContainerConfig.Configure();

            using (var scope = config.BeginLifetimeScope())
            {
                var app = scope.Resolve<IStartup>();
                app.Run();
            }

            Console.ReadLine();
        }
    }
}
