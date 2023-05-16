using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_Inzynierski_2._0
{
    public partial class Choose_floor : Form
    {
        public Choose_floor()
        {
            InitializeComponent();
        }

        private void first_floor_button_Click(object sender, EventArgs e)
        {
            dialog_result.Text = first_floor_button.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void second_floor_button_Click(object sender, EventArgs e)
        {
            dialog_result.Text = second_floor_button.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
