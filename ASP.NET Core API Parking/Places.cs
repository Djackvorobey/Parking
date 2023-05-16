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
            { //хуйово рахує поправити йобану хуйню
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





            //for (int i = 1; i <= 126; i++)
            //{

            //    if (value == 6)
            //    {
            //        value = 0;
            //    }
            //    if (i <= 6)
            //    {
            //        Places place = new Places() { line = value, place = 1, floor = int.Parse(floor) }; // rząd i miejsce
            //        PointPriorityOne.Add(place);
            //    }
            //    if (i > 6 && i <= 12)
            //    {
            //        Places place = new Places() { line = value, Y = 21 };
            //        PointPriorityOne.Add(place);
            //    }
            //    if (i > 12 && i <= 18)
            //    {
            //        Places place = new Places() { X = value, Y = 2 };
            //        PointPriorityTwo.Add(place);
            //    }
            //    if (i > 18 && i <= 24)
            //    {
            //        Places place = new Places() { X = value, Y = 20 };
            //        PointPriorityTwo.Add(place);
            //    }
            //    if (i > 24 && i <= 30)
            //    {
            //        Places place = new Places() { X = value, Y = 3 };
            //        PointPriorityThree.Add(place);
            //    }
            //    if (i > 30 && i <= 36)
            //    {
            //        Places place = new Places() { X = value, Y = 19 };
            //        PointPriorityThree.Add(place);
            //    }
            //    if (i > 36 && i <= 42)
            //    {
            //        Places place = new Places() { X = value, Y = 4 };
            //        PointPriorityFour.Add(place);
            //    }
            //    if (i > 42 && i <= 48)
            //    {
            //        Places place = new Places() { X = value, Y = 18 };
            //        PointPriorityFour.Add(place);
            //    }
            //    if (i > 48 && i <= 54)
            //    {
            //        Places place = new Places() { X = value, Y = 5 };
            //        PointPriorityFive.Add(place);
            //    }
            //    if (i > 54 && i <= 60)
            //    {
            //        Places place = new Places() { X = value, Y = 17 };
            //        PointPriorityFive.Add(place);
            //    }
            //    if (i > 60 && i <= 66)
            //    {
            //        Places place = new Places() { X = value, Y = 6 };
            //        PointPrioritySix.Add(place);
            //    }
            //    if (i > 66 && i <= 72)
            //    {
            //        Point place = new Point() { X = value, Y = 16 };
            //        PointPrioritySix.Add(place);

            //    }
            //    if (i > 72 && i <= 78)
            //    {
            //        Point place = new Point() { X = value, Y = 7 };
            //        PointPrioritySeven.Add(place);

            //    }
            //    if (i > 78 && i <= 84)
            //    {
            //        Point place = new Point() { X = value, Y = 15 };
            //        PointPrioritySeven.Add(place);
            //    }
            //    if (i > 84 && i <= 90)
            //    {
            //        Point place = new Point() { X = value, Y = 8 };
            //        PointPriorityEight.Add(place);
            //    }
            //    if (i > 90 && i <= 96)
            //    {
            //        Point place = new Point() { X = value, Y = 14 };
            //        PointPriorityEight.Add(place);
            //    }
            //    if (i > 96 && i <= 102)
            //    {
            //        Point place = new Point() { X = value, Y = 9 };
            //        PointPriorityNine.Add(place);
            //    }
            //    if (i > 102 && i <= 108)
            //    {
            //        Point place = new Point() { X = value, Y = 13 };
            //        PointPriorityNine.Add(place);
            //    }
            //    if (i > 108 && i <= 114)
            //    {
            //        Point place = new Point() { X = value, Y = 10 };
            //        PointPriorityTen.Add(place);
            //    }
            //    if (i > 114 && i <= 120)
            //    {
            //        Point place = new Point() { X = value, Y = 12 };
            //        PointPriorityTen.Add(place);
            //    }
            //    if (i > 120 && i <= 126)
            //    {
            //        Point place = new Point() { X = value, Y = 11 };
            //        PointPriorityEleven.Add(place);
            //    }
            //    value++;
            //}

            //var queue = new PriorityQueue<List<Point>, int>();

            //queue.Enqueue(PointPriorityOne, 1);
            //queue.Enqueue(PointPriorityTwo, 2);
            //queue.Enqueue(PointPriorityThree,3);
            //queue.Enqueue(PointPriorityFour, 4);
            //queue.Enqueue(PointPriorityFive, 5);
            //queue.Enqueue(PointPrioritySix, 6);
            //queue.Enqueue(PointPrioritySeven, 7);
            //queue.Enqueue(PointPriorityEight, 8);
            //queue.Enqueue(PointPriorityNine, 9);
            //queue.Enqueue(PointPriorityTen, 10);
            //queue.Enqueue(PointPriorityEleven, 11);



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




            //point = default;
            //int block_count = 0;
            //while (priority_places.Count > 0)
            //{
            //    var PlacesList = priority_places.Dequeue();
            //    for (int i = 0; i < PlacesList.Count; i++)
            //    {
            //        var place = PlacesList[i];

            //        if (block_places.Count == 0)
            //        {
            //            point = place;
            //            return point;
            //        }

            //        var b_place = block_places[block_count];

            //        if (block_count < block_places.Count - 1)
            //        {
            //            block_count++;
            //        }
            //        if (place == b_place)
            //        {
            //            continue;
            //        }
            //        else { point = place; return point; }

            //    }
            //    if (point != default)
            //    {
            //        break;
            //    }
            //}

        }

    }
}
