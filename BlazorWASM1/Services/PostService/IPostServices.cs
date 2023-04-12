using LoginFuncProject.Models;

namespace BlazorWasm1.Services.PostService;

public interface IPostServices
{
    List<Post> Posts { get; set; }
    Task GetPost();
    Task<Post?> GetPostById(int id);
    Task CreatePost(Post post);
    Task UpdatePost(int id, Post post);
    Task DeletePost(int id, Post post);

}