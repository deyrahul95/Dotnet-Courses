namespace AdvancedTopics.Services;

public class MessageService
{
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        Console.WriteLine($"[MessageService_OnVideoEncoded] Source: {source.GetType()}, Event: {e.GetType()}");
        Console.WriteLine($"[MessageService]: Sending an text message with content '{e.Video.Title} | Video Encoded Successfully' ...");
    }
}
