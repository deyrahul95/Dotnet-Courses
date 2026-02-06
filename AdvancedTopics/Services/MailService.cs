namespace AdvancedTopics.Services;

public class MailService
{
    public void OnVideoEncoded(object source, VideoEventArgs e)
    {
        Console.WriteLine($"[MailService_OnVideoEncoded] Source: {source.GetType()}, Event: {e.GetType()}");
        Console.WriteLine($"[MailService]: Sending an email with title '{e.Video.Title} | Video Encoded Successfully' ...");
    }
}
