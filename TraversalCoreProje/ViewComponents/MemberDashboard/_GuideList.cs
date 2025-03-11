using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.MemberDashboard
{
	public class _GuideList : ViewComponent
	{
		GuideManager gm = new GuideManager(new EfGuideDal());
		public IViewComponentResult Invoke()
		{
			var values=gm.TGetList();
			return View(values);
		}
	}
}
