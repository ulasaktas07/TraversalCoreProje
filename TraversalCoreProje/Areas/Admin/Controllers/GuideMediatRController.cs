﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.GuideCommands;
using TraversalCoreProje.CQRS.Queries.GuideQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class GuideMediatRController : Controller
	{
		private readonly IMediator _mediator;

		public GuideMediatRController(IMediator mediator)
		{
			_mediator = mediator;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _mediator.Send(new GetAllGuideQuery());
			return View(values);
		}
		[HttpGet]
		public async Task<IActionResult> GetGuides(int id)
		{
			var value =await _mediator.Send(new GetGuideByIDQuery(id));
			return View(value);
		}
		[HttpGet]
		public IActionResult AddGuide()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddGuide(CreateGuideCommand command)
		{
			await _mediator.Send(command);
			return RedirectToAction("Index", new { area = "Admin" });
		}
	}
}
