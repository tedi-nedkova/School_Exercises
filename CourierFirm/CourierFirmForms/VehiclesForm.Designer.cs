namespace CourierFirmForms
{
    partial class VehiclesForm
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
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            textBox6 = new TextBox();
            panel2 = new Panel();
            listBox1 = new ListBox();
            button1 = new Button();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 250, 243);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(66, 63);
            panel1.Name = "panel1";
            panel1.Size = new Size(1306, 738);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(22, 22, 46);
            button3.Font = new Font("Microsoft Sans Serif", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(53, 594);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(218, 88);
            button3.TabIndex = 19;
            button3.Text = "<< Go Back";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(142, 145, 144);
            button2.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(699, 225);
            button2.Name = "button2";
            button2.Size = new Size(137, 49);
            button2.TabIndex = 18;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click_1;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Microsoft New Tai Lue", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(535, 235);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(158, 38);
            textBox6.TabIndex = 17;
            textBox6.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Controls.Add(listBox1);
            panel2.Location = new Point(354, 326);
            panel2.Name = "panel2";
            panel2.Size = new Size(673, 367);
            panel2.TabIndex = 15;
            panel2.Visible = false;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 29;
            listBox1.Location = new Point(62, 62);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(551, 236);
            listBox1.TabIndex = 0;
            listBox1.Visible = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 64, 64);
            button1.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(610, 563);
            button1.Name = "button1";
            button1.Size = new Size(170, 67);
            button1.TabIndex = 14;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(622, 494);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(167, 34);
            textBox3.TabIndex = 10;
            textBox3.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(631, 422);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(193, 34);
            textBox2.TabIndex = 9;
            textBox2.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(728, 344);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 34);
            textBox1.TabIndex = 8;
            textBox1.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(487, 494);
            label4.Name = "label4";
            label4.Size = new Size(90, 32);
            label4.TabIndex = 7;
            label4.Text = "Type:";
            label4.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(487, 422);
            label3.Name = "label3";
            label3.Size = new Size(106, 32);
            label3.TabIndex = 6;
            label3.Text = "Model:";
            label3.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(487, 344);
            label2.Name = "label2";
            label2.Size = new Size(208, 32);
            label2.TabIndex = 5;
            label2.Text = "Plate Number:";
            label2.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Add Vehicle", "View All Vehicles", "Get Vehicles By Courier's Id" });
            comboBox1.Location = new Point(509, 158);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(354, 44);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft New Tai Lue", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(487, 67);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(402, 62);
            label1.TabIndex = 3;
            label1.Text = "Pick a command:";
            // 
            // VehiclesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(142, 145, 144);
            ClientSize = new Size(1443, 874);
            Controls.Add(panel1);
            Name = "VehiclesForm";
            Text = "VehiclesForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button1;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Panel panel2;
        private ListBox listBox1;
        private TextBox textBox6;
        private Button button2;
        private Button button3;
    }
}