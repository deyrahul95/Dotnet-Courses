using System.Text.Json;
using Amazon.DynamoDBv2.DataModel;
using PersonalBlog.Interfaces;
using PersonalBlog.Models;

namespace PersonalBlog.Strategies;

public class DynamoDbDataService(
    IDynamoDBContext dBContext,
    ILogger<DynamoDbDataService> logger) : IDataService
{
    public async Task CreateAsync(Post post)
    {
        logger.LogInformation(
            "Saving post... {@Post}",
            JsonSerializer.Serialize(post));
        await dBContext.SaveAsync<Post>(post);
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        var scanConditions = new List<ScanCondition>();

        logger.LogInformation(
            "Retrieving posts.... {@ScanConditions}",
            JsonSerializer.Serialize(scanConditions));
        return await dBContext.ScanAsync<Post>(scanConditions).GetRemainingAsync();
    }
}
