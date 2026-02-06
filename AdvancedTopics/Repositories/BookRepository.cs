using AdvancedTopics.Models;

namespace AdvancedTopics.Repositories;

public class BookRepository
{
    private readonly List<Book> _books = [
        new Book("Advanced C# Guide", 17),
        new Book("C# 14 and .NET 10", 7),
        new Book("Asynchrony Programming using C#", 5)
    ];
    public List<Book> GetBooks()
    {
        return _books;
    }
}
