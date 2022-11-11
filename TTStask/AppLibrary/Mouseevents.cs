using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLibrary
{
    public class Mouseevents
    {
        public Mouseevents(DateTime dateTime, string type, double xCoord, double yCoord)
        {
            this.dateTime = dateTime;
            Type = type;
            XCoord = xCoord;
            YCoord = yCoord;
        }

        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public string Type { get; set; }
        public double XCoord { get; set; }
        public double YCoord { get; set; }
    }
}
