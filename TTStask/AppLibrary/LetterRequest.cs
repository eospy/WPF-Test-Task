using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
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
