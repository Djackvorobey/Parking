using API;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<Random>();
builder.Services.AddScoped<Ticket>();
builder.Services.AddSingleton<MyDbContext>();
builder.Services.AddSingleton<Places>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var logger = LoggerFactory.Create(config => {config.AddConsole();}).CreateLogger("Program");
var app = builder.Build();
// builder.WebHost.UseUrls("");
// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapPut("/update_tax", (string tax) => {

    MyDbContext context= new MyDbContext();

    var price = context.Price.First();

    price.price = decimal.Parse(tax);

    context.Price.Update(price);
    context.SaveChanges();
    Console.WriteLine($"Ustawiono cenę za godzinę {tax.ToString()} zł/g");

}); //Update tax in Data Base

app.MapGet("/scan_exit_ticket", (string nr_registration) =>
{

    Console.WriteLine($"Client scan ticket with number :{nr_registration}, and wait ansver");

    MyDbContext context = new MyDbContext();

    var ticket = context.Tickets.FirstOrDefault(x => x.nr_rej == nr_registration);

            if (ticket.isPaid == true)
            {
                context.Tickets.Remove(ticket);
                context.SaveChanges();
                Console.WriteLine($"Client get /scan_exit_ticket and response ticket with {ticket.nr_rej} number of registration ");

                return JsonSerializer.Serialize(ticket); 
            }
            else
            {
                Console.WriteLine($"Client get /scan_exit_ticket and response ticket null");
                 return JsonSerializer.Serialize(ticket == default);
            }

}); //Car exit barrier sensor 

app.MapGet("/scan_ticket", (string ticket_number) => {

    Console.WriteLine($"Klient zeskanował bilet o numerze {ticket_number}");

    MyDbContext context = new MyDbContext();

    var ticket = context.Tickets.FirstOrDefault(x => x.numberofticket == int.Parse(ticket_number));
  
        if (ticket.isPaid == false)
        {
            var delta = (ticket.datetimeinput - DateTime.Now) * (-1);

            if (delta.Seconds <= 15)
            { //Безплатні години паркінгу
                int free = 0;

                ticket.tax = free;
                context.SaveChanges();
                
                Console.WriteLine("Klient dostał bilet free");

                string free_ticket_serialize = JsonSerializer.Serialize(ticket);
                return free_ticket_serialize;
            }
            else
            {
                decimal cost = (decimal)delta.Seconds * ticket.tax;

                ticket.tax = cost;
                context.SaveChanges();

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

app.MapPut("/paid_ticket", (string ticket_number) =>
{
    MyDbContext context= new MyDbContext();

   var ticket = context.Tickets.FirstOrDefault(x=>x.numberofticket == int.Parse(ticket_number));

    if (ticket != null)
    {
        ticket.isPaid = true;
        Console.WriteLine($"Klient zapłacił za bilet o numerze {ticket.numberofticket.ToString()}");
        context.Tickets.Update(ticket);
        context.SaveChanges();
    }
    else
    {
        Console.WriteLine($"Nie znaleziono biletu o numerze {ticket_number}");
    }

    return JsonSerializer.Serialize(ticket);

}); //Stopover payment simulation 

app.MapGet("/get_free_places", () => {
    MyDbContext context= new MyDbContext();

    var occupied_places = context.Tickets.Count();

    int free_places = 252 - occupied_places;

    Console.WriteLine("Klient dostał wolne miejsca");

    return JsonSerializer.Serialize(free_places);

}); //Get free places from Data Base

app.MapPost("/clearDB", () => 
{
    using (var context = new MyDbContext())
    {
        try
        {
            var entities = context.Tickets.ToList();
            context.Tickets.RemoveRange(entities);
            context.SaveChanges();
            return JsonSerializer.Serialize("Data base is clear");
        }
        catch (Exception e)
        {
            return JsonSerializer.Serialize($"Error + {e}");
        }
        
    }
}); //Clear Data Base

app.MapGet("/get_ticket", (string floor, Places places) => {

    Console.WriteLine("Klient zaprosił bilet");

    MyDbContext context = new MyDbContext();
    

    var new_ticket = Ticket.GetTicket(floor);

    if (new_ticket == null)
    {
        return JsonSerializer.Serialize(new_ticket);
    }
    
    context.Add(new_ticket);
    context.SaveChanges();

    Console.WriteLine("Klient dostał bilet");

    return JsonSerializer.Serialize(new_ticket);
}); //Get the ticket 

app.MapGet("/get_all_ticket_from_db", () => {
    MyDbContext context = new MyDbContext();

    var tickets = context.Tickets.ToList();
    string nrs_reg_serialize = JsonSerializer.Serialize(tickets);
    return nrs_reg_serialize;


}); //Get all tickets from Data Base



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


