using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
	public class _Feature:ViewComponent
	{
		FeatureManager fm = new FeatureManager(new EfFeatureDal());
		public IViewComponentResult Invoke()
		{
			//var values = fm.TGetList();
			
			return View();
		}
	}
}
