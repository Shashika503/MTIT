using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OrderManagement.Models
{
	public class Order
	{

		[Key]
		public Guid Id { get; set; }

		public DateTime OrderDate { get; set; }
		public string CustomerName { get; set; }
		public string DeliveryAddress { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }

		public decimal Discount { get; set; }

		public decimal DiscountedTotal { get; set; }


		public decimal CalculateDiscountedTotal()
		{
			decimal total = OrderItems.Sum(item => item.Quantity * item.UnitPrice);
			decimal discountAmount = total * (Discount / 100);
			decimal discountedTotal = total - discountAmount;
			return discountedTotal;
		}

	}
}