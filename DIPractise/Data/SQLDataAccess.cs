namespace DIPractise.Data;

public class SQLDataAccess : IDataAccess
{
    public void Signup(string username, string password)
    {
        Console.WriteLine($"User created for {username}");
        Console.WriteLine("User store in SQL database");
    }
}
