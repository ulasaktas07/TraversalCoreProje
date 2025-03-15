using BusinesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Destination
{
	public class _GuideDetails:ViewComponent
	{
		private readonly IGuideService _guideService;

		public _GuideDetails(IGuideService guideService)
		{
			_guideService = guideService;
		}
		public IViewComponentResult Invoke()
		{
			var values = _guideService.TGetById(3);
			return View(values);
		}
	}
}
