using System.Text.Json.Serialization;

namespace OrdersApiAppSPD011.Model.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Description { get; set; }
        // навигационные свойства
        public Client? Client { get; set; } // объект клиента, на которого ссылается заказ


        public Order()
        {
            Description = "";
        }
    }
}
