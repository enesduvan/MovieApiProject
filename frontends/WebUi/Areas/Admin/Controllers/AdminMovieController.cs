using Microsoft.AspNetCore.Mvc;
using MovieApiDto.Dtos.AdminMovieDtos;
using Newtonsoft.Json;
using System.Text;

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
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7116/api/Movies");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<List<AdminResultMovieDto>>(jsonData);
                    return View(value);
                }
            }
            catch (Exception)
            {
                // WebApi kapalıyken veya bağlantı sağlanamadığında hata fırlatmak yerine View'ı döndürür
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(AdminCreateMovieDto movieDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(movieDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Movies", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteMovie(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Movies/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("MovieList","AdminMovie", new { area = "Admin" });
            }
            return RedirectToAction("MovieList", "AdminMovie", new { area = "Admin" });
        }

    }

}
