using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski_2._0
{
    public class Ticket
    {
        public DateTime datetimeinput { get; set; }
        public decimal tax { get; set; }
        public int numberofticket { get; set; }
        public string nr_rej { get; set; }
        public bool isPaid { get; set; }
        public int line { get; set; }
        public int place { get; set; }
        public int floor { get; set; }
        public string color { get; set; }
    }
}
