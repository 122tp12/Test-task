using Microsoft.AspNetCore.SignalR;
using System.Text;
using Test_task.Models;
using Test_task.Service.UserServices;

namespace Test_task.SignalR
{
    public sealed class ComHub : Hub<IComHub>
    {
        IChatService _service;
        public ComHub(IChatService service) {
            _service = service;
        }
        //{"protocol":"json","version":1}
        public override async Task OnConnectedAsync()
        {
            await Clients.All.RecieveMessage($"New Member ({Context.ConnectionId}): Joined");
        }
        //{"arguments":["Hello"],"invocationId":"0","target":"SendMessage","type":1}
        public async Task SendMessage(string message)
        {
            await Clients.All.RecieveMessage($"{Context.ConnectionId}: {message}");
        }
        //{"arguments":["Hello", "user id"],"invocationId":"0","target":"SendMessage","type":1}
        public async Task SendDirectMessage(string message, string user)
        {
            await Clients.User(user).RecieveMessage($"{Context.ConnectionId}: {message}");
        }
        //{"arguments":["user id"],"invocationId":"0","target":"CreateGroup","type":1}
        public async Task<string> CreateGroup(int userId)
        {
            string id=_service.CreateChat(userId);
            return $"Group Id: {id}";
        }
    }
}
