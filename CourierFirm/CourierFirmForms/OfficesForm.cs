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
    public partial class OfficesForm : Form
    {
        private OfficeContoller officeContoller;
        private CourierFirmDbContext context;
        public OfficesForm()
        {
            context = new CourierFirmDbContext();
            officeContoller = new OfficeContoller(context);

            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string location = textBox2.Text;

                Office office = new Office
                {
                    Name = name,
                    Location = location,
                };

                await officeContoller.AddAsync(office);
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

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int command = comboBox1.SelectedIndex;

            if (command == 0)
            {
                label2.Visible = true;
                label3.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;

                panel2.Visible = false;
                listBox1.Visible = false;
                panel3.Visible = false;
                label4.Visible = false;
            }
            else if (command == 1)
            {
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                panel3.Visible = false;
                label4.Visible = true;

                panel2.Visible = true;
                listBox1.Visible = true;

                foreach (var item in await officeContoller.GetAllAsync())
                {
                    listBox1.Items.Add($"{item.Name} - {item.Location}");
                    listBox1.Items.Add("");
                }
            }
            else if(command == 2)
            {
                label2.Visible = false;
                label3.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                button1.Visible = false;
                panel2.Visible = false;
                listBox1.Visible = false;

                panel3.Visible = true;
                label4.Visible = true;

                Office office = await officeContoller.GetOfficeWithMostCouriers();

                label4.Text = $"{office.Name} - {office.Location}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Show();
        }
    }
}
