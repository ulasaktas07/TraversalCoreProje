using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	public class BookingHotelSearchController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://booking-com.p.rapidapi.com/v2/hotels/search?include_adjacency=true&checkout_date=2025-06-17&dest_id=-755070&units=metric&page_number=0&children_ages=5%2C0&room_number=1&filter_by_currency=TRY&checkin_date=2025-06-16&adults_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&locale=en-gb&children_number=2&order_by=popularity&dest_type=city"),
				Headers =
	{
		{ "x-rapidapi-key", "ebc6120d30mshcaba12226a713cap115b63jsn79340c9e14f1" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<BookingHotelSearchViewModel>(body);
				return View(values.results);

			}
		}

		[HttpGet]
		public IActionResult GetCityDestID()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> GetCityDestID(string p)
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={p}&locale=en-gb"),
				Headers =
	{
		{ "x-rapidapi-key", "ebc6120d30mshcaba12226a713cap115b63jsn79340c9e14f1" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				return View();
			}
		}
	}
}
