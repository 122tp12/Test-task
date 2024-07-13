using Microsoft.AspNetCore.SignalR;
using System.Text;
using Test_task.Models;
using Test_task.Service.UserService;
using Test_task.Service.UserServices;

namespace Test_task.SignalR
{
    public sealed class ComHub : Hub<IComHub>
    {
        IChatService _service;
        IUserService _userService;
        public ComHub(IChatService service, IUserService userService) {
            _service = service;
            _userService = userService;
        }

        //{"protocol":"json","version":1}
        public override async Task OnConnectedAsync()
        {
            await Clients.All.RecieveMessage($"New Member ({Context.ConnectionId}): Joined");
        }

        //{"arguments":[id],"invocationId":"0","target":"AutoriseConectionAsUser","type":1}
        public async Task<string> AutoriseConectionAsUser(int id)
        {
            return _userService.AutoriseConection(id, Context.ConnectionId);
        }
        //{"arguments":[id],"invocationId":"0","target":"RemoveConectionFromUser","type":1}
        public async Task<string> RemoveConectionFromUser(int id)
        {
            return _userService.RemoveConection(id);
        }

        //{"arguments":["Hello", sender_id, chat_id],"invocationId":"0","target":"SendMessageToChat","type":1}
        public async Task SendMessageToChat(string message, int senderId, int chatId)
        {
            List<string> cons=_service.GetUsersConnectionByChatId(chatId);
            _service.saveMessages(senderId, chatId, message);
            for (int i=0;i<cons.Count ;i++ ) {
                if (cons[i] != null)
                {
                    await Clients.User(cons[i]).RecieveMessage($"From chat{chatId}, from user{senderId}: {message}");
                }
            }
        }

        //{"arguments":["Hello", "user id"],"invocationId":"0","target":"SendMessage","type":1}
        public async Task SendDirectMessage(string message, string user)
        {
            await Clients.User(user).RecieveMessage($"{Context.ConnectionId}: {message}");
        }

        //{"arguments":[user id],"invocationId":"0","target":"CreateGroup","type":1}
        public async Task<string> CreateGroup(int userId)
        {
            return _service.CreateChat(userId);
        }

        //{"arguments":[user id, group id],"invocationId":"0","target":"AddUserToGroup","type":1}
        public async Task<string> AddUserToGroup(int userId, int groupId)
        {
            return _service.AddUserToChat(userId, groupId);
        }

        //{"arguments":[user id, group id],"invocationId":"0","target":"DeleteGroup","type":1}
        public async Task<string> DeleteGroup(int userId, int groupId)
        {
            return _service.DeleteChat(userId, groupId);
        }
    }
}
