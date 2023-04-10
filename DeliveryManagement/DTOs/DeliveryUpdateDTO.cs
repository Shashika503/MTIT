namespace DeliveryManagement.DTOs
{
	public class DeliveryUpdateDTO
	{
		public Guid Id { get; set; }
		public string DeliveryPersonName { get; set; }
		public string DeliveryVehicleNumber { get; set; }
		public DateTime DeliveryDate { get; set; }
		public string DeliveryStatus { get; set; }
		public string DeliveryAddress { get; set; }
	}
}
