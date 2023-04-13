using DeliveryManagement.DTOs;
using DeliveryManagement.Models;
using DeliveryManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DeliveryManagement.Controllers
{
	[Route("api/deliveries")]
	[ApiController]
	public class DeliveriesController : ControllerBase
	{
		private readonly IDeliveryRepository _repository;

		public DeliveriesController(IDeliveryRepository repository)
		{
			_repository = repository;
		}

		[HttpGet("get-all-deliveries")]
		public ActionResult<IEnumerable<Delivery>> GetAllDeliveries()
		{
			var deliveries = _repository.GetAllDeliveries();
			return Ok(deliveries);
		}

		[HttpGet("get-delivery/{id}")]
		public ActionResult<Delivery> GetDeliveryById(Guid id)
		{
			var delivery = _repository.GetDeliveryById(id);

			if (delivery == null)
			{
				return NotFound();
			}

			return Ok(delivery);
		}

		[HttpPost("create-delivery")]
		public ActionResult<Delivery> CreateDelivery(Delivery delivery)
		{
			_repository.AddDelivery(delivery);
			_repository.SaveChanges();

			return CreatedAtAction(nameof(GetDeliveryById), new { id = delivery.Id }, delivery);
		}

		[HttpPut("update-delivery/{id}")]
		public IActionResult UpdateDelivery(Guid id, DeliveryUpdateDTO deliveryUpdateDTO)
		{
			var delivery = _repository.GetDeliveryById(id);

			if (delivery == null)
			{
				return NotFound();
			}

			delivery.DeliveryPersonName = deliveryUpdateDTO.DeliveryPersonName;
			delivery.DeliveryVehicleNumber = deliveryUpdateDTO.DeliveryVehicleNumber;
			delivery.DeliveryDate = deliveryUpdateDTO.DeliveryDate;
			delivery.DeliveryStatus = deliveryUpdateDTO.DeliveryStatus;
			delivery.DeliveryAddress = deliveryUpdateDTO.DeliveryAddress;

			_repository.UpdateDelivery(delivery);
			_repository.SaveChanges();

			return NoContent();
		}

		[HttpDelete("delete-delivery/{id}")]
		public IActionResult DeleteDelivery(Guid id)
		{
			var delivery = _repository.GetDeliveryById(id);

			if (delivery == null)
			{
				return NotFound();
			}

			_repository.DeleteDelivery(delivery);
			_repository.SaveChanges();

			return NoContent();
		}
	}
}
