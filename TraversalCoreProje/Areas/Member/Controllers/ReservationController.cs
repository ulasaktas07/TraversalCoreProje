using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
	public class ReservationController : Controller
	{
		DestinationManager dm = new DestinationManager(new EfDestinationDal());
		ReservationManager rm = new ReservationManager(new EfReservationDal());
		private readonly UserManager<AppUser> _userManager;

		public ReservationController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> MyCurrentReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = rm.GetListWithReservationByAccepted(values.Id);
			return View(valuesList);
		}
		public async Task<IActionResult> MyOldReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList = rm.GetListWithReservationByPrevious(values.Id);
			return View(valuesList);
		}
		public async Task<IActionResult> MyApprovalReservation()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			var valuesList= rm.GetListWithReservationByWaitApproval(values.Id);
			return View(valuesList);
		}
		[HttpGet]
		public IActionResult NewReservation()
		{
			List<SelectListItem> values = (from x in dm.TGetList()
										   select new SelectListItem
										   {
											   Text=x.City,
											   Value=x.DestinationID.ToString()
										   }).ToList();
			ViewBag.v = values;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> NewReservation(Reservation p)
		{
			List<SelectListItem> valuess = (from x in dm.TGetList()
										   select new SelectListItem
										   {
											   Text = x.City,
											   Value = x.DestinationID.ToString()
										   }).ToList();
			ViewBag.v = valuess;
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			p.AppUserId = values.Id;
			p.Status = "Onay Bekliyor";			
			rm.TAdd(p);
			return RedirectToAction("MyCurrentReservation", new { area = "Member" });
		}
		
	}
}
