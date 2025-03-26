using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]/{id?}")]
	public class DestinationController : Controller
	{
		DestinationManager dm = new DestinationManager(new EfDestinationDal());
		public IActionResult Index()
		{
			var values = dm.TGetList();
			return View(values);
		}
		public IActionResult GetCitiesSearchByName(string searchString)
		{
			ViewData["CurrentFilter"] = searchString;
			var values=from x in dm.TGetList() select x;
			if (!string.IsNullOrEmpty(searchString))
			{
				values = values.Where(y => y.City.Contains(searchString));
			}
			return View(values.ToList());
		}
	}
}
