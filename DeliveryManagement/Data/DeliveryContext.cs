
using DeliveryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManagement.Data
{
	public class DeliveryContext : DbContext
	{
		public DeliveryContext(DbContextOptions<DeliveryContext> options)
			: base(options)
		{
		}

		public DbSet<Delivery> Deliveries { get; set; }
	}
}