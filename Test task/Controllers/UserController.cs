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
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("addUser")]
        public int AddUser(string userId)
        {
            return _userService.AddUser(new User() { UserId = userId });
        }

        [HttpPatch("updateUser")]
        public IActionResult UpdateUser(int id, string userId)
        {
            string result = _userService.UpdateUser(new User() { Id=id, UserId = userId });
            if (result != "ok")
            {
                return BadRequest(result);
            }
            return Ok();
        }

        [HttpDelete("deleteUser")]
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
