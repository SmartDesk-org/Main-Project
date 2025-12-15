using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Services
{
    public interface IEmployeeEmailService
    {
        Task SendAsync(string to, string subject, string html);
    }
}
