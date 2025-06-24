using CourierFirm.Core.Controllers;
using CourierFirm.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    public partial class CustomersForm : Form
    {

        private CourierFirmDbContext context;
        private CustomerController customerController;

        public CustomersForm()
        {
            context = new CourierFirmDbContext();
            customerController = new CustomerController(context);
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int command = int.Parse(comboBox1.SelectedIndex.ToString());

            if (command == 0)
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                button2.Visible = true;

                listBox1.Visible = false;
                panel2.Visible = false;
            }
            else if (command == 1)
            {
                listBox1.Items.Clear();

                listBox1.Visible = true;
                panel2.Visible = true;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button2.Visible = false;

                foreach (var item in await customerController.GetAllAsync())
                {
                    listBox1.Items.Add($"{item.FirstName} {item.LastName} - {item.Email} - {item.PhoneNumber} - {item.Address}");
                    listBox1.Items.Add(" ");
                }
            }
            else if (command == 2)
            {
                listBox1.Items.Clear();

                listBox1.Visible = true;
                panel2.Visible = true;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button2.Visible = false;

                foreach (var item in await customerController.GetCustomersWithActiveDeliveries())
                {
                    listBox1.Items.Add($"{item.FirstName} {item.LastName} - {item.Email} - {item.PhoneNumber} - {item.Address}");
                    listBox1.Items.Add(" ");
                }
            }
            else if (command == 3)
            {
                listBox1.Items.Clear();

                listBox1.Visible = true;
                panel2.Visible = true;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button2.Visible = false;

                foreach (var item in await customerController.GetTopFiveCustomersByPackagesCount())
                {
                    listBox1.Items.Add($"{item.FirstName} {item.LastName} - {item.Email} - {item.PhoneNumber} - {item.Address}");
                    listBox1.Items.Add(" ");
                }
            }
            else if (command == 4)
            {
                listBox1.Items.Clear();

                listBox1.Visible = true;
                panel2.Visible = true;
                button1.Visible = true;
                textBox6.Visible = true;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                button2.Visible = false;

            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string firstname = textBox1.Text;
                string lastName = textBox2.Text;
                string email = textBox3.Text;
                string phoneNumber = textBox4.Text;
                string address = textBox5.Text;

                Customer customer = new Customer()
                {
                    FirstName = firstname,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Address = address,
                };

                await customerController.AddAsync(customer);
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
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            try
            {
                string name = textBox6.Text;

                foreach (var item in await customerController.GetCustomersByCourierName(name))
                {
                    listBox1.Items.Add($"{item.FirstName} {item.LastName} - {item.Email} - {item.PhoneNumber} - {item.Address}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
