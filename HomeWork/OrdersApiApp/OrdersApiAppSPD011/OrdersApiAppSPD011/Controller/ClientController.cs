using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IDaoEntity<Client> daoClient;

        public ClientController(IDaoEntity<Client> daoClient)
        {
            this.daoClient = daoClient;
        }

        [HttpGet("all")]
        public async Task<List<Client>> GetAll()
        {
            return await daoClient.GetAllAsync();
        }

        [HttpGet("get")]
        public async Task<Client> Get(int id)
        {
            return await daoClient.GetAsync(id);
        }

        [HttpPost("add")]
        public async Task<Client> Add(Client client)
        {
            return await daoClient.AddAsync(client);
        }

        [HttpPost("update")]
        public async Task<Client> Update(Client client)
        {
            return await daoClient.UpdateAsync(client);
        }

        [HttpDelete("delete")]
        public async Task<Client> Delete(int id)
        {
            return await daoClient.DeleteAsync(id);
        }
    }
}
