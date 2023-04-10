using OrderManagement.Models;

namespace OrderManagement.Repositories
{
	public interface IOrderRepository
	{
		IEnumerable<Order> GetAllOrders();

		Order GetOrderById(Guid id);

		Task<Order> GetOrderByIdAsync(Guid id);
		void AddOrder(Order order);
		void UpdateOrder(Order order);
		void DeleteOrder(Order order);
		bool OrderExists(Guid id);
		bool SaveChanges();

		Task<bool> SaveChangesAsync();
	}
}
