using Microsoft.AspNetCore.Mvc;
using SupplierManagement.DTOs;
using SupplierManagement.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SupplierManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuppliersController : ControllerBase
	{
		private readonly ISupplierRepository _repository;

		public SuppliersController(ISupplierRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("get-allsuppliers")]
		public ActionResult<IEnumerable<Supplier>> GetAllSuppliers()
		{
			var suppliers = _repository.GetAllSuppliers();
			return Ok(suppliers);
		}

		[HttpGet("get-supplier/{id}")]
		public ActionResult<Supplier> GetSupplierById(Guid id)
		{
			var supplier = _repository.GetSupplierById(id);

			if (supplier == null)
			{
				return NotFound();
			}

			return Ok(supplier);
		}

		[HttpPost("create-supplier")]
		public ActionResult<Supplier> CreateSupplier(Supplier supplier)
		{
			_repository.AddSupplier(supplier);
			_repository.SaveChanges();

			return CreatedAtAction(nameof(GetSupplierById), new { id = supplier.Id }, supplier);
		}

		[HttpPut("update-supplier/{id}")]
		public IActionResult UpdateSupplier(Guid id, SupplierDto supplierUpdateDTO)
		{
			var supplier = _repository.GetSupplierById(id);

			if (supplier == null)
			{
				return NotFound();
			}

			// Map the SupplierUpdateDTO to the existing Supplier
			supplier.Name = supplierUpdateDTO.Name;
			supplier.Address = supplierUpdateDTO.Address;
			supplier.Email = supplierUpdateDTO.Email;
			supplier.ContactPhone = supplierUpdateDTO.ContactPhone;

			_repository.UpdateSupplier(supplier);
			_repository.SaveChanges();

			return NoContent();
		}

		[HttpDelete("delete-supplier/{id}")]
		public IActionResult DeleteSupplier(Guid id)
		{
			var supplier = _repository.GetSupplierById(id);

			if (supplier == null)
			{
				return NotFound();
			}

			_repository.DeleteSupplier(supplier);
			_repository.SaveChanges();

			return NoContent();
		}

	}
}
