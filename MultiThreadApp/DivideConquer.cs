using System.Diagnostics;

namespace MultiThreadApp;

public class DivideConquer
{
    public static void Run()
    {
        try
        {
            var array = GenerateArray(numberOfElement: 500);

            var stopwatch = Stopwatch.StartNew();

            stopwatch.Start();
            int sum = ParallelSum(array: array, numberOfThreads: 5);
            stopwatch.Stop();

            Console.WriteLine($"Sum is: {sum}");
            Console.WriteLine($"Time taken: {FormatTimeSpan(stopwatch.Elapsed)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static int ParallelSum(int[] array, int numberOfThreads)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(numberOfThreads);

        int size = array.Length;
        int segmentLength = (int)Math.Ceiling(size / (double)numberOfThreads);

        var threads = new Thread[numberOfThreads];
        var partialSums = new int[numberOfThreads];

        for (int i = 0; i < numberOfThreads; i++)
        {
            int threadIndex = i;
            int start = segmentLength * i;
            int end = start + segmentLength;

            threads[i] = new Thread(() =>
            {
                partialSums[threadIndex] = CalculateSum(array, start, end);
            });
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return partialSums.Sum();
    }


    private static int CalculateSum(int[] arr, int start, int end)
    {
        if (start >= arr.Length)
        {
            return 0;
        }

        end = Math.Min(val1: end, val2: arr.Length);

        int sum = 0;

        for (int i = start; i < end; i++)
        {
            sum += arr[i];
            Thread.Sleep(50);
        }

        return sum;
    }

    private static int[] GenerateArray(int numberOfElement)
    {
        int[] arr = new int[numberOfElement];

        for (int i = 0; i < numberOfElement; i++)
        {
            arr[i] = i + 1;
        }

        return arr;
    }

    public static string FormatTimeSpan(TimeSpan timeSpan)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(timeSpan, TimeSpan.Zero);

        if (timeSpan < TimeSpan.FromSeconds(1))
            return $"{timeSpan.TotalMilliseconds:0} ms";

        if (timeSpan < TimeSpan.FromMinutes(1))
            return $"{timeSpan.TotalSeconds:0.##} s";

        if (timeSpan < TimeSpan.FromHours(1))
            return $"{timeSpan.TotalMinutes:0.##} min";

        return $"{timeSpan.TotalHours:0.##} h";
    }

}
