using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{
		ContactUsManager ContactUsManager = new ContactUsManager(new EfContactUsDal());
		public IActionResult Index()
		{
			return View();
		}
	}
}
