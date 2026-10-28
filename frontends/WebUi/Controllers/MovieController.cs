using Microsoft.AspNetCore.Mvc;
using MovieApiDto.Dtos.MovieDtos;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebUi.Controllers
{
    public class MovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> MovieList()
        {
            ViewBag.v1 = "Film Listesi"; 
            ViewBag.v2 = "Ana Sayfa"; 
            ViewBag.v3 = "Tüm Filmler"; 
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Movies");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultMovieDto>>(jsonData);
                return View(value);
            }
            else
            {
                // Handle error response
                return View();
            }
            return View();
        }

        public async Task<IActionResult> MovieDetail(int id)
        {
            id = 0;
            ViewBag.v1 = "Film Listesi";
            ViewBag.v2 = "Ana Sayfa";
            ViewBag.v3 = "Tüm Filmler";
            return View();
        }
    }
}
