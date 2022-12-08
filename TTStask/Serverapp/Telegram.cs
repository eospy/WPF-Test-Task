using System.Net;

namespace Serverapp
{
    public class Telegram
    {
        //отправка сообщения в телеграм
        //в данном случае условный адрес, сохраненный в бд это chat id пользователя
        //бот @squumabot сможет отправлять сообщения если начать с ним диалог
        private readonly IConfiguration config;
        private static HttpClient _client;
        public Telegram(IConfiguration configuration)
        {
            _client = new HttpClient();
            this.config = configuration;
        }
        public async Task SendMessage(string text,string chatid)
        {
            string request = config["TelegramUrl"] + config["ApiToken"] + "/sendMessage?chat_id=" + chatid + "&text="+text;
            var response = await _client.PostAsync(request,null);
            Console.WriteLine(response);
        }
    }
}
