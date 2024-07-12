using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;
using Test_task.Models;
using Test_task.Service.UserService;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //this is crud controller
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("addUser")]
        public IActionResult AddUser(string name)
        {
            string result = _userService.AddUser(new User() { Name = name });
            if (result != "ok")
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpPost("updateUser")]
        public IActionResult UpdateUser(int id, string name)
        {
            string result = _userService.UpdateUser(new User() { Id=id, Name = name });
            if (result != "ok")
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpPost("deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }


        [HttpGet("getAll")]
        public IEnumerable<User> GetAllUser()
        {
            return _userService.GetAllUsers();
        }

    }
}
