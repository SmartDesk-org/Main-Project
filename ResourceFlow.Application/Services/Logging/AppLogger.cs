using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceFlow.Application.Services.Logging
{
    public class AppLogger<T>:IAppLogger<T> where T : class
    {
        private readonly ILogger<T> _logger;

        public AppLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Info(string message)
        {
            _logger.LogInformation(message);
        }

        public void Warning(string message)
        {
            _logger.LogWarning(message);
        }

        public void Error(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }
    }
}
