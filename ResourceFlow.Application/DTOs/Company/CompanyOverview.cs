using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Company
{
    public  class CompanyOverview
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int EmployeesCount { get; set; }
        public int FloorsCount { get; set; }
        public int DesksCount { get; set; }
        public int MeetingRoomsCount { get; set; }

        public int EmployeesLimit { get; set; }
        public int FloorsLimit { get; set; }
        public int DesksLimit { get; set; }
        public int MeetingRoomsLimit { get; set; }
        public DateTime subscriptionEndDate { get; set; }
    }
}
