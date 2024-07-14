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
            if (!_dbService.IsUserExist(user.Id).Result)
            {
                return "User not found";
            }
            _dbService.UpdateUser(user);
            return "ok";
        }

        public void DeleteUser(int id)
        {
            _dbService.DeleteUser(id);
        }

        public string AutoriseConection(int id, string con)
        {
            if (!_dbService.IsUserExist(id).Result)
            {
                User newer = new User() {UserId=con };
                _dbService.AddUser(newer);
                return "User not found, creating new user. New id is: "+newer.Id;
            }
            User u = _dbService.GetUser(id).Result;
            u.UserId= con;
            _dbService.UpdateUser(u);
            return "Autorised";
        }

        public string RemoveConection(int id)
        {
            if (!_dbService.IsUserExist(id).Result)
            {
                return "User not found";
            }
            User u = _dbService.GetUser(id).Result;
            u.UserId = null;
            _dbService.UpdateUser(u);
            return "Removed";
        }
    }
}
