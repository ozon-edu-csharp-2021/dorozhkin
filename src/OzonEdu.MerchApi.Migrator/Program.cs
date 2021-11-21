﻿using System;
using System.IO;
using System.Linq;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace OzonEdu.MerchApi.Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetSection("DatabaseConnectionOptions:ConnectionString")
                .Get<string>();

            var services = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(
                    rb => rb
                        .AddPostgres()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(Program).Assembly)
                        .For.Migrations());
            
            var serviceProvider = services.BuildServiceProvider();

            using (serviceProvider.CreateScope())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

                if (args.Contains("--dryrun"))
                    runner.ListMigrations();
                else
                    runner.MigrateUp();
            }
        }
    }
}