using BusinesLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class DestinationController : Controller
	{
		DestinationManager dm=new DestinationManager(new EfDestinationDal());
		private readonly UserManager<AppUser> _userManager;

		public DestinationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public IActionResult Index()
		{
			var values = dm.TGetList();
			return View(values);
		}
		//[HttpGet]
		public async Task<IActionResult> DestinationDetails(int id)
		{
			ViewBag.i = id;
			var value=await _userManager.FindByNameAsync(User.Identity.Name);
			ViewBag.userID = value.Id;
			var values=dm.TGetDestinationWithGuide(id);
			return View(values);
		}
		//[HttpPost]
		//public IActionResult DestinationDetails(Destination p)
		//{
		//	return View();
		//}
	}
}
