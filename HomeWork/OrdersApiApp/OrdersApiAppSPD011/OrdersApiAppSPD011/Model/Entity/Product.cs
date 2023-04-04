using System.Text.Json.Serialization;

namespace OrdersApiAppSPD011.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleNumber { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Name = "";
            ArticleNumber = 0;
            Price = 0;
        }
    }
}
