using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(); // 💬 Add SignalR service

var app = builder.Build();

app.MapGet("/", () => "✅ SignalR Chat Server is running");

app.MapHub<ChatHub>("/chatHub");

app.Run();

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
