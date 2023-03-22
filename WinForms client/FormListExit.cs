using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Inzynierski_2._0
{
    public partial class FormListExit : Form
    {
        public FormListExit()
        {
            InitializeComponent();
        }

        public List<Ticket> all_tickets = new List<Ticket>();

        private void FormListExit_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < all_tickets.Count; i++)
            {
                ListViewItem item = ListBox.CreateItemsNrReg(all_tickets[i]);
                listView.Items.Add(item);
            }
        }

        private void Select_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0)
            {
                label1.Text = listView.SelectedItems[0].SubItems[0].Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
