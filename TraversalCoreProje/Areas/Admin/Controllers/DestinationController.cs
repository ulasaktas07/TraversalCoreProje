﻿using BusinesLayer.Abstract;
using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class DestinationController : Controller
	{
		private readonly IDestinationService _destinationService;

		public DestinationController(IDestinationService destinationService)
		{
			_destinationService = destinationService;
		}

		public IActionResult Index()
		{
			var values= _destinationService.TGetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddDestination(Destination destination)
		{
			_destinationService.TAdd(destination);
			return RedirectToAction("Index", new { area = "Admin" });
		}
		public IActionResult DeleteDestination(int id)
		{
			var values= _destinationService.TGetById(id);
			_destinationService.TDelete(values);
			return RedirectToAction("Index", new { area = "Admin" });
		}
		[HttpGet]
		public IActionResult UpdateDestination(int id)
		{
			var values = _destinationService.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult UpdateDestination(Destination destination)
		{
			_destinationService.TUpdate(destination);
			return RedirectToAction("Index", new { area = "Admin" });
		}
	}
}
