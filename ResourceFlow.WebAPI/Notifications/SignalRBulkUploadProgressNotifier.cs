using Microsoft.AspNetCore.SignalR;

public class SignalRBulkUploadProgressNotifier
    : IBulkUploadProgressNotifier
{
    private readonly IHubContext<UploadProgressHub> _hub;

    public SignalRBulkUploadProgressNotifier(
        IHubContext<UploadProgressHub> hub)
    {
        _hub = hub;
    }

    public async Task ReportProgressAsync(
        int processed,
        int total,
        int userId)
    {
        int percent = (processed * 100) / total;

        await _hub.Clients
            .User(userId.ToString())
            .SendAsync("UploadProgress", percent);
    }
}
