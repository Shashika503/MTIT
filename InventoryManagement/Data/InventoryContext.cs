using InventoryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Data
{
	public class InventoryContext : DbContext
	{
		public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
		{
		}

		public DbSet<InventoryItem> InventoryItems { get; set; }
	}
}

