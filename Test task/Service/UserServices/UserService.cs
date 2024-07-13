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

        public int AddUser(User user)
        {
            return _dbService.AddUser(user).Result;
        }

        public string UpdateUser(User user)
        {
            _dbService.UpdateUser(user);
            return "ok";
        }

        public void DeleteUser(int id)
        {
            _dbService.DeleteUser(id);
        }
    }
}
