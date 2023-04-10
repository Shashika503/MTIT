using SupplierManagement.Data;
using SupplierManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SupplierManagement.Repositories
{
	public class SupplierRepository : ISupplierRepository
	{
		private readonly SupplierDbContext _context;

		public SupplierRepository(SupplierDbContext context)
		{
			_context = context;
		}

		public IEnumerable<Supplier> GetAllSuppliers()
		{
			return _context.Suppliers.ToList();
		}

		public Supplier GetSupplierById(Guid id)
		{
			return _context.Suppliers.FirstOrDefault(s => s.Id == id);
		}

		public void AddSupplier(Supplier supplier)
		{
			if (supplier == null)
			{
				throw new ArgumentNullException(nameof(supplier));
			}

			_context.Suppliers.Add(supplier);
		}

		public void UpdateSupplier(Supplier supplier)
		{
			// No additional code needed since Entity Framework Core automatically tracks changes
		}

		public void DeleteSupplier(Supplier supplier)
		{
			if (supplier == null)
			{
				throw new ArgumentNullException(nameof(supplier));
			}

			_context.Suppliers.Remove(supplier);
		}

		public bool SupplierExists(Guid id)
		{
			return _context.Suppliers.Any(s => s.Id == id);
		}

		public bool SaveChanges()
		{
			return _context.SaveChanges() >= 0;
		}
	}
}
