using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Serverapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ILogger _logger;
        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        //POST api/<ValuesController>
        [HttpPost("Reg")]
        public ContentResult Reg(User user)
        {
            bool check = false;
            using (UserContext db =new UserContext())
            {
                _logger.LogInformation("database loaded(Users)");
                foreach (var item in db.Users) 
                {
                    if (item.Login == user.Login)
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    _logger.LogInformation(user.Login+"-registration");
                    return Content("OK");
                }
                else return Content("Account already exists");

                
            }
        }

        [HttpPost("Log")]
        public ContentResult Log(User user)
        {
            bool check = false;
            int authtype = 0;
            using (UserContext db = new UserContext())
            {
                _logger.LogInformation("database loaded(Users)");
                foreach (var item in db.Users)
                {
                    if ((item.Login == user.Login)&&(item.Password==user.Password))
                    {
                        if(item.Type=="admin") authtype=1;
                        check = true;
                        break;
                    }
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
        [HttpPost("Sendevent")]
        public void Sendevent(Mouseevents mouseevent)
        {
            using (MouseEventsContext db =new MouseEventsContext())
            {
                _logger.LogInformation("database loaded(MouseEvents)");
                db.Mouseevents.Add(mouseevent);
                db.SaveChanges();
            }
           
        }
       
        [HttpPost("Sendletter")]
        public void Sendletter(LetterRequest req)
        {
            //отправка сообщения в телеграм
            //в данном случае условный адрес, сохраненный в бд это chat id пользователя
            //бот @squumabot сможет отправлять сообщения если начать с ним диалог
            string apiToken = "2081068774:AAGxkq57ZRl9oCD_I0OIa1eacrP0MOf3WQw";
            string chatid = "";
            string text = ("Пользователь:"+req.Username+"-"+req.Eventscount);
            using(DestinationaddrContext db = new DestinationaddrContext())
            {
                _logger.LogInformation("database loaded(Destinationaddr)");
                foreach (var addr in db.Adresses)
                {
                    if(addr.Type == "Telegram") chatid=addr.Address;
                }
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + apiToken + "/sendMessage?chat_id=" + chatid + "&text=" + text);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
            
        }
        [HttpPost("Recordcondition")]
        public void Recordcondition(Conditions conditions)
        {
            _logger.LogInformation("record-"+conditions.Condition);
        }
    }
}
