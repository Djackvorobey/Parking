using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Numerics;
using System.Windows.Markup;
using System.Linq;

namespace API
{
    public class Places
    {
        public int floor {get; set;}
        public int line { get; set; }
        public int place { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Places other = (Places)obj;
            return floor == other.floor && line == other.line && place == other.place;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(floor, line, place);
        }
        public Places GetOnePlace(int floor, int line , int place )
        {
            Places Place = new Places() { line = line, place = place, floor = floor };
            return Place;
        }
        public static PriorityQueue<List<Places>,int> GetPriorityPlace(string floor)
        {
            

            List<List<Places>> allPriorityPlaces = new List<List<Places>>();
            for (int i = 0; i <= 10; i++)
            {
                List<Places> PointPriority = new List<Places>();
                allPriorityPlaces.Add(PointPriority);
            }
           

            int placeStart = 1; //max 11
            int placeEnd = 21; //min 12
            
            int line = 1;
            int current_place = 1;
            Places place = new Places();
            for (int i = 0; i <=allPriorityPlaces.Count; i++)
            { 
                if (i == 10 )
                {
                    line = 1;
                    for (int z = 0; z <= 6; z++)
                    {
                        place = place.GetOnePlace(int.Parse(floor), line, placeStart);
                        allPriorityPlaces[i].Add(place);
                        line++;
                        if (line == 7)
                        {
                            break;
                        }


                    }
                    
                    break;
                }
                else
                {
                    for (int a = 1; a <= 12; a++)
                    {
                    
                        switch (current_place)
                        {
                            case var number when number <= 6:
                               place = place.GetOnePlace(int.Parse(floor), line, placeStart);
                                allPriorityPlaces[i].Add(place);
                                line++;
                                if (line == 7)
                                {
                                    line = 1;
                                    if (placeStart <= 11)
                                    {
                                        placeStart++;
                                    }
                                
                                
                                }
                            
                                break;
                            case var number when number > 6 && number <= 12:
                               place = place.GetOnePlace(int.Parse(floor), line, placeEnd);
                                allPriorityPlaces[i].Add(place);
                                line++;
                                if (line == 7)
                                {
                                    line = 1;
                                    if (placeEnd >= 12)
                                    {
                                        placeEnd--;
                                    }
                                }
                            
                                break;
                        }
                        if (current_place == 12)
                        {
                            current_place = 1;
                        }
                        else
                        {
                            current_place++;
                        }
                    }

                }
            }

            var queue = new PriorityQueue<List<Places>, int>();
            for (int i = 0; i < allPriorityPlaces.Count; i++)
            {
                queue.Enqueue(allPriorityPlaces[i], i);
            }
            

            return queue;


        }

        public Places GetPlace(string floor)
        { 
            Places place = new();
            MyDbContext context = new();
            List<Places> block_places = new();
            List<Places> all_places = new();
            var tickets = context.Tickets.ToList();

            foreach (var ticket in tickets)
            {
                Places places = new();
                places.floor = ticket.floor;
                places.line = ticket.line;
                places.place = ticket.place;
                block_places.Add(places);
            }

            var priority_places = Places.GetPriorityPlace(floor);

            for (int i = 0; i <= 10; i++)
            {
                all_places = priority_places.Dequeue();

                for (int a = 0; a < all_places.Count; a++)
                {
                    all_places.RemoveAll(x => block_places.Contains(x));
                    
                    if (all_places.Count >0)
                    {
                       place = all_places.First();
                        return place;
                    }
                }
               
            }

            Console.WriteLine("Nie znaleziono wolnego miejsca na parkingu");
            return default;


        }

    }
}
