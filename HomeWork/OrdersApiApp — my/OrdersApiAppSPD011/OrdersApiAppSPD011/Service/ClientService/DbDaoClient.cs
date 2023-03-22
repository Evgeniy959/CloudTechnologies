using Microsoft.EntityFrameworkCore;
using OrdersApiAppSPD011.Model;
using OrdersApiAppSPD011.Model.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrdersApiAppSPD011.Service.ClientService
{
    public class DbDaoClient : IDaoClient
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
            Client client = db.Clients.Find(id);
            if (client != null)
            {
                db.Clients.Remove(client);
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
            return await db.Clients.FindAsync(id); ; 
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            //Client clientNew = await db.Clients.FindAsync(client.Id);
            Client clientNew = db.Clients.Find(client.Id);
            if (clientNew != null)
            {
                clientNew.Name = client.Name;
                await db.SaveChangesAsync();
            }
            return clientNew;
        }
    }
}
