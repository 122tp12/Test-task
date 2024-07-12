using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Test_task.Models;

namespace Test_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public UserController(ILogger<UserController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost("addUser")]
        public ActionResult AddUser(User Model)
        {
            _dbContext.Users.Add(Model);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpGet("getAll")]
        public IEnumerable<User> GetAllUser()
        {
            return _dbContext.Users;
        }
    }
}
