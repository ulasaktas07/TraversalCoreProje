using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
	public class _PopularDestinations:ViewComponent
	{
		DestinationManager dm = new DestinationManager(new EfDestinationDal());
		public IViewComponentResult Invoke()
		{
			var values=dm.TGetList();
			return View(values);
		}
	}
}
