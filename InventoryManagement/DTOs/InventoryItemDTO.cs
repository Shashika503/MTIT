using System;

namespace InventoryManagement.DTOs
{
	public class InventoryItemDTO
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
	}
}
