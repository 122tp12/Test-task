﻿using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Test_task.Models;

namespace Test_task.Service.DbServices
{
    public class UserDbService : IUserDbService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserDbService(ApplicationDbContext dbContext) {
            _dbContext= dbContext;
        }
        public async Task<int> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> DeleteUser(int id)
        {
            _dbContext.Users.Remove(await _dbContext.Users.FirstAsync(n=>n.Id==id));
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateUser(User user)
        {

            _dbContext.Users.Update(user);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _dbContext.Users.ToArrayAsync();
        }

        public async Task<bool> IsUserExist(int id)
        {
            return await _dbContext.Users.AnyAsync(n=>n.Id==id);
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.Include(u => u.MyChats).Include(u => u.Chats).FirstOrDefaultAsync(n => n.Id == id);
        }
    }
}
