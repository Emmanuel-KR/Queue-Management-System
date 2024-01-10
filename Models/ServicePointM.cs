namespace Queue_Management_System_Assignment.Models
{
    public class ServicePointM
    public class ServicePointViewModel
    {
        // Properties representing data related to service operations
        // Add properties as needed for your specific use case

        public string NextNumber { get; set; }
        public string RecalledNumber { get; set; }
        public string NoShowNumber { get; set; }
        public string FinishedNumber { get; set; }
        public string TransferredNumber { get; set; }
        public List<QueueItemM> QueueItems { get; set; }

        // Other properties or operations related to service point view
    }
}
