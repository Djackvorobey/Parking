using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.Design.Behavior;
using Projekt_Inzynierski_2._0.Properties;

namespace Projekt_Inzynierski_2._0
{
    internal class Traffic_Barrier
    {
        public PictureBox blub_box = new PictureBox();
        public Point place { get; set; }

       private int[] arrX = new int[21];

       private int[] arrY = new int[] { 365, 350, 219, 205, 83, 71 };

        public static void AttributeToCars(List<Car> cars, List<Traffic_Barrier> traffic_barriers)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                var car = cars[i];

                var barrier = traffic_barriers.FirstOrDefault(b=>b.place == car.place);

                barrier.blub_box.Image = Resources.Green_Blub;
                
            }
            
        }
       

        public static void ToAttributeBarriersToCars(Car car, List<Traffic_Barrier> traffic_barriers)
        {
            var barrier = traffic_barriers.FirstOrDefault(b => b.place == car.place);

            barrier.blub_box.Image = Resources.Green_Blub;
            
        }
        public List<Traffic_Barrier> CreateTrafficBarriers()
        {
            
            List < Traffic_Barrier > traffic_Barriers = new List<Traffic_Barrier>();

            int[] places = new int[2];
            int line = 0, place = 0;

            this.SetPointer();

            for (int i = 0; i <= 5; i++)
            {
                place = 0;
                for (int a = 0; a <= 20; a++)
                {
                    Traffic_Barrier traffic_barrier = new Traffic_Barrier();
                    
                    traffic_barrier.blub_box.Size = new Size(10, 10);
                    traffic_barrier.blub_box.SizeMode = PictureBoxSizeMode.Zoom;
                    traffic_barrier.blub_box.BackColor = System.Drawing.Color.Black;
                    traffic_barrier.blub_box.Name = "red_blub";
                    traffic_barrier.blub_box.TabIndex = 32;
                    traffic_barrier.blub_box.TabStop = false;
                    traffic_barrier.place = new Point(place +1 , line +1);

                    places[0] = arrY[line];
                    places[1] = arrX[place];

                    traffic_barrier.blub_box.Location = new Point(places[1], places[0]);
                    traffic_barrier.blub_box.Image = Resources.Red_blub;
                    traffic_Barriers.Add(traffic_barrier);
                    place++;
                }
                line++;
                
            }

            return traffic_Barriers;
        }

        private void SetPointer()
        {

            int amount = 779;
            arrX[0] = 778;
            for (int i = 1; i < arrX.Length; i++)
            {
                amount += 30;
                arrX[i] = amount;
            }
        }
    }
}
