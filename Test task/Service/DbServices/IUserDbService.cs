using Test_task.Models;

namespace Test_task.Service.DbServices
{
    public interface IUserDbService
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<int> UpdateUser(User user);
        public Task<int> AddUser(User user);
        public Task<int> DeleteUser(int id);
        public Task<bool> IsUserExist(int id);
    }
}
