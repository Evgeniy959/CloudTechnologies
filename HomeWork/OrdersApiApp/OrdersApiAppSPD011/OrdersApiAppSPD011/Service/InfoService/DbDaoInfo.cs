using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.InfoService
{
    public class DbDaoInfo : IDaoInfo
    {
        private readonly ApplicationDbContext db;
        public DbDaoInfo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Object> GetOrderAsync(int id)
        {
            await db.Clients.LoadAsync();
            Order order = await db.Orders.SingleOrDefaultAsync(o => o.Id == id);
            var products = await db.OrderProduct.Where(op => op.OrderId == id)
                .Select(op => new { op.Product, op.Quantity })
                .ToListAsync();
            var OrderInfo = new
            {
                Order = order,
                Products = products
            };

            return OrderInfo;
        }
    }
}
