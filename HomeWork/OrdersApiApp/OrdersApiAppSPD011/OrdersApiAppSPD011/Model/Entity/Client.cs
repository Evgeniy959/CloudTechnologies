using System.Text.Json.Serialization;

namespace OrdersApiAppSPD011.Model.Entity
{
    // сущность Клиента
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // навигационные свойства
        [JsonIgnore]
        public ICollection<Order>? Orders { get; set; } //список заказов клиента

        public Client()
        {
            Name = "";
        }
    }
}
