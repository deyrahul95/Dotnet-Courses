using DIPractise.Data;

namespace DIPractise.Buss;

public class Business(IDataAccess da) : IBusiness
{
    public void Signup(string username, string password)
    {
        da.Signup(username, password);
    }
}
