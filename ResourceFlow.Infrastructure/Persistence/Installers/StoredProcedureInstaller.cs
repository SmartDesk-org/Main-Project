using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ResourceFlow.Application.Interfaces.Persistence;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ResourceFlow.Infrastructure.Persistence.Installers
{
    public class StoredProcedureInstaller : IStoredProcedureInstaller
    {
        private readonly ILogger<StoredProcedureInstaller> _logger;
        private readonly IConfiguration _configuration;

        public StoredProcedureInstaller(
            ILogger<StoredProcedureInstaller> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InstallAsync()
        {
            _logger.LogInformation("Starting stored procedure installation...");

            // Detect the output folder dynamically
            var rootPath = Path.Combine(AppContext.BaseDirectory, "StoredProcedures");

            if (!Directory.Exists(rootPath))
            {
                _logger.LogWarning("StoredProcedures folder not found at {Path}", rootPath);
                return;
            }

            // Get all .sql files in the folder, ordered
            var files = Directory.GetFiles(rootPath, "*.sql")
                                 .OrderBy(f => f)
                                 .ToList();

            _logger.LogInformation("Found {Count} SQL scripts to execute.", files.Count);

            if (!files.Any())
            {
                _logger.LogWarning("No SQL scripts found in StoredProcedures folder.");
                return;
            }

            using var connection = new SqlConnection(
                _configuration.GetConnectionString("DefaultConnection"));
            await connection.OpenAsync();

            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                try
                {
                    _logger.LogInformation("Executing stored procedure script: {File}", fileName);

                    var sql = await File.ReadAllTextAsync(file);

                    // Split by GO statements and execute each batch
                    var batches = SplitSqlBatches(sql);

                    foreach (var batch in batches)
                    {
                        if (string.IsNullOrWhiteSpace(batch))
                            continue;

                        using var command = new SqlCommand(batch, connection)
                        {
                            CommandType = CommandType.Text
                        };

                        await command.ExecuteNonQueryAsync();
                    }

                    _logger.LogInformation("Successfully executed script: {File}", fileName);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Failed while executing script: {File}", fileName);
                    throw; // stop on first failure
                }
            }

            _logger.LogInformation("Stored procedure installation complete.");
        }

        private static List<string> SplitSqlBatches(string sql)
        {
            // Split by GO statement (case-insensitive, whole word, can have whitespace)
            var batches = Regex.Split(
                sql,
                @"^\s*GO\s*$",
                RegexOptions.IgnoreCase | RegexOptions.Multiline
            );

            return batches
                .Where(b => !string.IsNullOrWhiteSpace(b))
                .Select(b => b.Trim())
                .ToList();
        }
    }
}