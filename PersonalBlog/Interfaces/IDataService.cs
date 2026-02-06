using PersonalBlog.Models;

namespace PersonalBlog.Interfaces;

public interface IDataService
{
    Task CreateAsync(Post post);
    Task<List<Post>> GetPostsAsync();
}
