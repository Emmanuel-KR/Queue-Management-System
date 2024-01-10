namespace Queue_Management_System_Assignment.Models
{
    public class Queue
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string ServicePoint { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckinTime { get; set; }
    }
}
