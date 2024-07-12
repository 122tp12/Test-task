using Microsoft.AspNetCore.Mvc;
using Test_task.Models;
using Test_task.Service.UserService;
using Test_task.Service.UserServices;

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
            if (result != "ok")
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpPost("AddUserToChat")]
        public IActionResult AddUserToChat(int userId, int chatId)
        {
            string result = _chatService.AddUserToChat(userId, chatId);
            if (result != "ok")
            {
                return BadRequest(result);
            }
            return Ok();
        }
    }
}
