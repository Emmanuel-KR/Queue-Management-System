namespace Queue_Management_System_Assignment.Models
{
    public class QueueM
    {
        public int QueueId { get; set; }
        public int CustomerId { get; set; }
        public int ServicePointId { get; set; }
        public int ProviderId { get; set; }
        public int TicketNumber { get; set; }
        public string Status { get; set; }
    }

}
