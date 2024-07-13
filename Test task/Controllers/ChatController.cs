using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Test_task.Models;
using Test_task.Service.UserService;
using Test_task.Service.UserServices;
using Test_task.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("getAll")]
        public IEnumerable<Chat> GetAllUser()
        {
            return _chatService.GetAllChats();
        }

        [HttpPost("createChat")]
        public IActionResult CreateChat(int userId)
        {
            string result = _chatService.CreateChat(userId);
            return Ok();
        }

        [HttpPost("deleteChat")]
        public IActionResult DeleteChat(int userId,int chatId)
        {
            string result = _chatService.DeleteChat(userId, chatId);
            return Ok();
        }

        [HttpPost("addUserToChat")]
        public IActionResult AddUserToChat(int userId, int chatId)
        {
            string result = _chatService.AddUserToChat(userId, chatId);
            return Ok();
        }

        [HttpPost("removeUserFromChat")]
        public IActionResult RemoveUserFromChat(int userId, int chatId)
        {
            string result = _chatService.RemoveUserFromChat(userId, chatId);
            return Ok();
        }
    }
}
