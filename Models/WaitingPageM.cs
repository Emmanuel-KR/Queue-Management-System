namespace Queue_Management_System_Assignment.Models
{
    public class WaitingPageM
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public string ServicePoint { get; set; }
        public string CustomerName { get; set; }
        public DateTime CheckinTime { get; set; }

        // Constructor
        public WaitingPageM(string ticketNumber, string servicePoint, string customerName, DateTime checkinTime)
        {
            TicketNumber = ticketNumber;
            ServicePoint = servicePoint;
            CustomerName = customerName;
            CheckinTime = checkinTime;
        }
    }
}
