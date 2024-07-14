using Test_task.Models;
using Test_task.Service.DbServices;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1 : PageTest
    {

        [TestMethod]
        public void DbTest()
        {
            using (var context = new ApplicationDbContext())
            {
                UserDbService service = new UserDbService(context);
                User u = new User() { UserId = "qwerty" };
                service.AddUser(u);
                u = service.GetUser(u.Id).Result;
                Assert.IsNotNull(u);
            }
        }
    }
}
