using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CourierFirmForms
{
    partial class PackagesForm
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
            button1 = new Button();
            textBox9 = new TextBox();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel2 = new Panel();
            listBox1 = new ListBox();
            button2 = new Button();
            comboBox2 = new ComboBox();
            label8 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(237, 250, 243);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox9);
            panel1.Controls.Add(textBox8);
            panel1.Controls.Add(textBox7);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(comboBox2);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(66, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(1580, 923);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(142, 145, 144);
            button1.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(126, 610);
            button1.Name = "button1";
            button1.Size = new Size(140, 47);
            button1.TabIndex = 31;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox9.Location = new Point(237, 525);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(125, 34);
            textBox9.TabIndex = 30;
            textBox9.Visible = false;
            // 
            // textBox8
            // 
            textBox8.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox8.Location = new Point(237, 457);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(125, 34);
            textBox8.TabIndex = 29;
            textBox8.Visible = false;
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox7.Location = new Point(164, 388);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(140, 34);
            textBox7.TabIndex = 28;
            textBox7.Visible = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(37, 525);
            label11.Name = "label11";
            label11.Size = new Size(182, 32);
            label11.TabIndex = 27;
            label11.Text = "Max Weight:";
            label11.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(37, 457);
            label10.Name = "label10";
            label10.Size = new Size(175, 32);
            label10.TabIndex = 26;
            label10.Text = "Min Weight:";
            label10.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(37, 388);
            label9.Name = "label9";
            label9.Size = new Size(90, 32);
            label9.TabIndex = 25;
            label9.Text = "Type:";
            label9.Visible = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 64, 64);
            panel2.Controls.Add(listBox1);
            panel2.Location = new Point(447, 295);
            panel2.Name = "panel2";
            panel2.Size = new Size(690, 433);
            panel2.TabIndex = 24;
            panel2.Visible = false;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 29;
            listBox1.Location = new Point(48, 52);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(597, 323);
            listBox1.TabIndex = 0;
            listBox1.Visible = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 64, 64);
            button2.Font = new Font("Arial Black", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(714, 787);
            button2.Name = "button2";
            button2.Size = new Size(156, 62);
            button2.TabIndex = 23;
            button2.Text = "Submit";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Pending", "In Transit", "Delivered", "Returned" });
            comboBox2.Location = new Point(822, 714);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 37);
            comboBox2.TabIndex = 22;
            comboBox2.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(570, 714);
            label8.Name = "label8";
            label8.Size = new Size(229, 32);
            label8.TabIndex = 21;
            label8.Text = "Delivery Status:";
            label8.Visible = false;
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox6.Location = new Point(849, 646);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(173, 34);
            textBox6.TabIndex = 20;
            textBox6.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(569, 646);
            label7.Name = "label7";
            label7.Size = new Size(253, 32);
            label7.TabIndex = 19;
            label7.Text = "Delivery Address:";
            label7.Visible = false;
            label7.Click += label7_Click;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox5.Location = new Point(697, 578);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(173, 34);
            textBox5.TabIndex = 18;
            textBox5.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(569, 578);
            label6.Name = "label6";
            label6.Size = new Size(90, 32);
            label6.TabIndex = 17;
            label6.Text = "Type:";
            label6.Visible = false;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(758, 507);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(112, 34);
            textBox4.TabIndex = 16;
            textBox4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(569, 509);
            label5.Name = "label5";
            label5.Size = new Size(156, 32);
            label5.TabIndex = 15;
            label5.Text = "Courier Id:";
            label5.Visible = false;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(789, 436);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(115, 34);
            textBox3.TabIndex = 14;
            textBox3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(569, 438);
            label4.Name = "label4";
            label4.Size = new Size(186, 32);
            label4.TabIndex = 13;
            label4.Text = "Customer Id:";
            label4.Visible = false;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(767, 362);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(122, 34);
            textBox2.TabIndex = 12;
            textBox2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(569, 362);
            label3.Name = "label3";
            label3.Size = new Size(170, 32);
            label3.TabIndex = 11;
            label3.Text = "Weight(kg):";
            label3.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(849, 293);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 34);
            textBox1.TabIndex = 10;
            textBox1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(569, 295);
            label2.Name = "label2";
            label2.Size = new Size(254, 32);
            label2.TabIndex = 9;
            label2.Text = "Tracking Number:";
            label2.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Add Package", "View All Packages", "Get Late Deliveries", "Get Packages By Type And Weight", "Get Unassigned Packages" });
            comboBox1.Location = new Point(609, 187);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(354, 44);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft New Tai Lue", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 64, 64);
            label1.Location = new Point(587, 96);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(402, 62);
            label1.TabIndex = 5;
            label1.Text = "Pick a command:";
            // 
            // PackagesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(142, 145, 144);
            ClientSize = new Size(1718, 1055);
            Controls.Add(panel1);
            Name = "PackagesForm";
            Text = "PackagesForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBox1;
        private Label label1;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox5;
        private Label label6;
        private TextBox textBox4;
        private Label label5;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label8;
        private Button button2;
        private Panel panel2;
        private ListBox listBox1;
        private Label label10;
        private Label label9;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label11;
        private Button button1;
    }
}