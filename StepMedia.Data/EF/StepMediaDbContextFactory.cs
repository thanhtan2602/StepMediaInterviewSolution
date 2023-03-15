using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StepMedia.Data.EF
{
    public class StepMediaDbContextFactory : IDesignTimeDbContextFactory<StepMediaDbContext>
    {
        public StepMediaDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("StepMediaInterviewDb");

            var optionsBuilder = new DbContextOptionsBuilder<StepMediaDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new StepMediaDbContext(optionsBuilder.Options);
        }
    }
}
