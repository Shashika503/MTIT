namespace OrderManagement.DTOs
{
	public class OrderItemUpdateDTO
	{
		public Guid Id { get; set; }
		public string ItemName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
