using SupplierManagement.Models;
using System;
using System.Collections.Generic;

public interface ISupplierRepository
{
	IEnumerable<Supplier> GetAllSuppliers();
	Supplier GetSupplierById(Guid id);
	void AddSupplier(Supplier supplier);
	void UpdateSupplier(Supplier supplier);
	void DeleteSupplier(Supplier supplier);
	bool SupplierExists(Guid id);
	bool SaveChanges();
}
