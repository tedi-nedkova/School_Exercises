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
    public partial class DeliveryRoutesForm : Form
    {
        private CourierFirmDbContext context;
        private DeliveryRouteController routeController;

        public DeliveryRoutesForm()
        {
            context = new CourierFirmDbContext();
            routeController = new DeliveryRouteController(context);

            InitializeComponent();
        }

        private async void panel1_Paint(object sender, PaintEventArgs e)
        {
            int command = comboBox1.SelectedIndex;

            if (command == 0)
            {
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;

                panel3.Visible = false;
                textBox3.Visible = false;
                listBox2.Visible = false;
                button3.Visible = false;
                panel2.Visible = false;
                listBox1.Visible = false;
            }
            else if (command == 1)
            {
                label2.Visible = false;
                label3.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                panel3.Visible = false;
                textBox3.Visible = false;
                listBox2.Visible = false;
                button3.Visible = false;

                panel2.Visible = true;
                listBox1.Visible = true;

                List<DeliveryRoute> all = await routeController.GetAllAsync();

                foreach (var item in all)
                {
                    listBox1.Items.Add($"{item.StartLocation} -> {item.EndLocation}");
                    listBox1.Items.Add("");
                }
            }
            else if (command == 2)
            {
                label2.Visible = false;
                label3.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                panel2.Visible = false;
                listBox1.Visible = false;

                panel3.Visible = true;
                textBox3.Visible = true;
                listBox2.Visible = true;
                button3.Visible = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string startLocation = textBox1.Text;
                string endLocation = textBox2.Text;

                DeliveryRoute deliveryRoute = new DeliveryRoute
                {
                    StartLocation = startLocation,
                    EndLocation = endLocation
                };

                await routeController.AddAsync(deliveryRoute);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox3.Text;

                List<DeliveryRoute> deliveryRoutes = await routeController.GetDeliveryRouteByCourierName(name);

                foreach (var item in deliveryRoutes)
                {
                    listBox2.Items.Add($"{item.StartLocation} -> {item.EndLocation}");
                    listBox2.Items.Add("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
