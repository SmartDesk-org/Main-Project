using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ResourceFlow.Application.Common;
using ResourceFlow.Application.Interfaces.Services;

public class EmailBackgroundWorker : BackgroundService
{
    private readonly IBackgroundEmailQueue _queue;
    private readonly IServiceProvider _serviceProvider;

    public EmailBackgroundWorker(IBackgroundEmailQueue queue, IServiceProvider serviceProvider)
    {
        _queue = queue;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem = await _queue.DequeueAsync(stoppingToken);
            var (email, subject, html) = workItem; // Deconstruct the tuple

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var emailService = scope.ServiceProvider.GetRequiredService<IEmployeeEmailService>();

                    Console.WriteLine($"🚀 Attempting to send to {email}...");
                    await emailService.SendAsync(email, subject, html);

                    // Success! Wait a bit to be nice to the server.
                    await Task.Delay(1000, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ FAILED sending to {email}: {ex.Message}");

                // CRITICAL: Don't lose the email! Put it back in the queue.
                Console.WriteLine($"⚠️ Re-queuing {email} to try again later...");
                _queue.QueueBackgroundWorkItem(email, subject, html);

                // If we hit a limit, we MUST pause. 
                // Wait 1 minute before picking up the next item to let the server cool down.
                Console.WriteLine("⏳ Pausing worker for 60 seconds...");
                await Task.Delay(TimeSpan.FromSeconds(60), stoppingToken);
            }
        }
    }
}