﻿using BusinesLayer.Concrete;
using DataAccessLayer.Entity_Framework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Comment
{
	public class _CommentList:ViewComponent
	{
		CommentManager cm = new CommentManager(new EfCommentDal());
		public IViewComponentResult Invoke(int id)
		{
			var values=cm.TGetListCommentWithDestinationAndUser(id);
			ViewBag.commentCount = values.Count();
			return View(values);
		}
	}
}
