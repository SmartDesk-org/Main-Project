using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Logging;
using System.Diagnostics;



namespace ResourceFlow.Infrastructure.Logging
{
    public class StoredProcedureLogger:IStoredProcedureLogger
    {
        private readonly ILogger<StoredProcedureLogger> _logger;

        public StoredProcedureLogger(ILogger<StoredProcedureLogger> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync(string procedureName, Func<Task> action)
        {
            var stopwatch = Stopwatch.StartNew();

            try
            {
                _logger.LogInformation(
                    "Executing stored procedure {ProcedureName}",
                    procedureName);

                await action();

                stopwatch.Stop();

                _logger.LogInformation(
                    "Stored procedure {ProcedureName} executed successfully in {ElapsedMs} ms",
                    procedureName,
                    stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                _logger.LogError(
                    ex,
                    "Stored procedure {ProcedureName} failed after {ElapsedMs} ms",
                    procedureName,
                    stopwatch.ElapsedMilliseconds);

                throw;
            }
        }
    }
}

