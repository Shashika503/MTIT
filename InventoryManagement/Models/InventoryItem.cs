using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
	public class InventoryItem
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		[MaxLength(100)]
		public string ItemName { get; set; }

		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }

		public DateTime LastUpdated { get; set; }
	}
}
