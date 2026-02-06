namespace WebServer;

public class ServerOne
{
    public static void Run()
    {
        Console.WriteLine("Press 'q' or 'quit' to quit from the app!");

        while (true)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)
                || input.Equals("q", StringComparison.OrdinalIgnoreCase)
                || input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            ProcessedInput(input);
        }
    }

    private static void ProcessedInput(string input)
    {
        Thread.Sleep(2000);
        Console.WriteLine($"Processed Input: {input}");
    }
}
