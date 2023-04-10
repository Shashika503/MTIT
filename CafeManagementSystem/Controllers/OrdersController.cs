using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Data;
using OrderManagement.DTOs;
using OrderManagement.Models;
using OrderManagement.Repositories;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
	private readonly IOrderRepository _repository;

	public OrdersController(IOrderRepository repository)
	{
		_repository = repository;
	}


	// GET: api/Orders
	[HttpGet("get-all-orders")]
    public ActionResult<IEnumerable<Order>> GetOrders()
	{
		return Ok(_repository.GetAllOrders());
	}

	//// GET: api/Orders/{id}
	//[HttpGet("get-order/{id}")]
	//public ActionResult<Order> GetOrderById(Guid id)
	//{
	//	var order = _repository.GetOrderById(id);

	//	if (order == null)
	//	{
	//		return NotFound();
	//	}

	//	return order;
	//}
	[HttpGet("get-order/{id}")]
	public async Task<ActionResult<OrderDTO>> GetOrderById(Guid id)
	{
		var order = await _repository.GetOrderByIdAsync(id);

		if (order == null)
		{
			return NotFound();
		}

		// Map the order entity to the DTO
		var orderDTO = new OrderDTO
		{
			Id = order.Id,
			OrderDate = order.OrderDate,
			CustomerName = order.CustomerName,
			DeliveryAddress = order.DeliveryAddress,
			Discount = order.Discount,
			DiscountedTotal = order.CalculateDiscountedTotal(),
			OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
			{
				Id = oi.Id,
				OrderId = oi.OrderId,
				ItemName = oi.ItemName,
				Quantity = oi.Quantity,
				UnitPrice = oi.UnitPrice
			}).ToList()
		};

		return Ok(orderDTO);
	}
	// POST: api/Orders
	[HttpPost("create-order")]
	public async Task<ActionResult<OrderDTO>> CreateOrder(OrderCreateDTO orderCreateDTO)
	{
		// Map the DTO to the entity model
		var order = new Order
		{
			OrderDate = orderCreateDTO.OrderDate,
			CustomerName = orderCreateDTO.CustomerName,
			DeliveryAddress = orderCreateDTO.DeliveryAddress,
			Discount = orderCreateDTO.Discount,
			OrderItems = orderCreateDTO.OrderItems.Select(oi => new OrderItem
			{
				ItemName = oi.ItemName,
				Quantity = oi.Quantity,
				UnitPrice = oi.UnitPrice
			}).ToList()
		};

		// Calculate the DiscountedTotal before saving
		order.DiscountedTotal = order.CalculateDiscountedTotal();

		// Save the order to the database
		_repository.AddOrder(order);
		await _repository.SaveChangesAsync();

		// Map the created order to an OrderDTO
		var orderDTO = new OrderDTO
		{
			Id = order.Id,
			OrderDate = order.OrderDate,
			CustomerName = order.CustomerName,
			DeliveryAddress = order.DeliveryAddress,
			Discount = order.Discount,
			DiscountedTotal = order.DiscountedTotal,
			OrderItems = order.OrderItems.Select(oi => new OrderItemDTO
			{
				Id = oi.Id,
				OrderId = oi.OrderId,
				ItemName = oi.ItemName,
				Quantity = oi.Quantity,
				UnitPrice = oi.UnitPrice
			}).ToList()
		};

		return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, orderDTO);
	}

	// PUT: api/Orders/{id}
	[HttpPut("update-order/{id}")]
	public IActionResult UpdateOrder(Guid id, OrderUpdateDTO orderUpdateDTO)
	{
		var order = _repository.GetOrderById(id);

		if (order == null)
		{
			return NotFound();
		}

		order.OrderDate = orderUpdateDTO.OrderDate;
		order.CustomerName = orderUpdateDTO.CustomerName;
		order.DeliveryAddress = orderUpdateDTO.DeliveryAddress;

		order.OrderItems = orderUpdateDTO.OrderItems.Select(oi => new OrderItem
		{
			Id = oi.Id,
			OrderId = id,
			ItemName = oi.ItemName,
			Quantity = oi.Quantity,
			UnitPrice = oi.UnitPrice
		}).ToList();

		_repository.UpdateOrder(order);
		_repository.SaveChanges();

		return NoContent();
	}



	// DELETE: api/Orders/{id}
	[HttpDelete("delete-order/{id}")]
	public IActionResult DeleteOrder(Guid id)
	{
		var order = _repository.GetOrderById(id);

		if (order == null)
		{
			return NotFound();
		}

		_repository.DeleteOrder(order);
		_repository.SaveChanges();

		return NoContent();
	}
}
