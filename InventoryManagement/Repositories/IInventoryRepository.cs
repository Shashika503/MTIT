using InventoryManagement.Models;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Repositories
{
	public interface IInventoryRepository
	{
		IEnumerable<InventoryItem> GetAllInventoryItems();
		InventoryItem GetInventoryItemById(Guid id);
		void AddInventoryItem(InventoryItem item);
		void UpdateInventoryItem(InventoryItem item);
		void DeleteInventoryItem(InventoryItem item);
		bool InventoryItemExists(Guid id);
		bool SaveChanges();
	}
}
