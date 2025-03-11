using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	public class ApiMovieController : Controller
	{
		public async Task<IActionResult> Index()
		{
			List<ApiMovieViewModel> apiMovies = new List<ApiMovieViewModel>();
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
				Headers =
	{
		{ "x-rapidapi-key", "ebc6120d30mshcaba12226a713cap115b63jsn79340c9e14f1" },
		{ "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				apiMovies=JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
				return View(apiMovies);
			}
		}
	}
}
