namespace Projekt_Inzynierski_2._0
{
    partial class Choose_floor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.choose_floor_panel = new System.Windows.Forms.Panel();
            this.second_floor_button = new System.Windows.Forms.Button();
            this.first_floor_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dialog_result = new System.Windows.Forms.Label();
            this.choose_floor_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // choose_floor_panel
            // 
            this.choose_floor_panel.Controls.Add(this.second_floor_button);
            this.choose_floor_panel.Controls.Add(this.first_floor_button);
            this.choose_floor_panel.Location = new System.Drawing.Point(22, 120);
            this.choose_floor_panel.Name = "choose_floor_panel";
            this.choose_floor_panel.Size = new System.Drawing.Size(270, 152);
            this.choose_floor_panel.TabIndex = 42;
            // 
            // second_floor_button
            // 
            this.second_floor_button.BackColor = System.Drawing.Color.Gray;
            this.second_floor_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.second_floor_button.FlatAppearance.BorderSize = 3;
            this.second_floor_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.second_floor_button.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.second_floor_button.ForeColor = System.Drawing.Color.White;
            this.second_floor_button.Location = new System.Drawing.Point(4, 84);
            this.second_floor_button.Name = "second_floor_button";
            this.second_floor_button.Size = new System.Drawing.Size(264, 68);
            this.second_floor_button.TabIndex = 1;
            this.second_floor_button.Text = "1";
            this.second_floor_button.UseVisualStyleBackColor = false;
            this.second_floor_button.Click += new System.EventHandler(this.second_floor_button_Click);
            // 
            // first_floor_button
            // 
            this.first_floor_button.BackColor = System.Drawing.Color.Gray;
            this.first_floor_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.first_floor_button.FlatAppearance.BorderSize = 3;
            this.first_floor_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.first_floor_button.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.first_floor_button.ForeColor = System.Drawing.Color.White;
            this.first_floor_button.Location = new System.Drawing.Point(4, 0);
            this.first_floor_button.Name = "first_floor_button";
            this.first_floor_button.Size = new System.Drawing.Size(263, 68);
            this.first_floor_button.TabIndex = 0;
            this.first_floor_button.Text = "0";
            this.first_floor_button.UseVisualStyleBackColor = false;
            this.first_floor_button.Click += new System.EventHandler(this.first_floor_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sitka Small", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 28);
            this.label1.TabIndex = 43;
            this.label1.Text = "Wybierz piętro";
            // 
            // dialog_result
            // 
            this.dialog_result.AutoSize = true;
            this.dialog_result.Location = new System.Drawing.Point(137, 319);
            this.dialog_result.Name = "dialog_result";
            this.dialog_result.Size = new System.Drawing.Size(38, 15);
            this.dialog_result.TabIndex = 2;
            this.dialog_result.Text = "label2";
            // 
            // Choose_floor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(327, 363);
            this.Controls.Add(this.dialog_result);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.choose_floor_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Choose_floor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose_floor";
            this.choose_floor_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel choose_floor_panel;
        private Button second_floor_button;
        private Button first_floor_button;
        private Label label1;
        public Label dialog_result;
    }
}