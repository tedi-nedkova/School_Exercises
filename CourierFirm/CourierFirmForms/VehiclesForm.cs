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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CourierFirmForms
{
    public partial class VehiclesForm : Form
    {
        private CourierFirmDbContext context;
        private VehicleController vehicleController;

        public VehiclesForm()
        {
            context = new CourierFirmDbContext();
            vehicleController = new VehicleController(context);
            InitializeComponent();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int command = comboBox1.SelectedIndex;

            if (command == 0)
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;

                panel2.Visible = false;
                textBox6.Visible = false;
                button2.Visible = false;
                listBox1.Visible = false;
            }
            else if (command == 1)
            {
                listBox1.Items.Clear();

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox6.Visible = false;
                button2.Visible = false;

                panel2.Visible = true;
                textBox1.Visible = true;
                listBox1.Visible = true;

                List<Vehicle> list = await vehicleController.GetAllAsync();

                foreach (var item in list)
                {
                    listBox1.Items.Add($"{item.PlateNumber} - {item.Model} - {item.Type}");
                }
            }
            else if (command == 2)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;

                panel2.Visible = true;
                textBox6.Visible = true;
                button2.Visible = true;
                listBox1.Visible = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string plateNumber = textBox1.Text;
                string model = textBox2.Text;
                string type = textBox3.Text;

                Vehicle vehicle = new Vehicle()
                {
                    PlateNumber = plateNumber,
                    Model = model,
                    Type = type
                };

                await vehicleController.AddAsync(vehicle);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

        }

        private async void button2_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();

                int id = int.Parse(textBox6.Text);

                foreach (var item in await vehicleController.GetVehiclesByCourierId(id))
                {
                    listBox1.Items.Add($"{item.PlateNumber} - {item.Model} - {item.Type}");
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
    }
}
