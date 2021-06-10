using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GEMS_Cloud.Models;
using Microsoft.Extensions.Configuration;

namespace GEMS_Cloud
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base(GetOptions())
        { }
        private static DbContextOptions GetOptions()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public DbSet<UserCredentials> User { get; set; }
    }
}
