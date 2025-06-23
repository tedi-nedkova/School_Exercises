namespace CourierFirmForms
{
    partial class CustomersForm
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
            comboBox1 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 250, 243);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(127, 106);
            panel1.Name = "panel1";
            panel1.Size = new Size(2540, 1473);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Miriam Libre", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Add Customer", "View All Customers", "Get Customers With Active Deliveries", "Get Top 5 Customers By Package Count", "Get Customers By Courier's Name" });
            comboBox1.Location = new Point(930, 321);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(573, 71);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft New Tai Lue", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(907, 119);
            label1.Name = "label1";
            label1.Size = new Size(640, 99);
            label1.TabIndex = 1;
            label1.Text = "Pick a command:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Miriam Libre", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(796, 570);
            label2.Name = "label2";
            label2.Size = new Size(275, 56);
            label2.TabIndex = 3;
            label2.Text = "First Name:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1188, 637);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 39);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Miriam Libre", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(796, 698);
            label3.Name = "label3";
            label3.Size = new Size(259, 56);
            label3.TabIndex = 5;
            label3.Text = "Last Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Miriam Libre", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(838, 794);
            label4.Name = "label4";
            label4.Size = new Size(162, 56);
            label4.TabIndex = 6;
            label4.Text = "Email:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Miriam Libre", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 177);
            label5.Location = new Point(838, 872);
            label5.Name = "label5";
            label5.Size = new Size(349, 56);
            label5.TabIndex = 7;
            label5.Text = "Phone Number:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(838, 954);
            label6.Name = "label6";
            label6.Size = new Size(78, 32);
            label6.TabIndex = 8;
            label6.Text = "label6";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1188, 715);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 39);
            textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1188, 794);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(200, 39);
            textBox3.TabIndex = 10;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1188, 872);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(200, 39);
            textBox4.TabIndex = 11;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1188, 963);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(200, 39);
            textBox5.TabIndex = 12;
            // 
            // CustomersForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(142, 145, 144);
            ClientSize = new Size(2792, 1688);
            Controls.Add(panel1);
            Margin = new Padding(5);
            Name = "CustomersForm";
            Text = "CustomersForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
    }
}