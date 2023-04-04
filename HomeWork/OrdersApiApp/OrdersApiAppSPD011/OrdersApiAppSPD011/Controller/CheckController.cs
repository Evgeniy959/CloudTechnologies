using Microsoft.AspNetCore.Mvc;
using OrdersApiAppSPD011.Service.СheckService;

namespace OrdersApiAppSPD011.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        private readonly IDaoCheck daoCheck;

        public CheckController(IDaoCheck daoCheck)
        {
            this.daoCheck = daoCheck;
        }

        [HttpGet]
        public async Task<Object> Check(int id)
        {
            return await daoCheck.CheckAsync(id);
        }
    }
}
