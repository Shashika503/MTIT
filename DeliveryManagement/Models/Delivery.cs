using System.ComponentModel.DataAnnotations;

namespace DeliveryManagement.Models
{

	public class Delivery
	{
		[Key]
		public Guid Id { get; set; }

		public string DeliveryPersonName { get; set; }

		public string DeliveryVehicleNumber { get; set; }

		public DateTime DeliveryDate { get; set; }

		[Required]
		[MaxLength(100)]
		public string DeliveryStatus { get; set; }

		[Required]
		public string DeliveryAddress { get; set; }

	}
}