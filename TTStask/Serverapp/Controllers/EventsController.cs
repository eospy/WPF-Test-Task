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
        private DatabaseContext _db;
        Telegram telegram;
        public EventsController(DatabaseContext databaseContext, ILogger<MainController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _db = databaseContext;
            telegram = new Telegram(configuration);
        }
        [HttpPost("Sendevent")]
        public void SendEvent(Mouseevent mouseevent)
        {
            _logger.LogInformation("database loaded(MouseEvents)");
            _db.Events.Add(mouseevent);
            _db.SaveChanges();
        }

        [HttpPost("Sendletter")]
        public async void SendLetter(LetterRequest req)
        {
            //отправка сообщения в телеграм
            string chatid = "";
            string text = ("Пользователь:" + req.Username + "-" + req.Eventscount);
            _logger.LogInformation("database loaded(Destinationaddr)");
            foreach (var addr in _db.Addresses)
            {
                if (addr.Type == "Telegram") chatid = addr.Address;
            }
            await telegram.SendMessage(text, chatid);

        }
        [HttpPost("Recordcondition")]
        public void RecordCondition(Conditions conditions)
        {
            _logger.LogInformation("record-" + conditions.Condition);
        }
    }
}
