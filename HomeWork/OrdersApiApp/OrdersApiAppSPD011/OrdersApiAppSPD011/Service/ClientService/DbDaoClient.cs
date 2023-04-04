using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoClient : IDaoEntity<Client>
    {
        private readonly ApplicationDbContext db;
        public DbDaoClient(ApplicationDbContext db) 
        {
            this.db = db;
        }
        public async Task<Client> AddAsync(Client client)
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return client;
        }

        public async Task<Client> DeleteAsync(int id)
        {
            Client client = await db.Clients.SingleOrDefaultAsync(x => x.Id == id);
            if (client != null)
            {
                db.Clients.Remove(client);                
                var delOrderProduct = await db.OrderProduct.Where(op => op.Order.ClientId == id).ToListAsync();
                db.OrderProduct.RemoveRange(delOrderProduct);
                var delOrders = await db.Orders.Where(o => o.ClientId == id).ToListAsync();
                db.Orders.RemoveRange(delOrders);
                await db.SaveChangesAsync();
            }
            
            return client;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await db.Clients.ToListAsync();
        }

        public async Task<Client> GetAsync(int id)
        {
            return await db.Clients.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            db.Clients.Update(client);
            await db.SaveChangesAsync();
            return client;
        }
    }
}
