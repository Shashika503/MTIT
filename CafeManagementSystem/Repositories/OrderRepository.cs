using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.Models;

namespace OrderManagement.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly OrderDbContext _context;

		public OrderRepository(OrderDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Order> GetAllOrders()
		{
			return _context.Orders.Include(o => o.OrderItems).ToList();
		}

		public Order GetOrderById(Guid id)
		{
			return _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == id);
		}

		public void AddOrder(Order order)
		{
			_context.Orders.Add(order);
		}

		public void UpdateOrder(Order order)
		{
			_context.Entry(order).State = EntityState.Modified;
		}

		public void DeleteOrder(Order order)
		{
			_context.Orders.Remove(order);
		}

		public bool OrderExists(Guid id)
		{
			return _context.Orders.Any(o => o.Id == id);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() > 0;
		}

		public async Task<Order> GetOrderByIdAsync(Guid id)
		{
			return await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}
