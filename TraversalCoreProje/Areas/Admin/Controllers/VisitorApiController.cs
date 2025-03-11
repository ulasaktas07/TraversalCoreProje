using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[controller]/[action]/{id?}")]
	public class VisitorApiController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public VisitorApiController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:5116/api/Visitor\r\n");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddVisitor()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddVisitor(VisitorViewModel p)
		{
			var client=_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(p);
			StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("http://localhost:5116/api/Visitor\r\n",content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", new { area = "Admin" });
			}
			return View();
		}
		public async Task<IActionResult> DeleteVisitor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"http://localhost:5116/api/Visitor/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", new { area = "Admin" });
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateVisitor(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5116/api/Visitor/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateVisitor(VisitorViewModel p)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(p);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5116/api/Visitor\r\n", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", new { area = "Admin" });
			}
			return View();
		}
	}
}
