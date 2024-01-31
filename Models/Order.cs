using System.Text.Json.Serialization;

namespace ProvaPub.Models
{
	public class Order
	{
		public int Id { get; set; }
		public decimal Value { get; set; }
		public int CustomerId { get; set; }
        
		[JsonPropertyName("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        public string Message { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
        }
    }
}
