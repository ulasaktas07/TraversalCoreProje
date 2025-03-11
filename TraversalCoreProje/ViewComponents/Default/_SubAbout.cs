using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
	public class _SubAbout:ViewComponent
	{
		SubAboutManager sam = new SubAboutManager(new EfSubAboutDal());
		public IViewComponentResult Invoke()
		{
			var values=sam.TGetList();
			return View(values);
		}
	}
}
