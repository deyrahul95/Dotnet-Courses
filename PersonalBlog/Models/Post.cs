using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace PersonalBlog.Models;

[DynamoDBTable(DbExtensions.PostsTableName)]
public class Post
{
    [DynamoDBHashKey]
    public string Id { get; set; }

    [Required(ErrorMessage = "Post title can't be empty")]
    [MaxLength(50, ErrorMessage = "Title con't be more than 50 characters")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Post content can't be empty")]
    [MaxLength(500, ErrorMessage = "Content con't be more than 500 characters")]
    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Post()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
    }
}
