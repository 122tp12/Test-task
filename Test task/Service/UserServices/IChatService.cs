using Test_task.Models;

namespace Test_task.Service.UserServices
{
    public interface IChatService
    {
        public string CreateChat(int userId);
        public IEnumerable<Chat> GetAllChats();
        public string AddUserToChat(int userId, int chatId);
    }
}
