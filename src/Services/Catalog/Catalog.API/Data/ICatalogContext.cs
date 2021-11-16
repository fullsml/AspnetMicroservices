using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Catalog.API.Data
{
    public interface ICatalogContext
    {
      DbSet<Product> Products { get; }
    }
}
