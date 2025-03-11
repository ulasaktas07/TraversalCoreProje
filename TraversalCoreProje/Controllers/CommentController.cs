using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentDal());
		[HttpGet]
		public PartialViewResult AddComment()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult AddComment(Comment p)
		{
			p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			p.CommentState = true;
			cm.TAdd(p);
			return RedirectToAction("Index","Destination");
		}
	}
}
