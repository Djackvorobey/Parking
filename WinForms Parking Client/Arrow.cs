using Projekt_Inzynierski_2._0.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Inzynierski_2._0
{
    internal class Arrow
    {
        public PictureBox pictureBox = new();
       
        public Arrow SetArrowPlaceOptions(Ticket ticket, int[] place)
        {
            Arrow arrow = new();
            arrow.pictureBox.Size = new Size(30, 30);
            arrow.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            arrow.pictureBox.Name = "Arrow";
            arrow.pictureBox.TabIndex = 32;
            arrow.pictureBox.TabStop = false;
            if (ticket.line == 1 || ticket.line == 3 || ticket.line == 5)
            {
                arrow.pictureBox.Location = new Point(place[1] - 5, place[0] + 50);
                arrow.pictureBox.Image = Resources.strzalkaUp;
            }
            else
            {
                arrow.pictureBox.Location = new Point(place[1] - 5, place[0] - 30); // зробити це в методі в классі Arrow
                arrow.pictureBox.Image = Resources.strzalkaDown;
            }
            return arrow;
        }
    }
}
