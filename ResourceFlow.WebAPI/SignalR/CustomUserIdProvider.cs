using Microsoft.AspNetCore.SignalR;

namespace ResourceFlow.WebAPI.SignalR
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string? GetUserId(HubConnectionContext connection)
        {
            // This tells SignalR to use the "userId" claim from your Token
            return connection.User?.FindFirst("userId")?.Value;
        }
    }
}