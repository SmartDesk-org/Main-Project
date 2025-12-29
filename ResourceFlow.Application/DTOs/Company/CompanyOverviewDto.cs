using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.DTOs.Company
{
    public class CompanyOverviewDto
    {
        public int CompanyId { get; set; }
        public string Name { get;set;}
        public int MaxEmployees { get;set;}
        public int MaxFloors { get;set;}
        public int MaxDesks { get;set;}
        public int MaxMeetingRooms { get;set;}

        public int CurrentEmployees { get; set; }
        public int CurrentFloors { get; set; }
        public int CurrentDesks { get; set; }
        public int CurrentMeetingRooms { get; set; }
       
         
    }
}
