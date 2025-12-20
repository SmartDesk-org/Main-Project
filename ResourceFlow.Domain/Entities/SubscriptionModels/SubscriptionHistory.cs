using ResourceFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Domain.Entities.SubscriptionModels
{
    public class SubscriptionHistory:BaseEntity
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public int SubscriptionId { get; set; }
        public int CompanySubscriptionId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double AmountPaid { get; set; }
        public string Currency { get; set; } = "INR";

        public int Status { get; set; }

        public int ChangeReason { get; set; }

        [NotMapped]
        public SubscriptionStatus StatusEnum
        {
            get => (SubscriptionStatus)Status;
            set => Status = (int)value;
        }

        [NotMapped]
        public HistoryChangeReasonEnum ChangeReasonEnum
        {
            get => (HistoryChangeReasonEnum)ChangeReason;
            set => ChangeReason = (int)value;
        }
        
    }
}
