using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5136);
});

builder.Services.AddSignalR();

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
