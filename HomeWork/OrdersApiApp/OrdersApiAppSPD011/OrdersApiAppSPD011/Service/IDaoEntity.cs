namespace OrdersApiAppSPD011.Service
{
    // Generic-интерфейс DAO для работы с сущностями
    public interface IDaoEntity<T>
    {
        // базовый CRUD
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T t);
        Task<T> UpdateAsync(T t);
        Task<T> DeleteAsync(int id);
        Task<T> GetAsync(int id);
    }
}
