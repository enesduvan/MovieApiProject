using Microsoft.AspNetCore.Mvc;
using MovieApiDto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;

namespace WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMovieController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminMovieController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> MovieList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7116/api/Movies");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);
                return View(value);
            }
            else
            {
                // Handle error response
                return View();
            }
        }
    }
}
