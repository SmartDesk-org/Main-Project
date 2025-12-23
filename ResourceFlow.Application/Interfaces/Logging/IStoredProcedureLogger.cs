using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Logging
{
    public interface IStoredProcedureLogger
    {
       
            Task ExecuteAsync(string procedureName, Func<Task> action);
        
    }

}

