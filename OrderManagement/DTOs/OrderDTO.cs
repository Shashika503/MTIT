namespace OrderManagement.DTOs
{
	public class OrderDTO
	{
		public Guid Id { get; set; }
		public DateTime OrderDate { get; set; }
		public string CustomerName { get; set; }
		public string DeliveryAddress { get; set; }
		public decimal Discount { get; set; }
		public decimal DiscountedTotal { get; set; }
		public List<OrderItemDTO> OrderItems { get; set; }
	}
}
