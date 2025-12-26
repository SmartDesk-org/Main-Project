using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.History
{
    public class HistoryResponseDto
    {
        public string? CompanyName { get; set; }
        public string? SubscriptionName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double AmountPaid { get; set; }

        public string? Status { get; set; }
        public string? Reason { get; set; }
    }


    public class HistorySpResult
    {
        public string CompanyName { get; set; }
        public string SubscriptionName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double AmountPaid { get; set; }
        public int StatusEnum { get; set; }
        public int ReasonEnum { get; set; }
    }

}
