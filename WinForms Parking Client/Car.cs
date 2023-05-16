using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski_2._0
{
    internal class Car
    {
        public PictureBox car_picturebox = new PictureBox();

        public string registrationNumber { get; set; }
        public Point place { get; set; }
        public static PictureBox Set_Options(PictureBox car)
        {
            car.BackColor = System.Drawing.Color.White;
            car.Name = "User_car";
            car.Size = new System.Drawing.Size(21, 50);
            car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            car.TabIndex = 32;
            car.TabStop = false;
            return car;
        }
        
    }
    
}
