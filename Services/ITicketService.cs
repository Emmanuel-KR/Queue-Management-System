using Queue_Management_System_Assignment.Models;

namespace Queue_Management_System_Assignment.Services
{
    public interface ITicketService
    {
        byte[] GenerateTicket(ServiceTypeM selectedService); // Define the method to generate a ticket
        Task<List<ServiceTypeM>> GetAvailableServicesAsync();
        ServiceTypeM GetServiceDetails(int selectedServiceId); // Define method to get service details
        string SaveTicketToFile(byte[] ticketBytes); // Define method to save ticket to a file
        Task<bool> CheckInAsync(string TicketNumber, string serviceName, string customerName);
    }
}
