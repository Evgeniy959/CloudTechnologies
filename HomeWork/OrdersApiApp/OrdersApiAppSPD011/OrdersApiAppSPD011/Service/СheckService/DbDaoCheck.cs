using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;

namespace OrdersApiAppSPD011.Service.СheckService
{
    public class DbDaoCheck : IDaoCheck
    {
        private readonly ApplicationDbContext db;
        public DbDaoCheck(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Object> CheckAsync(int id)
        {
            var products = await db.OrderProduct.Where(op => op.OrderId == id)
                .Select(op => new { op.Product.Name, op.Product.Price, op.Quantity })
                .ToListAsync();

            double sum = 0;
            double price = 0;

            foreach (var product in products)
            {
                price = product.Price * product.Quantity;
                sum += price;
            }
            Object check = new
            {
                Products = products,
                TotalPrice = sum
            };
            return check;
        }
    }
}
