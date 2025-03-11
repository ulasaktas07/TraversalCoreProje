using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[AllowAnonymous]
	[Area("Member")]
	public class DestinationController : Controller
	{
		DestinationManager dm=new DestinationManager(new EfDestinationDal());
		public IActionResult Index()
		{
			var values = dm.TGetList();
			return View(values);
		}
	}
}
