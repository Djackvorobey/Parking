using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Inzynierski_2._0
{
    internal class ListBox
    {
        public static ListViewItem CreateItemsNrReg(Ticket ticket)
        {
            ListViewItem item1 = new ListViewItem(ticket.nr_rej);
            item1.SubItems.Add(ticket.numberofticket.ToString());
            item1.SubItems.Add(ticket.isPaid.ToString());
            item1.SubItems.Add(ticket.datetimeinput.ToString());
          
            return item1;
        }
        public static ListViewItem CreateItemsNrTicket(Ticket ticket)
        {
            ListViewItem item1 = new ListViewItem(ticket.numberofticket.ToString());
            item1.SubItems.Add(ticket.nr_rej);
            item1.SubItems.Add(ticket.isPaid.ToString());
            item1.SubItems.Add(ticket.datetimeinput.ToString());

            return item1;
        }
    }
}
