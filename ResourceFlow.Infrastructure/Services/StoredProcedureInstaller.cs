using Dapper;
using ResourceFlow.Application.Interfaces.Logging;
using ResourceFlow.Infrastructure.Persistence.Dapper;
using System.Text.RegularExpressions;

namespace ResourceFlow.Infrastructure.Services
{
    public class StoredProcedureInstaller
    {
        private readonly DapperContext _context;
        private readonly IAppLogger<StoredProcedureInstaller> _logger;
        private readonly string _folderPath;

        public StoredProcedureInstaller(
            DapperContext context,
            IAppLogger<StoredProcedureInstaller> logger)
        {
            _context = context;
            _logger = logger;
            _folderPath = Path.Combine(
                AppContext.BaseDirectory,
                "Persistence",
                "StoredProcedures"
            );
        }

        private static IEnumerable<string> ExtractStoredProcedureNames(string sql)
        {
            // Matches CREATE or ALTER PROCEDURE statements
            var matches = Regex.Matches(
                sql,
                @"\b(CREATE|ALTER)\s+PROCEDURE\s+(\[?\w+\]?\.)?\[?(?<name>\w+)\]?",
                RegexOptions.IgnoreCase
            );

            foreach (Match match in matches)
            {
                if (match.Success)
                    yield return match.Groups["name"].Value;
            }
        }

        public async Task RunStoredProceduresAsync()
        {
            if (!Directory.Exists(_folderPath))
            {
                _logger.Warning($"Stored procedure folder not found: {_folderPath}");
                return;
            }

            var sqlFiles = Directory.GetFiles(_folderPath, "*.sql", SearchOption.AllDirectories);

            using var connection = _context.CreateConnection();

            foreach (var file in sqlFiles)
            {
                _logger.Info($"Installing stored procedure script: {Path.GetFileName(file)}");

                var sqlText = await File.ReadAllTextAsync(file);

                if (string.IsNullOrWhiteSpace(sqlText))
                {
                    _logger.Warning($"Skipped empty stored procedure script: {Path.GetFileName(file)}");
                    continue;
                }

                var batches = sqlText
                    .Split(new[] { "GO", "go", "Go" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(b => b.Trim())
                    .Where(b => !string.IsNullOrWhiteSpace(b));

                foreach (var batch in batches)
                {
                    try
                    {
                        await connection.ExecuteAsync(batch);

                        var spNames = ExtractStoredProcedureNames(batch).ToList();

                        if (spNames.Any())
                        {
                            foreach (var sp in spNames)
                                _logger.Info($"Executed stored procedure: {sp} (from file: {Path.GetFileName(file)})");
                        }
                        else
                        {
                            _logger.Info($"Executed SQL batch from file: {Path.GetFileName(file)}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.Error(ex, $"Error executing batch from file: {Path.GetFileName(file)}");
                        throw; // fail fast
                    }
                }
            }

            _logger.Info($"Stored procedure installation completed. Total files: {sqlFiles.Length}");
        }

    }
}
