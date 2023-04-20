using System.Net;
using LoginFuncProject.Models;

namespace BlazorWasm1.Services.PostService;

public class PostServices : IPostServices
{
    private readonly HttpClient _http;
    
    public PostServices(HttpClient http)
    {
        _http = http;
    }
    
    public List<Post> Posts { get; set; } = new List<Post>();
    
    public async Task GetPost()
    {
        var result = await _http.GetFromJsonAsync<ICollection<Post>>("controller");
        if (result is not null)
            Posts = (List<Post>) result;
    }

    public async Task<Post?> GetPostById(int id)
    {
        var result = await _http.GetAsync($"post/{id}");
        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Post>();
        }

        return null;
    }

    public async Task CreatePost(Post post)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePost(int id, Post post)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePost(int id, Post post)
    {
        throw new NotImplementedException();
    }
}