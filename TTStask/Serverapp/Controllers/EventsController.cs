using AppLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Serverapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : Controller
    {
        private readonly ILogger _logger;
        public EventsController(ILogger<MainController> logger)
        {
            _logger = logger;
        }
        [HttpPost("Sendevent")]
        public void Sendevent(Mouseevents mouseevent)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                _logger.LogInformation("database loaded(MouseEvents)");
                db.Events.Add(mouseevent);
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
            string text = ("Пользователь:" + req.Username + "-" + req.Eventscount);
            using (DatabaseContext db = new DatabaseContext())
            {
                _logger.LogInformation("database loaded(Destinationaddr)");
                foreach (var addr in db.Addresses)
                {
                    if (addr.Type == "Telegram") chatid = addr.Address;
                }
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.telegram.org/bot" + apiToken + "/sendMessage?chat_id=" + chatid + "&text=" + text);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();

        }
        [HttpPost("Recordcondition")]
        public void Recordcondition(Conditions conditions)
        {
            _logger.LogInformation("record-" + conditions.Condition);
        }
    }
}
