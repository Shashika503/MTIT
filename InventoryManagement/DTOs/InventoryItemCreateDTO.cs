namespace InventoryManagement.DTOs
{
	public class InventoryItemCreateDTO
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}