//using AspNetCoreMvc_Jwt_Bearer.Models;
//using SharedProject.ViewModels;
using AspNetCoreAPI_Jwt_Bearer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AspNetCoreMvc_Jwt_Bearer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //Account controller Login ekranından alınan Username (Email) ve Password bilgileri, api/Auth metoduna POST isteği olarak gönderilir.
            //API gelen user bilgilerini doğruladıktan sonra ürettiği token bilgisini buraya (Mvc) gönderir. Bu gelen token bilgisi her istek öncesi request.Header içine eklenerek api'den listeler çekilir.
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTcyNDQ5MjExNiwiZXhwIjoxNzI0NDkyNzE2LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0In0.kIV_6FijOiQzxM5xPiN95RnBSz1dCEKmt8Ru61oBFM0";
            //Yukarıdaki manuel token bilgisini, api/Auth adresine GET isteği atarak çekebilir ve aşağıda token olarak kullanabilirsiniz.
            var http = _httpClientFactory.CreateClient();
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            var result = await http.GetAsync("https://localhost:7132/api/Employees");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(jsonData);
                return View(data);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            { return View(model); 
            }
            //var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTcyNDQ5MjExNiwiZXhwIjoxNzI0NDkyNzE2LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0In0.kIV_6FijOiQzxM5xPiN95RnBSz1dCEKmt8Ru61oBFM0";
            var http = _httpClientFactory.CreateClient();
            //http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(JwtBearerDefaults.AuthenticationScheme, token);
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await http.PostAsync("https://localhost:7132/api/Employees", content);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError(string.Empty, "Failed to create the employee. Please try again."); 
            return View(model);
        }


    }
}
