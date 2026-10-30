using Microsoft.AspNetCore.Mvc;
using MovieApiDto.Dtos.AdminCategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7116/api/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<AdminResultCategoryDto>>(jsonData);
                    return View(values);
                }
            }
            catch (Exception)
            {
                // WebApi kapalıyken veya bağlantı sağlanamadığında hata fırlatmak yerine View'ı döndürür
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AdminCreateCategoryDto categoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7116/api/Categories", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }   
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7116/api/Categories/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList","AdminCategory", new { area = "Admin" });
            }
            return RedirectToAction("CategoryList", "AdminCategory", new { area = "Admin" });
        }
    }
}
