using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Model.Entity;
using OrdersApiAppSPD011.Service;
using OrdersApiAppSPD011.Service.InfoService;
using OrdersApiAppSPD011.Service.OrderService;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IDaoInfo daoInfo;

        public InfoController(IDaoInfo daoInfo)
        {
            this.daoInfo = daoInfo;
        }

        [HttpGet("order")]
        public async Task<Object> GetOrder(int id)
        {
            return await daoInfo.GetOrderAsync(id);
        }
    }
}
