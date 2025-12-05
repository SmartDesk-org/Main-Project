namespace ResourceFlow.Application.DTO.Subscription
{
    public class CreateSubscriptionDto
    {
        public string Name { get; set; }
        public int MaxEmployees { get; set; }
        public int MaxDesks { get; set; }
        public int MaxMeetingRooms { get; set; }
        public int MaxCheckinsPerDay { get; set; }
        public string ExpiryType { get; set; }
        public string PlanType { get; set; }
    }
}