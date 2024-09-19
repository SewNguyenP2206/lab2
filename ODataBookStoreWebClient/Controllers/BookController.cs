using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ODataBookStore.Models;
using System.Net.Http.Headers;

namespace ODataBookStoreWebClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _productApiUrl;

        public BookController()
        {
            _client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            _client.DefaultRequestHeaders.Accept.Add(contentType);
            _productApiUrl = "http://localhost:50246/odata/Books"; // Ensure this is the correct URL
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _client.GetAsync(_productApiUrl);
            if (!response.IsSuccessStatusCode)
            {
                // Handle error appropriately
                return StatusCode((int)response.StatusCode, "Error fetching data");
            }

            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);

            List<Book> items = ((JArray)temp.value).Select(x => new Book
            {
                Id = (int)x["Id"],
                ISBN = (string)x["ISBN"],
                Author = (string)x["Author"],
                Title = (string)x["Title"],
                Price = (decimal)x["Price"],
            }).ToList();

            return View(items);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{_productApiUrl}({id})");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string strData = await response.Content.ReadAsStringAsync();
            Book item = JObject.Parse(strData).ToObject<Book>();

            return View(item);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ISBN,Author,Title,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PostAsJsonAsync(_productApiUrl, book);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error creating book");
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{_productApiUrl}({id})");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string strData = await response.Content.ReadAsStringAsync();
            Book item = JObject.Parse(strData).ToObject<Book>();

            return View(item);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISBN,Author,Title,Price")] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await _client.PutAsJsonAsync($"{_productApiUrl}({id})", book);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Error updating book");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _client.GetAsync($"{_productApiUrl}({id})");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string strData = await response.Content.ReadAsStringAsync();
            Book item = JObject.Parse(strData).ToObject<Book>();

            return View(item);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"{_productApiUrl}({id})");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
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
