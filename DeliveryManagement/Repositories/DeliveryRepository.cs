using DeliveryManagement.Data;
using DeliveryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryManagement.Repositories
{
	public class DeliveryRepository : IDeliveryRepository
	{
		private readonly DeliveryContext _context;

		public DeliveryRepository(DeliveryContext context)
		{
			_context = context;
		}

		public IEnumerable<Delivery> GetAllDeliveries()
		{
			return _context.Deliveries.ToList();
		}

		public Delivery GetDeliveryById(Guid id)
		{
			return _context.Deliveries.FirstOrDefault(d => d.Id == id);
		}

		public void AddDelivery(Delivery delivery)
		{
			_context.Deliveries.Add(delivery);
		}

		public void UpdateDelivery(Delivery delivery)
		{
			_context.Entry(delivery).State = EntityState.Modified;
		}

		public void DeleteDelivery(Delivery delivery)
		{
			_context.Deliveries.Remove(delivery);
		}

		public bool DeliveryExists(Guid id)
		{
			return _context.Deliveries.Any(d => d.Id == id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}
	}
}
