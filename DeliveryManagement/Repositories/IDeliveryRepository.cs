using DeliveryManagement.Models;
using System;
using System.Collections.Generic;

namespace DeliveryManagement.Repositories
{
	public interface IDeliveryRepository
	{
		IEnumerable<Delivery> GetAllDeliveries();
		Delivery GetDeliveryById(Guid id);
		void AddDelivery(Delivery delivery);
		void UpdateDelivery(Delivery delivery);
		void DeleteDelivery(Delivery delivery);
		bool DeliveryExists(Guid id);
		bool SaveChanges();
	}
}