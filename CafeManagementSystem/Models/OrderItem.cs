using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OrderManagement.Models
{
	public class OrderItem
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public Guid OrderId { get; set; }

		public string ItemName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }

	
		public Order Order { get; set; }
	}
}
