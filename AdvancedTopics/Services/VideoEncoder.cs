using AdvancedTopics.Models;

namespace AdvancedTopics.Services;

public class VideoEventArgs(Video video) : EventArgs
{
    public Video Video { get; init; } = video;
}

public class VideoEncoder
{
    // 1. Define a Delegate
    // 2. Define an Event based on that Delegate
    public event EventHandler<VideoEventArgs>? VideoEncoded;

    public void Encode(Video video)
    {
        Console.WriteLine($"Encoding video '{video.Title}' ...");
        Thread.Sleep(3000);
        Console.WriteLine($"Video '{video.Title}' encoded successfully.");

        // 3. Raise the Event
        OnVideoEncoded(video);
    }

    protected virtual void OnVideoEncoded(Video video)
    {
        var videoEventArgs = new VideoEventArgs(video);

        VideoEncoded?.Invoke(this, videoEventArgs);
    }
}
