using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class GuideController : Controller
	{
		GuideManager gm =new GuideManager(new EfGuideDal());
		public IActionResult Index()
		{
			var values = gm.TGetList();
			return View(values);
		}
	}
}
