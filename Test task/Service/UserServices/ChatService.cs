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
            if (!_userDbService.IsUserExist(userId).Result)
                return "User not found";

            var user = _userDbService.GetUser(userId).Result;
            return "Group Id: "+_chatDbService.CreateChat(user).Result.ToString();
        }

        public IEnumerable<Chat> GetAllChats()
        {
            return _chatDbService.GetAllChats().Result;
        }

        public string AddUserToChat(int userId, int chatId)
        {
            if (!_userDbService.IsUserExist(userId).Result)
                return "User not found";
            if (!_chatDbService.IsChatExist(chatId).Result)
                return "Chat not found";

            var user = _userDbService.GetUser(userId).Result;
            _chatDbService.AddUserToChat(chatId, user);
            return "Added";
        }

        public string RemoveUserFromChat(int userId, int chatId)
        {
            if (!_userDbService.IsUserExist(userId).Result)
                return "User not found";
            if (!_chatDbService.IsChatExist(chatId).Result)
                return "Chat not found";

            var user = _userDbService.GetUser(userId).Result;
            _chatDbService.RemoveUserFromChat(chatId, user);
            return "Added";
        }

        public string DeleteChat(int userId, int chatId)
        {
            if (!_userDbService.IsUserExist(userId).Result)
                return "User not found";

            var user = _userDbService.GetUser(userId).Result;

            if (!user.MyChats.ToList().Exists(n=>n.Id==chatId))
                return "User is not creator";
            if (!_chatDbService.IsChatExist(chatId).Result)
                return "Chat not found";

            _chatDbService.DeleteChat(chatId);
            return "deleted";
        }

        public List<string> GetUsersConnectionByChatId(int chatId, int userId)
        {
            if (!_chatDbService.IsChatExist(chatId).Result)
                throw new Exception("Chat not found");
            if (!_userDbService.IsUserExist(userId).Result)
                throw new Exception("User not found");
            if (!_chatDbService.GetChat(chatId).Result.Users.Contains(_userDbService.GetUser(userId).Result))
                throw new Exception("User not in the chat");

            Chat chatToSearch=_chatDbService.GetChat(chatId).Result;
            if (chatToSearch == null)
                return null;
            return chatToSearch.Users.Select(n => n.UserId).ToList();
        }

        public string saveMessages(int userId, int chatId, string message)
        { 
            if (!_userDbService.IsUserExist(userId).Result)
                return "User not found";
            if (!_chatDbService.IsChatExist(chatId).Result)
                return "Chat not found";

            _chatDbService.AddMessage(userId, chatId, message);
            return "saved";
        }

        public List<string> GetAllMassages(int userId, int chatId)
        {
            if (!_userDbService.IsUserExist(userId).Result)
                return new List<string>(["User not found"]);
            if (!_chatDbService.IsChatExist(chatId).Result)
                return new List<string>(["Chat not found"]);
            User u = _userDbService.GetUser(userId).Result;
            if (!_chatDbService.GetChat(chatId).Result.Users.Contains(u))
                return new List<string>(["User not in the chat"]);

            return _chatDbService.GetAllMessages(chatId).Result.Select(n=>n.UserId+": "+n.Content).ToList();
        }
    }
}
