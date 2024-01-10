using Queue_Management_System_Assignment.Models;

namespace Queue_Management_System_Assignment.Services
{
    public interface IRepository
    {
        Task<List<ServiceTypeM>> GetAvailableServicesAsync();
    }
}
