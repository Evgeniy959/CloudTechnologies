namespace OrdersApiAppSPD011.Service.СheckService
{
    public interface IDaoCheck
    {
        Task<Object> CheckAsync(int id);
    }
}
