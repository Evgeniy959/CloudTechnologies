namespace OrdersApiAppSPD011.Service.InfoService
{
    public interface IDaoInfo
    {
        Task<object> GetOrderAsync(int id);
    }
}
