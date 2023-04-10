namespace SupplierManagement.Models
{
	public class Supplier
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string ContactName { get; set; }
		public string ContactPhone { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
	}
}
