﻿namespace Queue_Management_System_Assignment.Models
{
    public class ServiceTypeM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ServicePoint> AvailableServiceTypes { get; set; }


    }
}
