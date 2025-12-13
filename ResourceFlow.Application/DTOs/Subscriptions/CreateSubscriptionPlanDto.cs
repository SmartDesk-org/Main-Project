namespace ResourceFlow.Application.DTOs.Subscription
{
    public class CreateSubscriptionPlanDto
    {
        public string SubscriptionName { get; set; } = null!;

        public int EmployeeLimit { get; set; }
        public int FloorLimit { get; set; }
        public int DeskLimit { get; set; }
        public int MeetingRoomLimit { get; set; }
        public double PriceMonthly { get; set; }
        public double PriceYearly { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}