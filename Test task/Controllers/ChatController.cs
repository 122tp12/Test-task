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
        [HttpPost("sendMessage")]
        public async void SendMessage(IHubContext<ComHub, IComHub> context)
        {
            await context.Clients.All.RecieveMessage("message");
            Console.WriteLine("send");
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
