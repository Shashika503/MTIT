using System;
using System.Collections.Generic;
namespace OrderManagement.DTOs
{
	public class OrderCreateDTO
	{
		public DateTime OrderDate { get; set; }
		public string CustomerName { get; set; }
		public string DeliveryAddress { get; set; }
		public List<OrderItemCreateDTO> OrderItems { get; set; }

		public decimal Discount { get; set; }
	}
}
