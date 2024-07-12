using Test_task.Models;

namespace Test_task.Service.DbServices
{
    public interface IChatDbService
    {
        public Task<Chat> GetChat(int id);
        public Task<IEnumerable<Chat>> GetAllChats();
        public Task<int> CreateChat(User user);
        public Task<int> DeleteChat(int id);
        public Task<int> AddUserToChat(int id, User user);
        public Task<int> RemoveUserFromChat(int id, User user);
        public Task<bool> IsChatExist(int id);
    }
}
