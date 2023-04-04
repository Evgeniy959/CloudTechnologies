using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.ClientService;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IDaoEntity<Product> daoProduct;

        public ProductController(IDaoEntity<Product> daoProduct)
        {
            this.daoProduct = daoProduct;
        }

        [HttpGet("all")]
        public async Task<List<Product>> GetAll()
        {
            return await daoProduct.GetAllAsync();
        }

        [HttpGet("get")]
        public async Task<Product> Get(int id)
        {
            return await daoProduct.GetAsync(id);
        }

        [HttpPost("add")]
        public async Task<Product> Add(/*[FromBody]*/ Product product)
        {
            return await daoProduct.AddAsync(product);
        }

        [HttpPost("update")]
        public async Task<Product> Update(Product product)
        {
            return await daoProduct.UpdateAsync(product);
        }

        [HttpDelete("delete")]
        public async Task<Product> Delete(int id)
        {
            return await daoProduct.DeleteAsync(id);
        }

    }
}
