using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Test_task.Models;
using Test_task.Service.DbServices;

namespace Test_task.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserDbService _dbService;
        public UserService(IUserDbService dbService)
        {
            _dbService = dbService;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbService.GetUsers().Result;
        }

        public string AddUser(User user)
        {
            if (user.Name.Length > 20 || user.Name.Length < 2)
                return "Wrong name";
            
            _dbService.AddUser(user);
            return "ok";
        }

        public string UpdateUser(User user)
        {
            if (user.Name.Length > 20 || user.Name.Length < 2)
                return "Wrong name";
            if (!_dbService.IsUserExist(user.Id).Result)
                return "User not found";

            _dbService.UpdateUser(user);
            return "ok";
        }

        public void DeleteUser(int id)
        {
            _dbService.DeleteUser(id);
        }
    }
}
