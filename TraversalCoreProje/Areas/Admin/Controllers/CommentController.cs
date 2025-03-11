using BusinesLayer.Abstract;
using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class CommentController : Controller
	{
		private readonly ICommentSevice _commentSevice;

		public CommentController(ICommentSevice commentSevice)
		{
			_commentSevice = commentSevice;
		}

		public IActionResult Index()
		{
			var values = _commentSevice.TGetListCommentWithDestination();
			return View(values);
		}
		public IActionResult DeletComment(int id)
		{
			var values = _commentSevice.TGetById(id);
			_commentSevice.TDelete(values);
			return RedirectToAction("Index", new {area="Admin"});
		}
	}
}
