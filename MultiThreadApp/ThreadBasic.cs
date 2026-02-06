namespace MultiThreadApp;

public class ThreadBasic
{
    public static void Run()
    {
        var thread1 = new Thread(WriteThreadId);
        thread1.Start();

        Console.WriteLine("Thread 1 Started");

        var thread2 = new Thread(WriteThreadId);
        thread2.Start();

        Console.WriteLine("Thread 2 Started");

        WriteThreadId();
    }

    
    private static void WriteThreadId()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Thread ID: {Environment.CurrentManagedThreadId}");
            Thread.Sleep(100);
        }
    }
}
