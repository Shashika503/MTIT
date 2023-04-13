namespace OrderManagement.DTOs
{
	public class OrderItemDTO
	{
		public Guid Id { get; set; }
		public Guid OrderId { get; set; }
		public string ItemName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
