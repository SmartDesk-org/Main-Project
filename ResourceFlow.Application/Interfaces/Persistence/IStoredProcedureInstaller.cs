using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Interfaces.Persistence
{
    public interface IStoredProcedureInstaller
    {
        Task InstallAsync();
    }
}
