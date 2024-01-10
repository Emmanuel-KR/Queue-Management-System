namespace Queue_Management_System_Assignment.Services
{
    public interface IAuthentication
    {
        ServiceProvider GetServiceProviderByUsername(string username);

        bool AuthenticateServiceProvider(string username, string providedPassword);
    }
}
