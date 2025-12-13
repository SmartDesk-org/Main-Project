using Dapper;
using ResourceFlow.Infrastructure.Persistence.Dapper;
using System.Data;

namespace ResourceFlow.Infrastructure.Services
{
    public class StoredProcedureInstaller
    {
        private readonly DapperContext _context;
        private readonly string _folderPath;

        public StoredProcedureInstaller(DapperContext context)
        {
            _context = context;

            // SQL files copied to output folder by csproj rule
            _folderPath = Path.Combine(AppContext.BaseDirectory, "Persistence", "StoredProcedures");
        }

        public async Task RunStoredProceduresAsync()
        {
            if (!Directory.Exists(_folderPath))
                return;

            var sqlFiles = Directory.GetFiles(_folderPath, "*.sql", SearchOption.AllDirectories);

            using var connection = _context.CreateConnection();

            foreach (var file in sqlFiles)
            {
                var sqlText = await File.ReadAllTextAsync(file);

                if (string.IsNullOrWhiteSpace(sqlText))
                    continue;

                // Split batches by GO
                var batches = sqlText
                    .Split(new[] { "GO", "go", "Go" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(batch => batch.Trim())
                    .Where(batch => !string.IsNullOrWhiteSpace(batch));

                foreach (var batch in batches)
                {
                    await connection.ExecuteAsync(batch);
                }
            }
        }

    }
}
