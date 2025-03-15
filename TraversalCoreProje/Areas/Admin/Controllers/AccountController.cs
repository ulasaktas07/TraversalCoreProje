using BusinesLayer.Abstract.Abstract_Uow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]

	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(AccountViewModel model)
		{
			var valueSender = _accountService.TGetById(model.SenderID);
			var valueReceiver = _accountService.TGetById(model.ReceiverID);

			valueSender.Balance -= model.Amount;
			valueReceiver.Balance += model.Amount;

			List<Account> modifiedAccounts = new List<Account>()
			{
				valueSender,
				valueReceiver
			};

			_accountService.TMultiUpdate(modifiedAccounts);
			return View();
		}
	}
}
