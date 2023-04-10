﻿using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.Data
{
	public class OrderDbContext : DbContext
	{
		public OrderDbContext(DbContextOptions<OrderDbContext> options)
			: base(options)
		{
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
	}
}
