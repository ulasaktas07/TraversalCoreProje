﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]

	public class DestinationCQRSController : Controller
	{
		private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
		private readonly GetDestinationByIDQueryHandler _getDestinationByIDQueryHandler;
		private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
		private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
		private readonly UpdateDestinationCommendHandler _updateDestinationCommendHandler;

		public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler,
			GetDestinationByIDQueryHandler getDestinationByIDQueryHandler,
			CreateDestinationCommandHandler createDestinationCommandHandler,
			RemoveDestinationCommandHandler removeDestinationCommandHandler,
			UpdateDestinationCommendHandler updateDestinationCommendHandler)
		{
			_getAllDestinationQueryHandler = getAllDestinationQueryHandler;
			_getDestinationByIDQueryHandler = getDestinationByIDQueryHandler;
			_createDestinationCommandHandler = createDestinationCommandHandler;
			_removeDestinationCommandHandler = removeDestinationCommandHandler;
			_updateDestinationCommendHandler = updateDestinationCommendHandler;
		}

		public IActionResult Index()
		{
			var values = _getAllDestinationQueryHandler.Handle();
			return View(values);
		}
		[HttpGet]
		public IActionResult GetDestination(int id)
		{
			var values = _getDestinationByIDQueryHandler.Handle(new GetDestinationByIDQuery(id));
			return View(values);
		}
		[HttpPost]
		public IActionResult GetDestination(UpdateDestinationCommand command)
		{
			_updateDestinationCommendHandler.Handle(command);
			return RedirectToAction("Index", new { area = "Admin" });
		}
		[HttpGet]
		public IActionResult AddDestination()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddDestination(CreateDestinationCommand command)
		{
			_createDestinationCommandHandler.Handle(command);
			return RedirectToAction("Index", new { area = "Admin" });
		}
		public IActionResult DeleteDestination(int id)
		{
			_removeDestinationCommandHandler.Handle(new RemoveDestinationCommands(id));
			return RedirectToAction("Index", new { area = "Admin" });
		}
	}
}
