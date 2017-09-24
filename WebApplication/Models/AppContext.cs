using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ApplicationContext : DbContext
    {
        private IConfigurationRoot _config;

        public ApplicationContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["Data:SQLserver"]);
            base.OnConfiguring(optionsBuilder);
        }

    }
}
