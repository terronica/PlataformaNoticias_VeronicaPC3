using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using NewsIntegrationService.Models;

namespace NewsIntegrationService.Services
{
    public class JsonPlaceholderService
    {
        private readonly HttpClient _http;
        public JsonPlaceholderService(HttpClient http) => _http = http;

        public async Task<List<PostEnriched>> GetEnrichedPostsAsync() {
        var posts = await _http.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
        var users = await _http.GetFromJsonAsync<List<User>>("https://jsonplaceholder.typicode.com/users");
        var comments = await _http.GetFromJsonAsync<List<Comment>>("https://jsonplaceholder.typicode.com/comments");

        return posts.Select(p => new PostEnriched {
            Id = p.Id,
            Title = p.Title,
            Body = p.Body,
            Author = users.FirstOrDefault(u => u.Id == p.UserId)?.Name ?? "Desconocido",
            Comments = comments.Where(c => c.PostId == p.Id).Select(c => c.Body).ToList()
        }).ToList();
    }
    

    }
}