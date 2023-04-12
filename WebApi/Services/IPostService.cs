using LoginFuncProject.Dtos;
using LoginFuncProject.Models;

namespace WebApi.Services;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(string? userName, int? userId, bool? completedStatus, string? titleContains, string? textContains);

    Task UpdateAsync(PostUpdateDto dto);

    Task<PostBasicDto> GetByIdAsync(int id);

    Task DeleteAsync(int id);
}