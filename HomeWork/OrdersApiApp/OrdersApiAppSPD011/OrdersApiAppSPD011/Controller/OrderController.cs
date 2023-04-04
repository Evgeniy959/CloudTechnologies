using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IDaoEntity<Order> daoOrder;

        public OrderController(IDaoEntity<Order> daoOrder)
        {
            this.daoOrder = daoOrder;
        }

        [HttpGet("all")]
        public async Task<List<Order>> GetAll()
        {
            return await daoOrder.GetAllAsync();
        }

        [HttpGet("get")]
        public async Task<Order> Get(int id)
        {
            return await daoOrder.GetAsync(id);
        }

        [HttpPost("add")]
        public async Task<Order> Add(Order order)
        {
            return await daoOrder.AddAsync(order);
        }

        [HttpPost("update")]
        public async Task<Order> Update(Order order)
        {
            return await daoOrder.UpdateAsync(order);
        }

        [HttpDelete("delete")]
        public async Task<Order> Delete(int id)
        {
            return await daoOrder.DeleteAsync(id);
        }
    }
}
