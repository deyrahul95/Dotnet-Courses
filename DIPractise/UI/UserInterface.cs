using DIPractise.Buss;

namespace DIPractise.UI;

public class UserInterface(IBusiness buz) 
{
    public void Signup()
    {
        System.Console.WriteLine("Please enter username");
        var username = Console.ReadLine();
        System.Console.WriteLine("Please enter password");
        var password = Console.ReadLine();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException();
        }

        buz.Signup(username, password);
    }
}
