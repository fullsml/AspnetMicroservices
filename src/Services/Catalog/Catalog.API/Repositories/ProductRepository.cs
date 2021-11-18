using Catalog.API.Data;
using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();               
        }
        public async Task<Product> GetProduct(string id)
        {
            return await _context
                .Products
                .FindAsync(id);
                

        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
         
            return await _context.Products.Where(el => el.Name == name).ToListAsync();
               
        }
        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            return await _context.Products.Where(el => el.Category == categoryName).ToListAsync();
          
        }

        public async Task CreateProduct(Product product)
        {
             _context.Add(product);
            await _context.SaveChangesAsync();

        }

        public async Task<bool> UpdateProduct(Product product)
        {
          _context.Update(product);
           var cc= await _context.SaveChangesAsync();


            return cc > 0; //.IsAcknowledged   && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            _context.Remove(id);
            var cc = await _context.SaveChangesAsync();


            return cc > 0;

            //FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            //DeleteResult deleteResult = await _context
            //                                    .Products
            //                                    .DeleteOneAsync(filter);

            //return deleteResult.IsAcknowledged
            //    && deleteResult.DeletedCount > 0;
        }
    }
}
