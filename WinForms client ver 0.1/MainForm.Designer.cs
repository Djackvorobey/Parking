namespace Projekt_Inzynierski_2._0
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.screen_places = new System.Windows.Forms.Label();
            this.ticket_label = new System.Windows.Forms.Label();
            this.scan_ticket_button = new System.Windows.Forms.Button();
            this.scan_ticket = new System.Windows.Forms.Label();
            this.scan_exit_ticket = new System.Windows.Forms.Button();
            this.car_exit_button = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.pay_ticket_button = new System.Windows.Forms.Button();
            this.exit_barrier_picture_close = new System.Windows.Forms.PictureBox();
            this.enter_barrier_picture_close = new System.Windows.Forms.PictureBox();
            this.exit_barrier_picture_open = new System.Windows.Forms.PictureBox();
            this.enter_barrier_picture_open = new System.Windows.Forms.PictureBox();
            this.ticket_field = new System.Windows.Forms.Label();
            this.Skillet_parking = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Green_car = new System.Windows.Forms.PictureBox();
            this.Blue_Car = new System.Windows.Forms.PictureBox();
            this.Red_car = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TaxField_first = new System.Windows.Forms.TextBox();
            this.update_button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Settings_panel = new System.Windows.Forms.Panel();
            this.settings_button = new System.Windows.Forms.PictureBox();
            this.Car_Entered_Button = new System.Windows.Forms.Button();
            this.come_barrier_button = new System.Windows.Forms.Button();
            this.show_get_ticket = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.biletbarTimer = new System.Windows.Forms.Timer(this.components);
            this.settings_bar_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exit_barrier_picture_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enter_barrier_picture_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_barrier_picture_open)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enter_barrier_picture_open)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skillet_parking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green_car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_Car)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_car)).BeginInit();
            this.panel1.SuspendLayout();
            this.Settings_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settings_button)).BeginInit();
            this.show_get_ticket.SuspendLayout();
            this.SuspendLayout();
            // 
            // screen_places
            // 
            this.screen_places.AutoSize = true;
            this.screen_places.BackColor = System.Drawing.Color.Transparent;
            this.screen_places.ForeColor = System.Drawing.Color.White;
            this.screen_places.Location = new System.Drawing.Point(729, 572);
            this.screen_places.Name = "screen_places";
            this.screen_places.Size = new System.Drawing.Size(90, 30);
            this.screen_places.TabIndex = 11;
            this.screen_places.Text = "Wolne miejsca: \n Niema";
            // 
            // ticket_label
            // 
            this.ticket_label.AutoSize = true;
            this.ticket_label.Location = new System.Drawing.Point(574, 244);
            this.ticket_label.Name = "ticket_label";
            this.ticket_label.Size = new System.Drawing.Size(0, 15);
            this.ticket_label.TabIndex = 10;
            // 
            // scan_ticket_button
            // 
            this.scan_ticket_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.scan_ticket_button.FlatAppearance.BorderSize = 3;
            this.scan_ticket_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scan_ticket_button.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scan_ticket_button.ForeColor = System.Drawing.Color.White;
            this.scan_ticket_button.Location = new System.Drawing.Point(72, 199);
            this.scan_ticket_button.Name = "scan_ticket_button";
            this.scan_ticket_button.Size = new System.Drawing.Size(200, 71);
            this.scan_ticket_button.TabIndex = 12;
            this.scan_ticket_button.TabStop = false;
            this.scan_ticket_button.Text = "Zeskanuj bilet";
            this.scan_ticket_button.UseVisualStyleBackColor = true;
            this.scan_ticket_button.Click += new System.EventHandler(this.Scann_Ticket_Click);
            // 
            // scan_ticket
            // 
            this.scan_ticket.AutoSize = true;
            this.scan_ticket.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.scan_ticket.Location = new System.Drawing.Point(4, 50);
            this.scan_ticket.Name = "scan_ticket";
            this.scan_ticket.Size = new System.Drawing.Size(204, 119);
            this.scan_ticket.TabIndex = 15;
            this.scan_ticket.Text = "Data wjazdu: 2023-03-20 00.00.00\r\nNumer biletu: 682896109\r\nNumer Rejestracyjny: D" +
    "DI3835\r\nSuma do zapłaty: 82  zł\r\nRząd: 1\r\nMiejsce: 1\r\nPiętro: 1";
            // 
            // scan_exit_ticket
            // 
            this.scan_exit_ticket.BackColor = System.Drawing.Color.Gray;
            this.scan_exit_ticket.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.scan_exit_ticket.FlatAppearance.BorderSize = 3;
            this.scan_exit_ticket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scan_exit_ticket.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scan_exit_ticket.ForeColor = System.Drawing.Color.White;
            this.scan_exit_ticket.Location = new System.Drawing.Point(71, 286);
            this.scan_exit_ticket.Name = "scan_exit_ticket";
            this.scan_exit_ticket.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.scan_exit_ticket.Size = new System.Drawing.Size(200, 71);
            this.scan_exit_ticket.TabIndex = 17;
            this.scan_exit_ticket.Text = "Wyjazd auta";
            this.scan_exit_ticket.UseVisualStyleBackColor = false;
            this.scan_exit_ticket.Click += new System.EventHandler(this.Car_NrRegist_Scan_Exit_Click);
            // 
            // car_exit_button
            // 
            this.car_exit_button.BackColor = System.Drawing.Color.Gray;
            this.car_exit_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.car_exit_button.FlatAppearance.BorderSize = 3;
            this.car_exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.car_exit_button.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.car_exit_button.ForeColor = System.Drawing.Color.White;
            this.car_exit_button.Location = new System.Drawing.Point(71, 286);
            this.car_exit_button.Name = "car_exit_button";
            this.car_exit_button.Size = new System.Drawing.Size(200, 71);
            this.car_exit_button.TabIndex = 22;
            this.car_exit_button.Text = "auto wyjechalo";
            this.car_exit_button.UseVisualStyleBackColor = false;
            this.car_exit_button.Click += new System.EventHandler(this.Car_Exit_Button_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Gray;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exit.FlatAppearance.BorderSize = 2;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(111, 415);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(126, 46);
            this.exit.TabIndex = 23;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pay_ticket_button
            // 
            this.pay_ticket_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.pay_ticket_button.FlatAppearance.BorderSize = 3;
            this.pay_ticket_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pay_ticket_button.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pay_ticket_button.ForeColor = System.Drawing.Color.White;
            this.pay_ticket_button.Location = new System.Drawing.Point(72, 199);
            this.pay_ticket_button.Name = "pay_ticket_button";
            this.pay_ticket_button.Size = new System.Drawing.Size(200, 71);
            this.pay_ticket_button.TabIndex = 24;
            this.pay_ticket_button.Text = "Zaplac za bilet";
            this.pay_ticket_button.UseVisualStyleBackColor = true;
            this.pay_ticket_button.Click += new System.EventHandler(this.Pay_Ticket_Click);
            // 
            // exit_barrier_picture_close
            // 
            this.exit_barrier_picture_close.BackColor = System.Drawing.Color.White;
            this.exit_barrier_picture_close.Image = ((System.Drawing.Image)(resources.GetObject("exit_barrier_picture_close.Image")));
            this.exit_barrier_picture_close.Location = new System.Drawing.Point(970, 509);
            this.exit_barrier_picture_close.Name = "exit_barrier_picture_close";
            this.exit_barrier_picture_close.Size = new System.Drawing.Size(117, 71);
            this.exit_barrier_picture_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_barrier_picture_close.TabIndex = 26;
            this.exit_barrier_picture_close.TabStop = false;
            this.exit_barrier_picture_close.Click += new System.EventHandler(this.Car_NrRegist_Scan_Exit_Click);
            // 
            // enter_barrier_picture_close
            // 
            this.enter_barrier_picture_close.BackColor = System.Drawing.Color.White;
            this.enter_barrier_picture_close.Image = ((System.Drawing.Image)(resources.GetObject("enter_barrier_picture_close.Image")));
            this.enter_barrier_picture_close.Location = new System.Drawing.Point(1114, 511);
            this.enter_barrier_picture_close.Name = "enter_barrier_picture_close";
            this.enter_barrier_picture_close.Size = new System.Drawing.Size(117, 71);
            this.enter_barrier_picture_close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enter_barrier_picture_close.TabIndex = 27;
            this.enter_barrier_picture_close.TabStop = false;
            this.enter_barrier_picture_close.Click += new System.EventHandler(this.Car_Enter_Barrier_Click);
            // 
            // exit_barrier_picture_open
            // 
            this.exit_barrier_picture_open.BackColor = System.Drawing.Color.White;
            this.exit_barrier_picture_open.Image = ((System.Drawing.Image)(resources.GetObject("exit_barrier_picture_open.Image")));
            this.exit_barrier_picture_open.Location = new System.Drawing.Point(970, 463);
            this.exit_barrier_picture_open.Name = "exit_barrier_picture_open";
            this.exit_barrier_picture_open.Size = new System.Drawing.Size(117, 117);
            this.exit_barrier_picture_open.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exit_barrier_picture_open.TabIndex = 28;
            this.exit_barrier_picture_open.TabStop = false;
            this.exit_barrier_picture_open.Click += new System.EventHandler(this.Car_Exit_Button_Click);
            // 
            // enter_barrier_picture_open
            // 
            this.enter_barrier_picture_open.BackColor = System.Drawing.Color.White;
            this.enter_barrier_picture_open.Image = ((System.Drawing.Image)(resources.GetObject("enter_barrier_picture_open.Image")));
            this.enter_barrier_picture_open.Location = new System.Drawing.Point(1114, 465);
            this.enter_barrier_picture_open.Name = "enter_barrier_picture_open";
            this.enter_barrier_picture_open.Size = new System.Drawing.Size(117, 117);
            this.enter_barrier_picture_open.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enter_barrier_picture_open.TabIndex = 29;
            this.enter_barrier_picture_open.TabStop = false;
            this.enter_barrier_picture_open.Click += new System.EventHandler(this.Car_Entered_Barrier_Click);
            // 
            // ticket_field
            // 
            this.ticket_field.AutoSize = true;
            this.ticket_field.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.ticket_field.Location = new System.Drawing.Point(4, 50);
            this.ticket_field.Name = "ticket_field";
            this.ticket_field.Size = new System.Drawing.Size(204, 119);
            this.ticket_field.TabIndex = 14;
            this.ticket_field.Text = "Data wjazdu: 2023-03-20 00.00.00\r\nNumer biletu: 682896109\r\nNumer Rejestracyjny: D" +
    "DI3835\r\nSuma do zapłaty: 82  zł\r\nRząd: 1\r\nMiejsce: 1\r\nPiętro: 1";
            // 
            // Skillet_parking
            // 
            this.Skillet_parking.Image = ((System.Drawing.Image)(resources.GetObject("Skillet_parking.Image")));
            this.Skillet_parking.Location = new System.Drawing.Point(708, 12);
            this.Skillet_parking.Name = "Skillet_parking";
            this.Skillet_parking.Size = new System.Drawing.Size(744, 706);
            this.Skillet_parking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Skillet_parking.TabIndex = 30;
            this.Skillet_parking.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(744, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(743, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(743, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(743, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(743, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 15);
            this.label5.TabIndex = 31;
            this.label5.Text = "5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(743, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "6";
            // 
            // Green_car
            // 
            this.Green_car.BackColor = System.Drawing.Color.White;
            this.Green_car.Image = ((System.Drawing.Image)(resources.GetObject("Green_car.Image")));
            this.Green_car.Location = new System.Drawing.Point(667, 30);
            this.Green_car.Name = "Green_car";
            this.Green_car.Size = new System.Drawing.Size(21, 50);
            this.Green_car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Green_car.TabIndex = 32;
            this.Green_car.TabStop = false;
            // 
            // Blue_Car
            // 
            this.Blue_Car.BackColor = System.Drawing.Color.White;
            this.Blue_Car.Image = ((System.Drawing.Image)(resources.GetObject("Blue_Car.Image")));
            this.Blue_Car.Location = new System.Drawing.Point(628, 30);
            this.Blue_Car.Name = "Blue_Car";
            this.Blue_Car.Size = new System.Drawing.Size(21, 50);
            this.Blue_Car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Blue_Car.TabIndex = 32;
            this.Blue_Car.TabStop = false;
            // 
            // Red_car
            // 
            this.Red_car.BackColor = System.Drawing.Color.White;
            this.Red_car.Image = global::Projekt_Inzynierski_2._0.Properties.Resources.Red_car;
            this.Red_car.Location = new System.Drawing.Point(647, 30);
            this.Red_car.Name = "Red_car";
            this.Red_car.Size = new System.Drawing.Size(21, 50);
            this.Red_car.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Red_car.TabIndex = 32;
            this.Red_car.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(59, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Aktualizacja Ceny";
            // 
            // TaxField_first
            // 
            this.TaxField_first.Location = new System.Drawing.Point(83, 46);
            this.TaxField_first.Multiline = true;
            this.TaxField_first.Name = "TaxField_first";
            this.TaxField_first.Size = new System.Drawing.Size(98, 28);
            this.TaxField_first.TabIndex = 34;
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.update_button.FlatAppearance.BorderSize = 0;
            this.update_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_button.Font = new System.Drawing.Font("Stencil", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.update_button.ForeColor = System.Drawing.Color.White;
            this.update_button.Location = new System.Drawing.Point(73, 105);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(126, 55);
            this.update_button.TabIndex = 35;
            this.update_button.Text = "Aktualizuj";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.Update_Tax_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.Settings_panel);
            this.panel1.Controls.Add(this.settings_button);
            this.panel1.Controls.Add(this.Car_Entered_Button);
            this.panel1.Controls.Add(this.come_barrier_button);
            this.panel1.Controls.Add(this.scan_exit_ticket);
            this.panel1.Controls.Add(this.scan_ticket_button);
            this.panel1.Controls.Add(this.pay_ticket_button);
            this.panel1.Controls.Add(this.car_exit_button);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 732);
            this.panel1.TabIndex = 36;
            // 
            // Settings_panel
            // 
            this.Settings_panel.BackColor = System.Drawing.Color.Gray;
            this.Settings_panel.Controls.Add(this.TaxField_first);
            this.Settings_panel.Controls.Add(this.update_button);
            this.Settings_panel.Controls.Add(this.label7);
            this.Settings_panel.Location = new System.Drawing.Point(72, 467);
            this.Settings_panel.MaximumSize = new System.Drawing.Size(270, 170);
            this.Settings_panel.Name = "Settings_panel";
            this.Settings_panel.Size = new System.Drawing.Size(0, 0);
            this.Settings_panel.TabIndex = 38;
            // 
            // settings_button
            // 
            this.settings_button.BackColor = System.Drawing.Color.Transparent;
            this.settings_button.Image = global::Projekt_Inzynierski_2._0.Properties.Resources.pngegg__1_;
            this.settings_button.Location = new System.Drawing.Point(3, 467);
            this.settings_button.Name = "settings_button";
            this.settings_button.Size = new System.Drawing.Size(70, 70);
            this.settings_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.settings_button.TabIndex = 38;
            this.settings_button.TabStop = false;
            this.settings_button.Click += new System.EventHandler(this.Settings_Button_Click);
            // 
            // Car_Entered_Button
            // 
            this.Car_Entered_Button.BackColor = System.Drawing.Color.Gray;
            this.Car_Entered_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Car_Entered_Button.FlatAppearance.BorderSize = 3;
            this.Car_Entered_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Car_Entered_Button.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Car_Entered_Button.ForeColor = System.Drawing.Color.White;
            this.Car_Entered_Button.Location = new System.Drawing.Point(72, 106);
            this.Car_Entered_Button.Name = "Car_Entered_Button";
            this.Car_Entered_Button.Size = new System.Drawing.Size(200, 71);
            this.Car_Entered_Button.TabIndex = 0;
            this.Car_Entered_Button.Text = "Auto Wjechalo";
            this.Car_Entered_Button.UseVisualStyleBackColor = false;
            this.Car_Entered_Button.Click += new System.EventHandler(this.Car_Entered_Barrier_Click);
            // 
            // come_barrier_button
            // 
            this.come_barrier_button.BackColor = System.Drawing.Color.Gray;
            this.come_barrier_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.come_barrier_button.FlatAppearance.BorderSize = 3;
            this.come_barrier_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.come_barrier_button.Font = new System.Drawing.Font("Stencil", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.come_barrier_button.ForeColor = System.Drawing.Color.White;
            this.come_barrier_button.Location = new System.Drawing.Point(72, 106);
            this.come_barrier_button.Name = "come_barrier_button";
            this.come_barrier_button.Size = new System.Drawing.Size(200, 71);
            this.come_barrier_button.TabIndex = 0;
            this.come_barrier_button.Text = "Wjazd Auta";
            this.come_barrier_button.UseVisualStyleBackColor = false;
            this.come_barrier_button.Click += new System.EventHandler(this.Car_Enter_Barrier_Click);
            // 
            // show_get_ticket
            // 
            this.show_get_ticket.BackColor = System.Drawing.Color.Gray;
            this.show_get_ticket.Controls.Add(this.label8);
            this.show_get_ticket.Controls.Add(this.ticket_field);
            this.show_get_ticket.Controls.Add(this.scan_ticket);
            this.show_get_ticket.Location = new System.Drawing.Point(396, 30);
            this.show_get_ticket.MaximumSize = new System.Drawing.Size(210, 197);
            this.show_get_ticket.MinimumSize = new System.Drawing.Size(200, 33);
            this.show_get_ticket.Name = "show_get_ticket";
            this.show_get_ticket.Size = new System.Drawing.Size(210, 33);
            this.show_get_ticket.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Stencil", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(18, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Zeskanowany bilet";
            // 
            // biletbarTimer
            // 
            this.biletbarTimer.Interval = 10;
            this.biletbarTimer.Tick += new System.EventHandler(this.BiletbarTimer_Tick);
            // 
            // settings_bar_timer
            // 
            this.settings_bar_timer.Interval = 10;
            this.settings_bar_timer.Tick += new System.EventHandler(this.Settings_Bar_Timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1464, 732);
            this.Controls.Add(this.show_get_ticket);
            this.Controls.Add(this.Blue_Car);
            this.Controls.Add(this.Green_car);
            this.Controls.Add(this.Red_car);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.screen_places);
            this.Controls.Add(this.enter_barrier_picture_open);
            this.Controls.Add(this.exit_barrier_picture_open);
            this.Controls.Add(this.enter_barrier_picture_close);
            this.Controls.Add(this.exit_barrier_picture_close);
            this.Controls.Add(this.ticket_label);
            this.Controls.Add(this.Skillet_parking);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Parking_Program_164357";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exit_barrier_picture_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enter_barrier_picture_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_barrier_picture_open)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enter_barrier_picture_open)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Skillet_parking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Green_car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blue_Car)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Red_car)).EndInit();
            this.panel1.ResumeLayout(false);
            this.Settings_panel.ResumeLayout(false);
            this.Settings_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.settings_button)).EndInit();
            this.show_get_ticket.ResumeLayout(false);
            this.show_get_ticket.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ticket_label;
        private Label screen_places;
        private Button scan_ticket_button;
        private Label ticket_field;
        private Label scan_ticket;
        private Button scan_exit_ticket;
        private Button car_exit_button;
        private Button exit;
        private Button pay_ticket_button;
        private PictureBox exit_barrier_picture_close;
        private PictureBox enter_barrier_picture_close;
        private PictureBox exit_barrier_picture_open;
        private PictureBox enter_barrier_picture_open;
        private PictureBox Skillet_parking;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private PictureBox Green_car;
        private PictureBox Blue_Car;
        private PictureBox Red_car;
        private Label label7;
        private TextBox TaxField_first;
        private Button update_button;
        private Panel panel1;
        private Button Car_Entered_Button;
        private Button come_barrier_button;
        private Panel show_get_ticket;
        private System.Windows.Forms.Timer biletbarTimer;
        private Label label8;
        
        private PictureBox settings_button;
        private Panel Settings_panel;
        private System.Windows.Forms.Timer settings_bar_timer;
    }
}