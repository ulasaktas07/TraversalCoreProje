using BusinesLayer.Abstract;
using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		private readonly IContactUsService _contactUsService;

		public ContactController(IContactUsService contactUsService)
		{
			_contactUsService = contactUsService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(SendMessageDto model)
		{
			if (ModelState.IsValid)
			{
				_contactUsService.TAdd(new ContactUs()
				{
					Name = model.Name,
					Mail = model.Mail,
					Subject = model.Subject,
					MessageBody = model.MessageBody,
					MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
					MessageStatus = true
				});
				return RedirectToAction("Index","Default");
			}
			return View(model);
		}
	}
}
