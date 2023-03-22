using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design.Behavior;

namespace Projekt_Inzynierski_2._0
{
    internal class Setpoint
    {
        int[] arrX = new int[22];

        int[] arrY = new int[] {368,308,222,162,86,28};

        
        public void SetPointer()
        {
            int amount = 764;
            arrX[0] = 764;
            for (int i = 1; i < arrX.Length; i++)
            {
                amount += 30;
                arrX[i] = amount;
            }
            

        }

        public int[] GetPoint(Ticket ticket) //Приписання Координат до місця визначеного на сервері
        {
            int[] place = new int[2];

            place[0] = arrY[ticket.line];
            place[1] = arrX[ticket.place-1];

            return place;

        }
    }
}
