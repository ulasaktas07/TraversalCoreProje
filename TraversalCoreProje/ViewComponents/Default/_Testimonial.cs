using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
	public class _Testimonial:ViewComponent
	{
		TestimonialManager tm=new TestimonialManager(new EfTestimonialDal());
		public IViewComponentResult Invoke()
		{
			var values=tm.TGetList();
			return View(values);
		}
	}
}
