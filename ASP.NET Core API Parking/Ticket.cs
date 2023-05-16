using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

namespace API
{



    public class Ticket
    {
        public int Id { get; set; }
        public DateTime datetimeinput { get; set; }
        public decimal tax { get; set; }
        public int numberofticket { get; set; }
        public string nr_rej { get; set; }
        public bool isPaid { get; set; }
        public int line { get; set; }
        public int place { get; set; }
        public int floor { get; set; }
        public string color { get; set; }

        public static Ticket GetTicket(string floor)
        {
            Places place = new();
            Random random = new();
            Ticket ticket = new();
            MyDbContext context = new();
            
           var block_places = context.Tickets.Count(x => x.floor == int.Parse(floor));
            if (block_places > 63)
            {
                place = place.GetPlace(floor);
                ticket.color = "Orange";
            }
            else
            {
                place.line = random.Next(1, 6);
                place.place= random.Next(1, 21);
                place.floor = int.Parse(floor);
                ticket.color = "Green";
            }
            if (place == null)
            {
                return ticket=default;
            }
            ticket.floor = place.floor;
            ticket.line = place.line;
            ticket.place = place.place;
            ticket.nr_rej = ticket.GenerateRegistrationNumber();
            ticket.datetimeinput = DateTime.Now;
            var Price = context.Price.First();
            ticket.tax = Price.price;
            ticket.numberofticket = random.Next(000000000, 999999999);
            
            

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
        
