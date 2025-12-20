using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.History
{
    public  class HistoryResponseDto
    {
        public string? CompanyName { get; set; }
        public string? SubscriptionName { get; set; }
       
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public double AmountPaid { get; set; }
      
        public PaymentStatus Status { get; set; }
        public HistoryChangeReasonEnum Reason { get; set; }

        public PaymentStatus statusEnum => (PaymentStatus)Status;

        public HistoryChangeReasonEnum ReasonEnum => (HistoryChangeReasonEnum)Reason;

    }
}
