using Projekt_Inzynierski_2._0.Properties;
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

        Ticket ticket_scan_pay = new();
        public List<Image> Cars = new();
        Random random = new();
        List<Car> first_floor_cars = new();
        List<Car> second_floor_cars = new();
        List<Traffic_Barrier> traffic_barriers_first_floor = new();
        List<Traffic_Barrier> traffic_barriers_second_floor = new();
       // List<List<Arrow>> arrows = new();
        Arrow arrow = new();

        //Floor changer 
        Choose_floor floor = new();
        DialogResult result;

        public MainForm()
        {
            InitializeComponent();
            //arrow = new Arrow(this);

            ticket_field.ForeColor = Color.Black;
            second_floor.Hide();
            ticket_field.Hide();
            scan_ticket.Hide();

            arrow_1_left.Hide();
            arrow_1_right.Hide();
            arrow_2_3_left.Hide();
            arrow_2_3_right.Hide();
            arrow_4_5_left.Hide();  
            arrow_4_5_right.Hide();
            arrow_6_left.Hide();
            arrow_6_right.Hide();

            entered_Button.Hide();

            arrow_left.Hide();
            arrow_right.Hide();

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


        }    


        async private void Car_Enter_Barrier_Click(object sender, EventArgs e)
        {
            // SET FLOOR
            
            result = floor.ShowDialog();
            this.choose_floor();
            // IF FLOOR SET => GET TICKET => CREATE CAR WITH TICKET PLACES

            if (result == DialogResult.OK)
            {

                var ticket = await Server.Request<Ticket>("https://localhost:7269/get_ticket?floor="+ floor.dialog_result.Text);
                if (ticket == null)
                {
                    MessageBox.Show($"Niema miejsca na wybranym poziomie {floor.dialog_result.Text}");
                    return;
                }
                Setpointer setpoint = new Setpointer();
                int[] arrX = new int[22];
                int[] arrY = new int[] { 368, 308, 222, 162, 86, 28 };
                int firstPozition = 764;
                int step = 30;

                int[] place_L_P = setpoint.attachLocationCoordinates(ticket, firstPozition, step, arrY, arrX);

                Car car = new Car();

                car.car_picturebox.Image = Cars[random.Next(0, 3)];

                car.place = new Point(ticket.place, ticket.line);

                car.registrationNumber = ticket.nr_rej;

                car.car_picturebox.Location = new Point(place_L_P[1], place_L_P[0]);

                Car.Set_Options(car.car_picturebox);

                this.Controls.Add(car.car_picturebox);

                if (ticket.floor == 0)
                {
                    first_floor_cars.Add(car);

                    Traffic_Barrier.ToAttributeBarriersToCars(car, traffic_barriers_first_floor); //Add Traffic Barrier to CAR

                    if (Skillet_parking.Enabled == false)
                    {
                        car.car_picturebox.Hide();
                    }
                    
                }
                if (ticket.floor == 1)
                {
                    second_floor_cars.Add(car);

                    Traffic_Barrier.ToAttributeBarriersToCars(car, traffic_barriers_second_floor); //Add Traffic Barrier to CAR

                    if (second_floor.Enabled == false)
                    {
                        car.car_picturebox.Hide();
                    }
                }
                //Set Arrow Side
                if (ticket.place <= 10)
                {
                    arrow_left.Show();
                }
                else { arrow_right.Show(); }
                //Set Arrow Place

                Arrow arrow = new Arrow();

                arrow = arrow.SetArrowPlaceOptions(ticket, place_L_P);

                this.arrow = arrow;
                this.Controls.Add(arrow.pictureBox);

                //Set Arrow line

                if (ticket.place <=10)
                {
                    switch (ticket.line)
                    {
                        case 2:
                            arrow_2_3_left.Show();
                            break;
                        case 3:
                            arrow_2_3_left.Show();
                            break;
                        case 4:
                            arrow_4_5_left.Show();
                            break;
                        case 5:
                            arrow_4_5_left.Show();
                            break;
                        case 6:
                            arrow_6_left.Show();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (ticket.line)
                    {
                        case 2:
                            arrow_2_3_right.Show();
                            break;
                        case 3:
                            arrow_2_3_right.Show();
                            break;
                        case 4:
                            arrow_4_5_right.Show();
                            break;
                        case 5:
                            arrow_4_5_right.Show();
                            break;
                        case 6:
                            arrow_6_right.Show();
                            break;
                        default:
                            break;
                    }
                }
                // GET FREE PLACES 

                var free_places = await Server.Request<int>("https://localhost:7269/get_free_places");

                if (free_places == -1) {screen_places.Text = "SERVER ERROR"; }

                if (free_places == 0)
                {
                   
                    screen_places.Text = $"Wolne miejsca : Niema";
                    return;
                }
                else
                {
                    screen_places.Text = $"Wolne miejsca: \n {free_places}";
                }

                // UI interfase

                Skillet_parking.SendToBack();
                second_floor.SendToBack();
                biletbarTimer.Start();
                ticket_field.Show();
                if (ticket.color == "Orange")
                {
                    show_get_ticket.BackColor = Color.Orange;
                }
                if (ticket.color == "Green")
                {
                    show_get_ticket.BackColor = Color.Green;
                }
                ticket_field.Text = $"Data wjazdu: {ticket.datetimeinput.ToString()}\nCena za godzinę: {ticket.tax.ToString()}\nNumer biletu : {ticket.numberofticket.ToString()}\nNr_Rej {ticket.nr_rej}\nPiętro: {ticket.floor.ToString()}"; //\nRząd: {ticket.line.ToString()}\nMiejsce: {ticket.place.ToString()}

                come_barrier_button.Hide();
                    entered_Button.Show();

                    enter_barrier_picture_open.Show();
                    enter_barrier_picture_close.Hide();
                
                
            }
            
        } //Button on the enter Barrier

        private void Car_Entered_Barrier_Click(object sender, EventArgs e) 
        {
            this.Controls.Remove(arrow.pictureBox);

            arrow_left.Hide();
            arrow_right.Hide();
            biletbarTimer.Start();

            come_barrier_button.Show();
            entered_Button.Hide();

            enter_barrier_picture_close.Show();
            enter_barrier_picture_open.Hide();

            // Arrows in Line is Hide
            arrow_2_3_left.Hide();
            arrow_2_3_right.Hide();
            arrow_4_5_left.Hide();
            arrow_4_5_right.Hide();
            arrow_6_left.Hide();
            arrow_6_right.Hide();
            show_get_ticket.BackColor = Color.Gray;
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
                show_get_ticket.SendToBack();
                ticket_field.Location = ticket_field.Location;
                ticket_label.Text = $"Data wjazdu: {ticket.datetimeinput.ToString()}\nSuma do zapłaty: {ticket.tax.ToString()}\nNumer biletu : {ticket.numberofticket.ToString()}\nNr_Rej {ticket.nr_rej}\nPiętro: {ticket.floor.ToString()}"; ;
                ticket_scan_pay = ticket;
                if (ticket.color == "Orange")
                {
                    show_get_ticket.BackColor = Color.Orange;
                }
                if (ticket.color == "Green")
                {
                    show_get_ticket.BackColor = Color.Green;
                }
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
                    show_get_ticket.BackColor = Color.Gray;
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
                var ticket = await Server.Request<Ticket>("https://localhost:7269/scan_exit_ticket?nr_registration=" + data);
                if (ticket == default) { MessageBox.Show("Szlaban zamknięty, proszę opłacić parking"); }
                else
                {
                    var car = first_floor_cars.FirstOrDefault(c => c.registrationNumber == ticket.nr_rej);

                    this.Controls.Remove(car.car_picturebox);

                    var traffic_barrier = traffic_barriers_first_floor.FirstOrDefault(b => b.place == car.place);

                    traffic_barrier.blub_box.Image = Resources.Red_blub;

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
            //Create a traffic blubs in parking
            Traffic_Barrier traffic_barrier = new Traffic_Barrier();
            traffic_barriers_first_floor = traffic_barrier.CreateTrafficBarriers();

            foreach (var barrier in traffic_barriers_first_floor)
            {
                
                this.Controls.Add(barrier.blub_box);
            }
           
            traffic_barriers_second_floor = traffic_barrier.CreateTrafficBarriers();

            foreach (var barrier in traffic_barriers_second_floor)
            {
                
                this.Controls.Add(barrier.blub_box);
            }

            // Loading car from Data Base
            
            var ticket_list = await Server.Request<List<Ticket>>("https://localhost:7269/get_all_ticket_from_db");

            Setpointer setpoint = new Setpointer();

            int[] arrX = new int[22];
            int[] arrY = new int[] { 368, 308, 222, 162, 86, 28 };
            int firstPozition = 764;
            int step = 30;

            for (int i = 0; i < ticket_list.Count; i++)
            {
                var ticket = ticket_list[i];
                int[] place_L_P = setpoint.attachLocationCoordinates(ticket, firstPozition, step, arrY, arrX);

                Car Car = new Car();

                Car.car_picturebox.Image = Cars[random.Next(0, 3)];
                Car.place = new Point(ticket.place, ticket.line);
                Car.registrationNumber = ticket.nr_rej;
                Car.car_picturebox.Location = new Point(place_L_P[1], place_L_P[0]);

                Car.Set_Options(Car.car_picturebox);

                this.Controls.Add(Car.car_picturebox);
                if (ticket.floor == 0)
                {
                    first_floor_cars.Add(Car);
                }
                if (ticket.floor == 1)
                {
                    second_floor_cars.Add(Car);
                }
                
            }

            // Set traffic burriers to cars

            Traffic_Barrier.AttributeToCars(first_floor_cars, traffic_barriers_first_floor);
            Traffic_Barrier.AttributeToCars(second_floor_cars, traffic_barriers_second_floor);

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

            // Create all arrows
            //arrows = arrow.CreateArrows();

            Skillet_parking.SendToBack();

            

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

        private void choose_floor_button_Click(object sender, EventArgs e ) // Choose floor 
        {
            // SET FLOOR 
            result = floor.ShowDialog();
            this.choose_floor();
        }

        private void choose_floor()
        {

            if (result == DialogResult.OK)
            {
                var choose_floor = floor.dialog_result.Text;
                if (choose_floor == "0")
                {
                    Skillet_parking.Show();
                    Skillet_parking.Enabled = true;
                    second_floor.Hide();
                    second_floor.Enabled = false;

                    enter_barrier_picture_close.Show();
                    exit_barrier_picture_close.Show();

                    foreach (var item in first_floor_cars)
                    {
                        item.car_picturebox.Show();
                    }
                    foreach (var item in second_floor_cars)
                    {
                        item.car_picturebox.Hide();
                    }
                    foreach (var item in traffic_barriers_first_floor)
                    {
                        item.blub_box.Show();
                    }
                    foreach (var item in traffic_barriers_second_floor)
                    {
                        item.blub_box.Hide();
                    }
                }
                else
                {
                    Skillet_parking.Hide();
                    Skillet_parking.Enabled = false;
                    second_floor.Show();
                    second_floor.Enabled = true;
                    second_floor.SendToBack();

                    enter_barrier_picture_close.Hide();
                    exit_barrier_picture_close.Hide();

                    foreach (var item in first_floor_cars)
                    {
                        item.car_picturebox.Hide();
                    }
                    foreach (var item in second_floor_cars)
                    {
                        item.car_picturebox.Show();
                    }
                    foreach (var item in traffic_barriers_first_floor)
                    {
                        item.blub_box.Hide();
                    }
                    foreach (var item in traffic_barriers_second_floor)
                    {
                        item.blub_box.Show();
                    }
                }
            }
        }

        private async Task<string> clearDB() 
        { 
            string ansver = await Server.Request<string>("https://localhost:7269/clearDB");
            return ansver;
        }

        private async void ClearDB_Buttron_Click(object sender, EventArgs e)
        {
            var ansver = await this.clearDB(); 
            MessageBox.Show(ansver);
        }
    }
}