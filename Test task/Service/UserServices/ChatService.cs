using Microsoft.AspNetCore.Http.HttpResults;
using Test_task.Models;
using Test_task.Service.DbServices;

namespace Test_task.Service.UserServices
{
    public class ChatService: IChatService
    {

        private readonly IChatDbService _chatDbService;
        private readonly IUserDbService _userDbService;
        public ChatService(IChatDbService chatDbService, IUserDbService userDbService) {
            _chatDbService = chatDbService;
            _userDbService = userDbService;
        }

        public string CreateChat(int userId)
        {
            var user=_userDbService.GetUser(userId).Result;
            if (user == null)
                return "User not found";
            return _chatDbService.CreateChat(user).Result.ToString();
        }
        public IEnumerable<Chat> GetAllChats()
        {
            return _chatDbService.GetAllChats().Result;
        }
        public string AddUserToChat(int userId, int chatId)
        {
            var user = _userDbService.GetUser(userId).Result;
            if (user == null)
                return "User not found";
            if (!_chatDbService.IsChatExist(chatId).Result)
                return "Chat not found";

            _chatDbService.AddUserToChat(chatId, user);
            return "ok";
        }
    }
}
