using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NewsIntegrationService.Services;
using NewsIntegrationService.Models;


namespace NewsPortal.Controllers
{    
    public class PostsController : Controller
    {
        private readonly JsonPlaceholderService _service;
        private readonly HttpClient _client;

        public PostsController(JsonPlaceholderService service, IHttpClientFactory factory) {
        _service = service;
        _client = factory.CreateClient();
        }

        public async Task<IActionResult> Index() {
        var posts = await _service.GetEnrichedPostsAsync();
        return View(posts);
        }

        public async Task<IActionResult> Details(int id) {
        var post = (await _service.GetEnrichedPostsAsync()).FirstOrDefault(p => p.Id == id);
        return post is null ? NotFound() : View(post);
        }

        [HttpPost]
        public async Task<IActionResult> React(int postId, string sentimiento) {
            var feedback = new {
                PostId = postId,
                Sentimiento = sentimiento,
                Fecha = DateTime.UtcNow
            };
            await _client.PostAsJsonAsync("https://localhost:5001/api/feedback", feedback);
            return RedirectToAction("Details", new { id = postId });
        }
    }
}