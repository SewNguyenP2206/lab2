using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ODataBookStore.Models;
using System.Net.Http.Headers;

namespace ODataBookStoreWebClient.Controllers
{
    public class PressController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _productApiUrl;

        public PressController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _productApiUrl = "http://localhost:5015/odata/Presses";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _client.GetAsync(_productApiUrl);
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data");
            }

            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);

            List<Press> items = ((JArray)temp.value).Select(x => new Press
            {
                Id = (int)x["Id"],
                Name = (string)x["Name"],
            }).ToList();

            return View(items);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _client.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
