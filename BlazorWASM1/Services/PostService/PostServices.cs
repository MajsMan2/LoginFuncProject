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
        var result = await _http.GetFromJsonAsync<List<Post>>("controller");
        if (result is not null)
            Posts = result;
    }

    public async Task<Post?> GetPostById(int id)
    {
        throw new NotImplementedException();
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