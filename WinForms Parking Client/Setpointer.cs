using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

namespace Projekt_Inzynierski_2._0
{
    internal class Setpointer
    {
       
        public int[] attachLocationCoordinates(Ticket ticket, int firstPozition, int step, int[] arrY, int[] arrX) //Приписання Координат до місця визначеного на сервері
        {
            arrX = this.SetXPoint(arrX,firstPozition,step);

            int[] place = new int[2];
            place[0] = arrY[ticket.line-1];

            if (ticket.place == 0)
            {
              place[1] = arrX[ticket.place];
            }
            else
            {
              place[1] = arrX[ticket.place - 1];
            }
            return place;
        }

       
        private int[] SetXPoint(int[] arrX, int firstPozition, int step)
        {
            arrX[0] = firstPozition;
            for (int i = 1; i < arrX.Length; i++)
            {
                firstPozition += step;
                arrX[i] = firstPozition;
            }
            return arrX;
        }
    }
}
