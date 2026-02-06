namespace AdvancedTopics.Models;

public class Book(string title, int price)
{
    public string Title { get; set; } = title;
    public int Price { get; set; } = price;

    public bool IsCheap()
    {
        return Price < 10;
    }
}
