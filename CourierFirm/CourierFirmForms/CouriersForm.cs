using CourierFirm.Core.Controllers;
using CourierFirm.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourierFirmForms
{
    public partial class CouriersForm : Form
    {
        private readonly CourierFirmDbContext courierFirmDbContext;
        private CourierController courierController;
        public CouriersForm()
        {
            courierFirmDbContext = new CourierFirmDbContext();
            courierController = new CourierController(courierFirmDbContext);
            InitializeComponent();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int command = comboBox1.SelectedIndex;

            if (command == 0)
            {
                textBox2.Visible = true;
                textBox3.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button1.Visible = true;

                panel2.Visible = false;
                listBox1.Visible = false;
                listBox2.Visible = false;
                textBox5.Visible = false;
                panel3.Visible = false;
                button2.Visible = false;
                textBox7.Visible = false;
                label8.Visible = false;
                label6.Visible = false;
                textBox6.Visible = false;
                button4.Visible = false;
            }
            else if (command == 1)
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                button1.Visible = false;
                listBox2.Visible = false;
                textBox5.Visible = false;
                panel3.Visible = false;
                button2.Visible = false;
                textBox7.Visible = false;
                label8.Visible = false;
                label6.Visible = false;
                textBox6.Visible = false;
                button4.Visible = false;

                panel2.Visible = true;
                listBox1.Visible = true;

                foreach (var item in await courierController.GetAllAsync())
                {
                    listBox1.Items.Add($"{item.Name} - {item.Office.Name}");
                    listBox1.Items.Add("");
                }
            }
            else if (command == 2)
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                button1.Visible = false;
                panel2.Visible = false;
                listBox1.Visible = false;
                textBox7.Visible = false;
                label8.Visible = false;
                label6.Visible = false;
                textBox6.Visible = false;
                button4.Visible = false;

                listBox2.Visible = true;
                textBox5.Visible = true;
                panel3.Visible = true;
                button2.Visible = true;
            }
            else if (command == 3)
            {
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                button1.Visible = false;
                panel2.Visible = false;
                listBox1.Visible = false;
                listBox2.Visible = false;
                textBox5.Visible = false;
                panel3.Visible = false;
                button2.Visible = false;

                textBox7.Visible = true;
                label8.Visible = true;
                label6.Visible = true;
                textBox6.Visible = true;
                button4.Visible = true;
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Courier courier = new Courier
                {
                    Name = textBox2.Text,
                    OfficeId = int.Parse(textBox3.Text),
                };

                await courierController.AddAsync(courier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                int vehicleId = int.Parse(textBox5.Text);

                List<Courier> list = await courierController.GetCouriersByVehicleId(vehicleId);

                foreach (var item in list)
                {
                    listBox2.Items.Add($"{item.Id} - {item.Name}");
                    listBox2.Items.Add(" ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int vehicleId = int.Parse(textBox6.Text);

                int courierId = int.Parse(textBox7.Text);

                await courierController.AssignCouriersVehicle(vehicleId, courierId);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox6.Text = "";
                textBox7.Text = "";
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
