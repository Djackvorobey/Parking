using Microsoft.AspNetCore.Mvc.TagHelpers;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Numerics;
using System.Windows.Markup;

namespace API
{
    public class Places
    {
        

        public PriorityQueue<List<Point>,int> GetPriorityPlace()
        {
            List<Point> PointPriorityOne = new List<Point>();
            List<Point> PointPriorityTwo = new List<Point>();
            List<Point> PointPriorityThree = new List<Point>();
            List<Point> PointPriorityFour = new List<Point>();
            List<Point> PointPriorityFive = new List<Point>();
            List<Point> PointPrioritySix = new List<Point>();
            List<Point> PointPrioritySeven = new List<Point>();
            List<Point> PointPriorityEight = new List<Point>();
            List<Point> PointPriorityNine = new List<Point>();
            List<Point> PointPriorityTen = new List<Point>();
            List<Point> PointPriorityEleven = new List<Point>();

            int value = 0;

            for (int i = 1; i <= 126; i++)
            {

                if (value == 6)
                {
                    value = 0;
                }
                if (i <= 6)
                {
                    Point place = new Point() { X = value, Y = 1 }; // rzad i miejsce
                    PointPriorityOne.Add(place);
                }
                if (i > 6 && i <= 12)
                {
                    Point place = new Point() { X = value, Y = 21 };
                    PointPriorityOne.Add(place);
                }
                if (i > 12 && i <= 18)
                {
                    Point place = new Point() { X = value, Y = 2 };
                    PointPriorityTwo.Add(place);
                }
                if (i > 18 && i <= 24)
                {
                    Point place = new Point() { X = value, Y = 20 };
                    PointPriorityTwo.Add(place);
                }
                if (i > 24 && i <= 30)
                {
                    Point place = new Point() { X = value, Y = 3 };
                    PointPriorityThree.Add(place);
                }
                if (i > 30 && i <= 36)
                {
                    Point place = new Point() { X = value, Y = 19 };
                    PointPriorityThree.Add(place);
                }
                if (i > 36 && i <= 42)
                {
                    Point place = new Point() { X = value, Y = 4 };
                    PointPriorityFour.Add(place);
                }
                if (i > 42 && i <= 48)
                {
                    Point place = new Point() { X = value, Y = 18 };
                    PointPriorityFour.Add(place);
                }
                if (i > 48 && i <= 54)
                {
                    Point place = new Point() { X = value, Y = 5 };
                    PointPriorityFive.Add(place);
                }
                if (i > 54 && i <= 60)
                {
                    Point place = new Point() { X = value, Y = 17 };
                    PointPriorityFive.Add(place);
                }
                if (i > 60 && i <= 66)
                {
                    Point place = new Point() { X = value, Y = 6 };
                    PointPrioritySix.Add(place);
                }
                if (i > 66 && i <= 72)
                {
                    Point place = new Point() { X = value, Y = 16 };
                    PointPrioritySix.Add(place);

                }
                if (i > 72 && i <= 78)
                {
                    Point place = new Point() { X = value, Y = 7 };
                    PointPrioritySeven.Add(place);

                }
                if (i > 78 && i <= 84)
                {
                    Point place = new Point() { X = value, Y = 15 };
                    PointPrioritySeven.Add(place);
                }
                if (i > 84 && i <= 90)
                {
                    Point place = new Point() { X = value, Y = 8 };
                    PointPriorityEight.Add(place);
                }
                if (i > 90 && i <= 96)
                {
                    Point place = new Point() { X = value, Y = 14 };
                    PointPriorityEight.Add(place);
                }
                if (i > 96 && i <= 102)
                {
                    Point place = new Point() { X = value, Y = 9 };
                    PointPriorityNine.Add(place);
                }
                if (i > 102 && i <= 108)
                {
                    Point place = new Point() { X = value, Y = 13 };
                    PointPriorityNine.Add(place);
                }
                if (i > 108 && i <= 114)
                {
                    Point place = new Point() { X = value, Y = 10 };
                    PointPriorityTen.Add(place);
                }
                if (i > 114 && i <= 120)
                {
                    Point place = new Point() { X = value, Y = 12 };
                    PointPriorityTen.Add(place);
                }
                if (i > 120 && i <= 126)
                {
                    Point place = new Point() { X = value, Y = 11 };
                    PointPriorityEleven.Add(place);
                }
                value++;
            }

            var queue = new PriorityQueue<List<Point>, int>();

            queue.Enqueue(PointPriorityOne, 1);
            queue.Enqueue(PointPriorityTwo, 2);
            queue.Enqueue(PointPriorityThree,3);
            queue.Enqueue(PointPriorityFour, 4);
            queue.Enqueue(PointPriorityFive, 5);
            queue.Enqueue(PointPrioritySix, 6);
            queue.Enqueue(PointPrioritySeven, 7);
            queue.Enqueue(PointPriorityEight, 8);
            queue.Enqueue(PointPriorityNine, 9);
            queue.Enqueue(PointPriorityTen, 10);
            queue.Enqueue(PointPriorityEleven, 11);

            return queue;

        }

        public Point GetPlace()
        {
            DataBase DB = new DataBase();
            Places places = new Places();
            var priority_places = places.GetPriorityPlace();
            var block_places = DB.GetAllBlockPlaces();

            Point point = new Point();
            int block_count = 0;
            while (priority_places.Count > 0)
            {
                var PlacesList = priority_places.Dequeue();
                for (int i = 0; i < PlacesList.Count; i++)
                {
                    var place = PlacesList[i];

                    if (block_places.Count == 0)
                    {
                        point = place;
                        return point;
                    }

                    var b_place = block_places[block_count];

                    if (block_count < block_places.Count - 1)
                    {
                        block_count++;
                    }
                    if (place == b_place)
                    {
                        continue;
                    }
                    else { point = place; return point; }

                }
                if (point != default)
                {
                    break;
                }
            }
            return default;
        }

    }
}
