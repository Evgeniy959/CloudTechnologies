using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderProductController : ControllerBase
    {
        private readonly IDaoEntity<OrderProduct> daoOrderProduct;

        public OrderProductController(IDaoEntity<OrderProduct> daoOrderProduct)
        {
            this.daoOrderProduct = daoOrderProduct;
        }

        [HttpGet("all")]
        public async Task<List<OrderProduct>> GetAll()
        {
            return await daoOrderProduct.GetAllAsync();
        }

        [HttpGet("get")]
        public async Task<OrderProduct> Get(int id)
        {
            return await daoOrderProduct.GetAsync(id);
        }

        [HttpPost("add")]
        public async Task<OrderProduct> Add(OrderProduct orderProduct)
        {
            return await daoOrderProduct.AddAsync(orderProduct);
        }

        [HttpPost("update")]
        public async Task<OrderProduct> Update(OrderProduct orderProduct)
        {
            return await daoOrderProduct.UpdateAsync(orderProduct);
        }

        [HttpDelete("delete")]
        public async Task<OrderProduct> Delete(int id)
        {
            return await daoOrderProduct.DeleteAsync(id);
        }
    }
}
