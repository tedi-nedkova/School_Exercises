namespace CourierFirmForms
{
    partial class CouriersForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 250, 243);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(41, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(1635, 971);
            panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft YaHei UI Light", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Add Courier", "View All Couriers", "Get Couriers By Vehicle's Id" });
            comboBox1.Location = new Point(594, 178);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(448, 47);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft New Tai Lue", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(77, 122, 98);
            label1.Location = new Point(600, 49);
            label1.Name = "label1";
            label1.Padding = new Padding(20);
            label1.Size = new Size(442, 102);
            label1.TabIndex = 1;
            label1.Text = "Pick a command:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(646, 345);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 3;
            label2.Text = "Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(646, 386);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 4;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(646, 432);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 5;
            label4.Text = "Office Id:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(646, 468);
            label5.Name = "label5";
            label5.Size = new Size(76, 20);
            label5.TabIndex = 6;
            label5.Text = "Vehicle Id:";
            // 
            // CouriersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(142, 145, 144);
            ClientSize = new Size(1718, 1055);
            Controls.Add(panel1);
            Name = "CouriersForm";
            Text = "CouriersForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}