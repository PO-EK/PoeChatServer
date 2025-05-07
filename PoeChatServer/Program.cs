using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR(); // 💬 Add SignalR service

var app = builder.Build();

app.MapGet("/", () => "✅ SignalR Chat Server is running");

// 🧠 Map the chat hub endpoint
app.MapHub<ChatHub>("/chatHub");

app.Run();

// 🔧 ChatHub class
public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        // Sends message to all connected clients
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
