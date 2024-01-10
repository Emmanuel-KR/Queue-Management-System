namespace Queue_Management_System_Assignment.Models
{
    public class ServiceProviderM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ServicePoint { get; set; }
        public int ServiceTypeId { get; set; }
    }
}
