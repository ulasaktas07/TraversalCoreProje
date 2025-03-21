﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Member.Models;

namespace TraversalCoreProje.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[controller]/[action]")]
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditModel userEditModel=new UserEditModel();
			userEditModel.name = values.Name;
			userEditModel.surname = values.Surname;
			userEditModel.phonenumber = values.PhoneNumber;
			userEditModel.mail = values.Email;
			return View(userEditModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditModel p) 
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			if (p.Image!=null)
			{
				var resource = Directory.GetCurrentDirectory();
				var extension = Path.GetExtension(p.Image.FileName);
				var imagename = Guid.NewGuid() + extension;
				var savelocation = resource + "/wwwroot/userimages/" + imagename;
				var stream=new FileStream(savelocation,FileMode.Create);
				await p.Image.CopyToAsync(stream);
				user.ImageUrl = imagename;
			}
			user.Name = p.name;
			user.Surname = p.surname;
			user.PhoneNumber=p.phonenumber;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
			var result=await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}
