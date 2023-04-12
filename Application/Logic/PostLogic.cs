using Application.DAOInterfaces;
using Application.LogicInterfaces;
using LoginFuncProject.Dtos;
using LoginFuncProject.Models;

namespace Application.Logic
{
    public class PostLogic : IPostLogic
    {
    
        private readonly IPostDao postDao;
        private readonly IUserDao userDao;

        public PostLogic(IPostDao postDao, IUserDao userDao)
        {
            this.postDao = postDao;
            this.userDao = userDao;
        }
        public async Task<Post> CreateAsync(PostCreationDto dto)
        {
            User? user = await userDao.GetByIdAsync(dto.OwnerId);
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }

            ValidatePost(dto);
            Post post = new Post(user, dto.Title, dto.NewText, dto.Karma);
            Post created = await postDao.CreateAsync(post);
            return created;
        }

        public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
        {
            return postDao.GetAsync(searchParameters);
        }

        private void ValidatePost(PostCreationDto dto)
        {
            if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        }
        public async Task UpdateAsync(PostUpdateDto dto)
        {
            Post? existing = await postDao.GetByIdAsync(dto.Id);

            if (existing == null)
            {
                throw new Exception($"Post with ID {dto.Id} not found!");
            }

            User? user = null;
            if (dto.OwnerId != null)
            {
                user = await userDao.GetByIdAsync((int)dto.OwnerId);
                if (user == null)
                {
                    throw new Exception($"User with id {dto.OwnerId} was not found.");
                }
            }

            User userToUse = user ?? existing.Owner;
            string titleToUse = dto.Title ?? existing.Title;
            string newTextToUse = dto.NewText ?? existing.NewText;
            int karmaToUse = dto.Karma;

            Post updated = new (userToUse, titleToUse, newTextToUse, karmaToUse)
            {
                Id = existing.Id,
            };

            ValidatePost(updated);

            await postDao.UpdateAsync(updated);
        }

        private void ValidatePost(Post dto)
        {
            if (string.IsNullOrEmpty(dto.Title + dto.NewText)) throw new Exception("Title and text cannot be empty.");
        }
    
        public async Task DeleteAsync(int id)
        {
            Post? post = await postDao.GetByIdAsync(id);
            if (post == null)
            {
                throw new Exception($"Post with ID {id} was not found!");
            }

            await postDao.DeleteAsync(id);
        }
    }
}