namespace Serverapp
{
    /// <summary>
    /// Класс БД для Entity Framework с указанием адресов для отправки писем
    /// </summary>
    public class Destinationaddr
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}
