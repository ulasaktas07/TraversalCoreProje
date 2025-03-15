using BusinesLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
	{
		DestinationManager dm=new DestinationManager(new EfDestinationDal());
		public IActionResult Index()
		{
			var values = dm.TGetList();
			return View(values);
		}
		[HttpGet]
		public IActionResult DestinationDetails(int id)
		{
			ViewBag.i = id;
			var values=dm.TGetById(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult DestinationDetails(Destination p)
		{
			return View();
		}
	}
}
