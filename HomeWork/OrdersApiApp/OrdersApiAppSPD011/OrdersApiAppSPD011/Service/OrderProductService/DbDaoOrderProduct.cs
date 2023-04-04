using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;

namespace OrdersApiAppSPD011.Service.OrderProductService
{
    public class DbDaoOrderProduct : IDaoEntity<OrderProduct>
    {
        private readonly ApplicationDbContext db;
        public DbDaoOrderProduct(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<OrderProduct> AddAsync(OrderProduct orderProduct)
        {
            db.Clients.Load(); //явная загрузка данных о клиенте
            db.Products.Load(); //явная загрузка данных о продукте
            db.Orders.Load(); //явная загрузка данных о заказе
            db.OrderProduct.Add(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }

        public async Task<OrderProduct> DeleteAsync(int id)
        {
            db.Clients.Load(); //явная загрузка данных о клиенте
            db.Products.Load(); //явная загрузка данных о продукте
            db.Orders.Load(); //явная загрузка данных о заказе
            OrderProduct orderProduct = await db.OrderProduct.SingleOrDefaultAsync(x => x.Id == id);
            if (orderProduct != null)
            {
                db.OrderProduct.Remove(orderProduct);
                await db.SaveChangesAsync();
            }
            return orderProduct;
        }

        public async Task<List<OrderProduct>> GetAllAsync()
        {
            db.Clients.Load(); //явная загрузка данных о клиенте
            db.Products.Load(); //явная загрузка данных о продукте
            db.Orders.Load(); //явная загрузка данных о заказе
            return await db.OrderProduct.ToListAsync();
        }

        public async Task<OrderProduct> GetAsync(int id)
        {
            db.Clients.Load();
            db.Products.Load(); 
            db.Orders.Load(); 
            return await db.OrderProduct.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderProduct> UpdateAsync(OrderProduct orderProduct)
        {
            db.Clients.Load();
            db.Products.Load();
            db.Orders.Load();
            db.OrderProduct.Update(orderProduct);
            await db.SaveChangesAsync();
            return orderProduct;
        }
    }
}
