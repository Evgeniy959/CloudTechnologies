using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoProduct : IDaoEntity<Product> 
    {
        private readonly ApplicationDbContext db;
        public DbDaoProduct(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public async Task<Product> AddAsync(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            Product product = await db.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return product;
            }
            else return null;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await db.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
    }
}
