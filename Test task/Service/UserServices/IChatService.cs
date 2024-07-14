using System.Net;
using Test_task.Models;

namespace Test_task.Service.UserServices
{
    public interface IChatService
    {
        public string CreateChat(int userId);
        public IEnumerable<Chat> GetAllChats();
        public string AddUserToChat(int userId, int chatId);
        public string RemoveUserFromChat(int userId, int chatId);
        public string DeleteChat(int userId, int chatId);
        public List<string> GetUsersConnectionByChatId(int chatId, int userId);
        public string saveMessages(int userId, int chatId, string message);
        public List<string> GetAllMassages(int userId, int chatId);
    }
}
