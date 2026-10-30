using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApiDto.Dtos.AdminCategoryDtos;
using MovieApiDto.Dtos.SeriesDtos;
using Newtonsoft.Json;
using System.Text;

namespace WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSeriesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSeriesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SeriesList()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7116/api/Series");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultSeriesDto>>(jsonData);
                    return View(values);
                }
            }
            catch (Exception)
            {
                // WebApi kapalıyken veya bağlantı sağlanamadığında hata fırlatmak yerine View döndürür
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSeries()
        {
            await LoadCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesDto createSeriesDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createSeriesDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://localhost:7116/api/Series", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
                }
            }
            catch (Exception)
            {
                // Hata durumunda formu doldurulan verilerle yeniden gösterir
            }

            await LoadCategoriesAsync();
            return View(createSeriesDto);
        }

        public async Task<IActionResult> DeleteSeries(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                await client.DeleteAsync($"https://localhost:7116/api/Series/{id}");
            }
            catch (Exception)
            {
                // Hata oluşsa bile güvenle listeye yönlendirir
            }

            return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSeries(int id)
        {
            await LoadCategoriesAsync();
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://localhost:7116/api/Series/GetSeriesById?id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var value = JsonConvert.DeserializeObject<UpdateSeriesDto>(jsonData);
                    return View(value);
                }
            }
            catch (Exception)
            {
                // WebApi'ye erişilemezse listeye yönlendirir
            }

            return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesDto updateSeriesDto)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateSeriesDto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("https://localhost:7116/api/Series", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("SeriesList", "AdminSeries", new { area = "Admin" });
                }
            }
            catch (Exception)
            {
                // Hata oluşursa formu geri döndürür
            }

            await LoadCategoriesAsync();
            return View(updateSeriesDto);
        }

        private async Task LoadCategoriesAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7116/api/Categories");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<AdminResultCategoryDto>>(jsonData);
                    if (categories != null)
                    {
                        ViewBag.CategoryList = (from c in categories
                                                select new SelectListItem
                                                {
                                                    Text = c.CategoryName,
                                                    Value = c.CategoryId.ToString()
                                                }).ToList();
                        return;
                    }
                }
            }
            catch (Exception)
            {
                // WebApi kapalıysa boş liste tanımlar
            }

            ViewBag.CategoryList = new List<SelectListItem>();
        }
    }
}
