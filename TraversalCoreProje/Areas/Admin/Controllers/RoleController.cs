﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;
		public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			var values=_roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
		public IActionResult CreateRole()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
		{
			AppRole role = new AppRole()
			{
				Name = createRoleViewModel.RoleName
			};
			var result = await _roleManager.CreateAsync(role);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", new { area = "Admin" });
			}
			else {
				return View();
			}
		
		}
		public async Task<IActionResult> DeleteRole(int id)
		{
			var value=_roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
			return RedirectToAction("Index",new { area = "Admin" });
		}
		[HttpGet]
		public IActionResult UpdateRole(int id)
		{
			var value=_roleManager.Roles.FirstOrDefault(x => x.Id == id);
			UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel
			{
				RoleID = value.Id,
				RoleName = value.Name
			};
			return View(updateRoleViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleID);
			value.Name = updateRoleViewModel.RoleName;
			await _roleManager.UpdateAsync(value);
			return RedirectToAction("Index", new { area = "Admin" });
		}
		public IActionResult UserList()
		{
			var values=_userManager.Users.ToList();
			return View(values);
		}
		public async Task<IActionResult> AssignRole(int id)
		{
			var user=_userManager.Users.FirstOrDefault(x => x.Id == id);
			TempData["UserId"] = user.Id;
			var roles = _roleManager.Roles.ToList();
			var userRoles = await _userManager.GetRolesAsync(user);
			List<RoleAssignViewModel> roleAssignViewModels= new List<RoleAssignViewModel>();
			foreach(var item in roles)
			{
				RoleAssignViewModel model=new RoleAssignViewModel();
				model.RoleId = item.Id;
				model.RoleName = item.Name;
				model.RoleExist= userRoles.Contains(item.Name);
				roleAssignViewModels.Add(model);
			}
			return View(roleAssignViewModels);
		}
		[HttpPost]
		public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
		{
			var userid =(int)TempData["UserId"];
			var user =_userManager.Users.FirstOrDefault(x => x.Id == userid);
			foreach (var item in model)
			{
				if(item.RoleExist)
				{
					await _userManager.AddToRoleAsync(user, item.RoleName);
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.RoleName);
				}
			}
			return RedirectToAction("UserList", new { area = "Admin" });
		}	
	}
}
