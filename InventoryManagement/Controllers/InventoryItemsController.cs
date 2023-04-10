using InventoryManagement.DTOs;
using InventoryManagement.Models;
using InventoryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class InventoryItemsController : ControllerBase
	{
		private readonly IInventoryRepository _repository;

		public InventoryItemsController(IInventoryRepository repository)
		{
			_repository = repository;
		}

		// GET: api/InventoryItems
		[HttpGet("get-all-inventories")]
		public ActionResult<IEnumerable<InventoryItemDTO>> GetAllInventoryItems()
		{
			var items = _repository.GetAllInventoryItems()
				.Select(item => new InventoryItemDTO
				{
					Id = item.Id,
					Name = item.ItemName,
					Quantity = item.Quantity,
					UnitPrice = item.UnitPrice
				});

			return Ok(items);
		}

		// GET: api/InventoryItems/{id}
		[HttpGet("get-inventoryitem/{id}")]
		public ActionResult<InventoryItemDTO> GetInventoryItemById(Guid id)
		{
			var item = _repository.GetInventoryItemById(id);

			if (item == null)
			{
				return NotFound();
			}

			var itemDTO = new InventoryItemDTO
			{
				Id = item.Id,
				Name = item.ItemName,
				Quantity = item.Quantity,
				UnitPrice = item.UnitPrice
			};

			return Ok(itemDTO);
		}

		// POST: api/InventoryItems
		[HttpPost("create-inventoryitem")]
		public ActionResult<InventoryItemDTO> CreateInventoryItem(InventoryItemCreateDTO itemCreateDTO)
		{
			var item = new InventoryItem
			{
				ItemName = itemCreateDTO.Name,
				Quantity = itemCreateDTO.Quantity,
				UnitPrice = itemCreateDTO.UnitPrice
			};

			_repository.AddInventoryItem(item);
			_repository.SaveChanges();

			var itemDTO = new InventoryItemDTO
			{
				Id = item.Id,
				Name = item.ItemName,
				Quantity = item.Quantity,
				UnitPrice = item.UnitPrice
			};

			return CreatedAtAction(nameof(GetInventoryItemById), new { id = item.Id }, itemDTO);
		}

		// PUT: api/InventoryItems/{id}
		[HttpPut("update-inventoryitem{id}")]
		public IActionResult UpdateInventoryItem(Guid id, InventoryItemUpdateDTO itemUpdateDTO)
		{
			var item = _repository.GetInventoryItemById(id);

			if (item == null)
			{
				return NotFound();
			}

			item.ItemName = itemUpdateDTO.Name;
			item.Quantity = itemUpdateDTO.Quantity;
			item.UnitPrice = itemUpdateDTO.UnitPrice;

			_repository.UpdateInventoryItem(item);
			_repository.SaveChanges();

			return NoContent();
		}

		// DELETE: api/InventoryItems/{id}
		[HttpDelete("delete-inventoryitem/{id}")]
		public IActionResult DeleteInventoryItem(Guid id)
		{
			var item = _repository.GetInventoryItemById(id);

			if (item == null)
			{
				return NotFound();
			}

			_repository.DeleteInventoryItem(item);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}
