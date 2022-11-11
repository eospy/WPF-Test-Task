using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class User
    {
        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
            this.Type = "user";
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
    }
}
