using DIPractise.Data;

namespace DIPractise.Buss;

public class BusinessV2(IDataAccess da) : IBusiness
{
    public void Signup(string username, string password)
    {
        if (username.Equals("username", StringComparison.OrdinalIgnoreCase)
            || password.Equals("password", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Invalid Username and Password received!");
        }

        da.Signup(username, password);
    }
}
