using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace API
{



    public class Ticket
    {
        
        public DateTime datetimeinput { get; set; }
        public double tax { get; set; }
        public int numberofticket { get; set; }
        public string nr_rej { get; set; }
        public bool isPaid { get; set; }
        public int line { get; set; }
        public int place { get; set; }
        public int floor { get; set; }
        public string color { get; set; }

        public Ticket GetTicket(Ticket ticket)
        {
            DataBase DB = new DataBase();
            Places place = new Places();
            Random random = new Random();

            var point = place.GetPlace();
            ticket.line = point.X;
            ticket.place = point.Y;
            ticket.nr_rej = ticket.GenerateRegistrationNumber();
            ticket.datetimeinput = DateTime.Now;
            ticket.tax = DB.GetPrice();
            ticket.numberofticket = random.Next(000000000, 999999999);
            ticket.floor = 0;
            ticket.color = "Green";

            return ticket;
        }
        public string GenerateRegistrationNumber()
        {
            string registrationNumber = "";
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "X", "Y", "Z" };
            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                registrationNumber += letters[random.Next(letters.Length)];
            }
            for (int i = 0; i < 4; i++)
            {
                registrationNumber += random.Next(10).ToString();
            }
            return registrationNumber;
        }

    }
}
        
