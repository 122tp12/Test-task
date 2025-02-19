﻿using Test_task.Models;

namespace Test_task.Service.UserService
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        public int AddUser(User user);
        public string UpdateUser(User user);
        public void DeleteUser(int id);
        public string AutoriseConection(int id, string con);
        public string RemoveConection(int id); 
    }
}
