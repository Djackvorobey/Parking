using API;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<Random>();
builder.Services.AddScoped<Ticket>();
builder.Services.AddSingleton<DataBase>();
builder.Services.AddSingleton<Places>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var logger = LoggerFactory.Create(config => {config.AddConsole();}).CreateLogger("Program");
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapGet("/update_tax", (string tax, DataBase DB) => {

    double tax_parsed = double.Parse(tax);
    DB.UpdatePrice(tax_parsed);

    Console.WriteLine($"Ustawiono cenę za godzinę");

}); //Update tax in Data Base

app.MapGet("/scan_exit_ticket", (string nr_registration, Ticket ticket, DataBase DB) => 
{

    Console.WriteLine($"Client scan ticket with number :{nr_registration}, and wait ansver");

    ticket = DB.GetTicketFromDB_nr_reg(nr_registration);

            if (ticket.isPaid == true)
            {
                DB.DeleteTicketFromDB(nr_registration);
                bool ticket_paid = true;
                string paid_serialized = JsonSerializer.Serialize(ticket_paid);
                logger.LogWarning($"Server request {ticket_paid}");
                return paid_serialized;
            }
            else
            {
                bool ticket_no_paid = false;
                string no_paid_serialized = JsonSerializer.Serialize(ticket_no_paid);
                
                return no_paid_serialized;
            }

}); //Car exit barrier sensor

app.MapGet("/scan_ticket", (string ticket_number, Ticket ticket, DataBase DB) => {

    Console.WriteLine($"Klient zeskanował bilet o numerze {ticket_number}");

    int parsed_ticket_nr = int.Parse(ticket_number);

    ticket = DB.GetTicketFromDB_tk_nr(parsed_ticket_nr);
  
        if (ticket.isPaid == false)
        {
            var delta = (ticket.datetimeinput - DateTime.Now) * (-1);
            if (delta.Seconds <= 15)
            { //Безплатні години паркінгу
                int free = 0;
                ticket.tax = free;
                Console.WriteLine("Klient dostał bilet free");
                string free_ticket_serialize = JsonSerializer.Serialize(ticket);
                return free_ticket_serialize;
            }
            else
            {
                double cost = (double)delta.Seconds * ticket.tax;
                ticket.tax = cost;
                DB.SetTicketTax(ticket);
                Console.WriteLine("Klient dostał bilet z obliczoną należnością za postój");
                string ticket_serialized = JsonSerializer.Serialize(ticket);
                return ticket_serialized;
            }
        }
        else
        {
            Console.WriteLine($"Bilet o numerze: {ticket.numberofticket.ToString()}, już byl skanowany");
            return JsonSerializer.Serialize(ticket);
        }
    

}); //Ticket scanning

app.MapGet("/paid_ticket", (string ticket_number, Ticket ticket, DataBase DB) =>
{

        int parsed_ticket_nr = int.Parse(ticket_number);
        ticket = DB.GetTicketFromDB_tk_nr(parsed_ticket_nr);

            Console.WriteLine($"Klient zapłacił za bilet o numerze {ticket.numberofticket.ToString()}");
            ticket.isPaid = true;
        DB.SetIsPaid(ticket);
            string ticket_paided = JsonSerializer.Serialize(ticket);
            return ticket_paided;
}); //Stopover payment simulation

app.MapGet("/get_free_places", (DataBase DB) => {

    int occupied_places = DB.GetOccupiedPlaces();
    int free_places = 126 - occupied_places;
    Console.WriteLine("Klient dostał wolne miejsca");
         string free_places_serialized = JsonSerializer.Serialize(free_places);
         return free_places_serialized;
   
}); //Get free places from Data Base

app.MapGet("/get_ticket", (Ticket ticket, DataBase DB, Places places) => {

    Console.WriteLine("Klient zaprosił bilet");

        ticket.GetTicket(ticket);

        DB.SendTicketToDB(ticket);
         
        string ticked_serialize = JsonSerializer.Serialize(ticket);

    Console.WriteLine("Klient dostał bilet");

    return ticked_serialize;
}); //Get the ticket

app.MapGet("/get_all_ticket_from_db", (DataBase DB) => {

    List<Ticket> nrs_tickets = DB.GetAllTicketFromDB();
    string nrs_reg_serialize = JsonSerializer.Serialize(nrs_tickets);
    return nrs_reg_serialize;


}); //Get all tickets from Data Base



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


