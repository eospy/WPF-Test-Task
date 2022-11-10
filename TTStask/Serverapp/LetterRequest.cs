namespace Serverapp
{
    public class LetterRequest
    {
        public LetterRequest(int eventscount, string username)
        {
            Eventscount = eventscount;
            Username = username;
        }

        public int Eventscount { get; set; }
        public string Username { get; set; }
    }
}
