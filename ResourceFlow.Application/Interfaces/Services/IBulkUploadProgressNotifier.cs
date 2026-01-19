public interface IBulkUploadProgressNotifier
{
    Task ReportProgressAsync(
        int userId,
        int processed,
        int total
    );
}
