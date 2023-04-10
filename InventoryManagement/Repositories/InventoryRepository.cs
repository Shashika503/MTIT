using InventoryManagement.Data;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Repositories
{
	public class InventoryRepository : IInventoryRepository
	{
		private readonly InventoryContext _context;

		public InventoryRepository(InventoryContext context)
		{
			_context = context;
		}

		public IEnumerable<InventoryItem> GetAllInventoryItems()
		{
			return _context.InventoryItems.ToList();
		}

		public InventoryItem GetInventoryItemById(Guid id)
		{
			return _context.InventoryItems.FirstOrDefault(item => item.Id == id);
		}

		public void AddInventoryItem(InventoryItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			_context.InventoryItems.Add(item);
		}

		public void UpdateInventoryItem(InventoryItem item)
		{
			// No implementation needed, as the context will track changes automatically.
		}

		public void DeleteInventoryItem(InventoryItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			_context.InventoryItems.Remove(item);
		}

		public bool InventoryItemExists(Guid id)
		{
			return _context.InventoryItems.Any(item => item.Id == id);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}
