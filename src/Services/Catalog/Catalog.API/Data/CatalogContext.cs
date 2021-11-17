using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Catalog.API.Data
{
    public class CatalogContext:DbContext //:ICatalogContext
    {
        private IConfiguration _configuration;
        public DbSet<Product> Products { get; }
        //public DbSet<Product1> Products1 { get; }
        public CatalogContext(IConfiguration configuration)
        {
            _configuration = configuration;
          
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        


    }
}
