using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Model;
using Microsoft.EntityFrameworkCore;

namespace OrdersApiAppSPD011.Service.OrderService
{
    public class DbDaoOrder : IDaoEntity<Order>
    {
        private readonly ApplicationDbContext db;
        public DbDaoOrder(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<Order> AddAsync(Order order)
        {
            db.Clients.Load(); //явная загрузка данных о клиенте
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return order;
        }

        public async Task<Order> DeleteAsync(int id)
        {
            db.Clients.Load(); //явная загрузка данных о клиенте
            Order order = await db.Orders.SingleOrDefaultAsync(x => x.Id == id);
            if (order != null)
            {
                db.Orders.Remove(order);
                var delRelOrderProduct = await db.OrderProduct.Where(op => op.OrderId == id).ToListAsync();
                db.OrderProduct.RemoveRange(delRelOrderProduct);
                await db.SaveChangesAsync();
            }
            return order;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            db.Clients.Load(); //явная загрузка данных о клиенте
            return await db.Orders.ToListAsync();
            //return await db.Orders.Include(o => o.Client).ToListAsync();
        }

        public async Task<Order> GetAsync(int id)
        {
            db.Clients.Load();
            return await db.Orders.SingleOrDefaultAsync(x => x.Id == id);
            //return await db.Orders.Include(c => c.Client).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            db.Clients.Load();
            db.Orders.Update(order);
            await db.SaveChangesAsync();
            return order;
        }
    }
}
