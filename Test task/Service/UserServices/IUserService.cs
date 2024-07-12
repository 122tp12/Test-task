using Test_task.Models;

namespace Test_task.Service.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        public string AddUser(User user);
        public string UpdateUser(User user);
        public void DeleteUser(int id);
    }
}
