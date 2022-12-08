using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;
using AppLibrary;
namespace Serverapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ILogger _logger;
        private DatabaseContext _db;
        public MainController(DatabaseContext databaseContext, ILogger<MainController> logger)
        {
            _logger = logger;
            _db = databaseContext;
        }
        [HttpPost("Reg")]
        public ContentResult Reg(User user)
        {
            bool check = false;
            _logger.LogInformation("database loaded(Users)");
            foreach (var item in _db.Users)
            {
                if (item.Login == user.Login)
                {
                    check = true;
                    break;
                }
            }
            if (!check)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                _logger.LogInformation(user.Login + "-registration");
                return Content("OK");
            }
            else return Content("Account already exists");
        }

        [HttpPost("Log")]
        public ContentResult Log(User user)
        {
            bool check = false;
            int authtype = 0;
            _logger.LogInformation("database loaded(Users)");
            foreach (var item in _db.Users)
            {
                if ((item.Login == user.Login) && (item.Password == user.Password))
                {
                    if (item.Type == "admin") authtype = 1;
                    check = true;
                    break;
                }
            }
            if (check && authtype == 0)
            {
                _logger.LogInformation(user.Login + "-authorization");
                return Content("Userauth");
            }
            else if (check && authtype == 1)
            {
                _logger.LogInformation(user.Login + "-authorization");
                return Content("Adminauth");
            } 
            else return Content("Wrongpass");
        }
     
    }
}
