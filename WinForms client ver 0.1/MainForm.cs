using System;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using static Projekt_Inzynierski_2._0.Ticket;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Projekt_Inzynierski_2._0
{
    public partial class MainForm : Form
    {
       
        //Timers expand
        bool bilet_bar_expand;
        bool settings_bar_expand;

        Ticket ticket_scan_pay = new Ticket();
        List<Image> Cars = new List<Image>();
        Setpoint setpoint = new Setpoint();
        Random random = new Random();
        List<PictureBox> first_floor = new List<PictureBox>();


        public MainForm()
        {
            InitializeComponent();

            
            ticket_field.ForeColor = Color.Black;

            ticket_field.Hide();
            scan_ticket.Hide();
           

            screen_places.BackColor = Color.Black;


            Car_Entered_Button.Hide();

            pay_ticket_button.Hide();

            car_exit_button.Hide();

            exit_barrier_picture_open.Hide();
            enter_barrier_picture_open.Hide();

            Cars.Add(Red_car.Image);
            Cars.Add(Green_car.Image);
            Cars.Add(Blue_Car.Image);

            Red_car.Hide();
            Green_car.Hide();
            Blue_Car.Hide();


            setpoint.SetPointer();
        }    


        async private void Car_Enter_Barrier_Click(object sender, EventArgs e)
        {
            
            

            var free_places = await Server.Request<int>("https://localhost:7269/get_free_places");

            if (free_places == -1) { screen_places.BackColor = Color.Black; ; screen_places.Text = "SERVER ERROR"; }

            if (free_places == 0)
            {
                screen_places.BackColor = Color.Black;
                screen_places.Text = $"Wolne miejsca : Niema";
                return;
            }
            else
            {
                screen_places.Text = $"Wolne miejsca: \n {free_places}";
            }

            var ticket = await Server.Request<Ticket>("https://localhost:7269/get_ticket");

            int[] place_L_P = setpoint.GetPoint(ticket);

            PictureBox car = new PictureBox();

            car.Image = Cars[random.Next(0, 3)];

            car.Location = new Point(place_L_P[1], place_L_P[0]);

            Car.Set_Options(car);

            this.Controls.Add(car);

            first_floor.Add(car);

            Skillet_parking.SendToBack();

            biletbarTimer.Start();
            // UI interfase
            ticket_field.Show();

            ticket_field.Text = $"Data wjazdu: {ticket.datetimeinput.ToString()}\nCena za godzinę: {ticket.tax.ToString()}\nNumer biletu : {ticket.numberofticket.ToString()}\nNr_Rej {ticket.nr_rej}\nPiętro: 1\nRząd: {ticket.line.ToString()}\nMiejsce: {ticket.place.ToString()}";

            
            come_barrier_button.Hide();
            Car_Entered_Button.Show();

            enter_barrier_picture_open.Show();
            enter_barrier_picture_close.Hide();
        } //Button on the enter Barrier

        private void Car_Entered_Barrier_Click(object sender, EventArgs e) 
        {
            biletbarTimer.Start();

            come_barrier_button.Show();
            Car_Entered_Button.Hide();

            enter_barrier_picture_close.Show();
            enter_barrier_picture_open.Hide();

            ticket_field.Hide();
        } // Sensor of the car that entered

        async private void Scann_Ticket_Click(object sender, EventArgs e) 
        {
            Ticket ticket = new Ticket();

            var all_tickets = await Server.Request<List<Ticket>>("https://localhost:7269/get_all_ticket_from_db");

            FormList ticket_list_form = new FormList();

            ticket_list_form.all_tickets = all_tickets;

            DialogResult result = ticket_list_form.ShowDialog();

            if (result == DialogResult.OK)
            {
                // get data from the form
                string data = ticket_list_form.label1.Text;
                ticket = await Server.Request<Ticket>("https://localhost:7269/scan_ticket?ticket_number=" + data);
            }

            if (ticket.isPaid == false)
            {
                pay_ticket_button.Show();
                scan_ticket_button.Hide();

                biletbarTimer.Start();

                scan_ticket.Show();

                ticket_scan_pay = ticket;

                scan_ticket.Text = $"Data wjazdu: {ticket.datetimeinput.ToString()}\nCena za godzinę: {ticket.tax.ToString()}\nNumer biletu : {ticket.numberofticket.ToString()}\nNr_Rej {ticket.nr_rej}\nPiętro: 1\nRząd: {ticket.line.ToString()}\nMiejsce: {ticket.place.ToString()}";
            }
            else { MessageBox.Show("Bilet już był zapłacony"); return; }

        } //Ticket scanning

        async private void Pay_Ticket_Click(object sender, EventArgs e)
        {
            if (ticket_scan_pay.isPaid == false)
            {
                var ticket = await Server.Request<Ticket>("https://localhost:7269/paid_ticket?ticket_number=" + ticket_scan_pay.numberofticket);
               
                if (ticket.isPaid == true)
                {
                    scan_ticket.Text = $"Numer biletu: {ticket.numberofticket.ToString()}\nBilet został zapłacony";

                    scan_ticket_button.Show();
                    pay_ticket_button.Hide();

                    await Task.Delay(5000);
                    biletbarTimer.Start();
                }
            }
        } //Stopover payment simulation

        async private void Car_NrRegist_Scan_Exit_Click(object sender, EventArgs e)
        {
            var all_tickets = await Server.Request<List<Ticket>>("https://localhost:7269/get_all_ticket_from_db");

            FormListExit formList = new FormListExit();

            formList.all_tickets = all_tickets;

            DialogResult result = formList.ShowDialog();

            if (result == DialogResult.OK)
            {
                //get data from the form
                string data = formList.label1.Text;
                var isPaid = await Server.Request<bool>("https://localhost:7269/scan_exit_ticket?nr_registration=" + data);

                if (isPaid == true)
                {
                    exit_barrier_picture_open.Show();
                    exit_barrier_picture_close.Hide();
                }
            }

            scan_exit_ticket.Hide();
            car_exit_button.Show();

        } //Ticket exit scan

        private void Car_Exit_Button_Click(object sender, EventArgs e) 

        {
            scan_exit_ticket.Show();
            car_exit_button.Hide();

            exit_barrier_picture_close.Show();
            exit_barrier_picture_open.Hide();
        } // Car exit barrier sensor

        private void Exit_Click(object sender, EventArgs e)
        {

            Application.Exit();


        } //Exit program

        private async void Update_Tax_Click(object sender, EventArgs e)
        {
            double tax;

            if (double.TryParse(TaxField_first.Text, out tax))
            {
                HttpClient client = new HttpClient();

                await client.GetAsync("https://localhost:7269/update_tax?tax=" + tax);

                MessageBox.Show("Stawkę zmieniono");
            }
            else { MessageBox.Show("Wpisz jaką cene ustawić"); return; }
        } //Update tax in Data Base

        private async void MainForm_Load(object sender, EventArgs e)
        {
           
            
            // Loading car from Data Base
            var ticket_list = await Server.Request<List<Ticket>>("https://localhost:7269/get_all_ticket_from_db");

            for (int i = 0; i < ticket_list.Count; i++)
            {
                var ticket = ticket_list[i];
                int[] place_L_P = setpoint.GetPoint(ticket);

                PictureBox car = new PictureBox();

                car.Image = Cars[random.Next(0, 3)];

                car.Location = new Point(place_L_P[1], place_L_P[0]);

                Car.Set_Options(car);

                this.Controls.Add(car);

                first_floor.Add(car);

                Skillet_parking.SendToBack();

                //Loading free places from Data Base
                var free_places = await Server.Request<int>("https://localhost:7269/get_free_places");

                if (free_places == 0)
                {
                    screen_places.BackColor = Color.Black;
                    screen_places.Text = $"Wolne miejsca : Niema";
                    return;
                }
                else
                {
                    screen_places.Text = "Wolne miejsca \n" + free_places.ToString();
                }
            }
        } //Program run

        private async void Settings_Button_Click(object sender, EventArgs e)
        {
            settings_bar_timer.Start();

            if (settings_bar_expand == true)
            {
                await Task.Delay(350);
                Settings_panel.Hide();
            }
            else
            {
                Settings_panel.Show();
            }
        } //Settings button

        private void BiletbarTimer_Tick(object sender, EventArgs e)
        {
            if (bilet_bar_expand == true)
            {
                show_get_ticket.Height -= 10;
                if (show_get_ticket.Height == show_get_ticket.MinimumSize.Height)
                {

                    bilet_bar_expand = false;
                    biletbarTimer.Stop();
                }
            }
            if (bilet_bar_expand == false)
            {
                show_get_ticket.Height += 10;
                if (show_get_ticket.Height == show_get_ticket.MaximumSize.Height)
                {
                    bilet_bar_expand = true;
                    biletbarTimer.Stop();
                }
            }
        } //Timer biletBaru tick

        private void Settings_Bar_Timer_Tick(object sender, EventArgs e)
        {
            if (settings_bar_expand == true)
            {
                Settings_panel.Width -= 10;
                Settings_panel.Height -= 10;
                if (Settings_panel.Width == Settings_panel.MinimumSize.Width)
                {
                    
                    if (Settings_panel.Height == Settings_panel.MinimumSize.Height)
                    {
                        settings_bar_expand = false;
                        settings_bar_timer.Stop();
                    }
                    
                }
            }
            if (settings_bar_expand == false)
            {
                Settings_panel.Height += 10;
                Settings_panel.Width += 10;
                if (Settings_panel.Height == Settings_panel.MaximumSize.Height)
                {
                    
                    if (Settings_panel.Width == Settings_panel.MaximumSize.Width)
                    {
                        settings_bar_expand = true;
                        settings_bar_timer.Stop();
                    }
                    
                }
            }
        } //Timer settings button tick
    }
}