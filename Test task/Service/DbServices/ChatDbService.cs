using Microsoft.EntityFrameworkCore;
using Test_task.Models;

namespace Test_task.Service.DbServices
{
    public class ChatDbService : IChatDbService
    {
        private readonly ApplicationDbContext _dbContext;
        public ChatDbService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddMessage(int userId, int chatId, string message)
        {
            await _dbContext.Messages.AddAsync(new Message() { UserId = userId, ChatId = chatId, Content = message });
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Message>> GetAllMessages(int chatId)
        {
            return _dbContext.Messages.Where(n=>n.ChatId==chatId).ToList();
        }

        public async Task<IEnumerable<Chat>> GetAllChats()
        {
            return await _dbContext.Chats.ToArrayAsync();
        }

        public async Task<bool> IsChatExist(int id)
        {
            return await _dbContext.Chats.AnyAsync(n => n.Id == id);
        }

        async public Task<int> RemoveUserFromChat(int id, User user)
        {
            Chat tmp = await _dbContext.Chats.Include(u => u.Users).FirstOrDefaultAsync(n => n.Id == id);
            tmp.Users.Remove(user);
            _dbContext.Chats.Update(tmp);
            return await _dbContext.SaveChangesAsync();
        }

        async Task<int> IChatDbService.AddUserToChat(int id, User user)
        {
            Chat tmp=await _dbContext.Chats.Include(u => u.Users).FirstOrDefaultAsync(n=>n.Id==id);
            tmp.Users.Add(user);
            _dbContext.Chats.Update(tmp);
            return await _dbContext.SaveChangesAsync();
        }

        async Task<int> IChatDbService.CreateChat(User user)
        {
            List<User> tmp=new List<User>(new User[] { user });
            Chat chat = new Chat() { Creator = user, Users = tmp };
            await _dbContext.Chats.AddAsync(chat);
            await _dbContext.SaveChangesAsync();
            return chat.Id;
        }

        async Task<int> IChatDbService.DeleteChat(int id)
        {
            _dbContext.Chats.Remove(await _dbContext.Chats.FirstAsync(n => n.Id == id));
            return await _dbContext.SaveChangesAsync();
        }

        async Task<Chat> IChatDbService.GetChat(int id)
        {
            return await _dbContext.Chats.Include(u=>u.Users).Include(u => u.Messages).FirstOrDefaultAsync(n=>n.Id==id);
        }
    }
}
