using System.Threading.Channels;
using ResourceFlow.Application.DTOs; // Or wherever you want to store the tuple

public interface IBackgroundEmailQueue
{
    void QueueBackgroundWorkItem(string email, string subject, string htmlMessage);
    Task<(string email, string subject, string htmlMessage)> DequeueAsync(CancellationToken cancellationToken);
}

public class BackgroundEmailQueue : IBackgroundEmailQueue
{
    private readonly Channel<(string, string, string)> _queue;

    public BackgroundEmailQueue()
    {
        // Capacity 1000 to hold pending emails in memory
        var options = new BoundedChannelOptions(1000) { FullMode = BoundedChannelFullMode.Wait };
        _queue = Channel.CreateBounded<(string, string, string)>(options);
    }

    public void QueueBackgroundWorkItem(string email, string subject, string htmlMessage)
    {
        _queue.Writer.TryWrite((email, subject, htmlMessage));
    }

    public async Task<(string, string, string)> DequeueAsync(CancellationToken cancellationToken)
    {
        return await _queue.Reader.ReadAsync(cancellationToken);
    }
}