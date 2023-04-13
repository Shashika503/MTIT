namespace OrderManagement.DTOs
{
	public class OrderItemCreateDTO
	{
		public string ItemName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
