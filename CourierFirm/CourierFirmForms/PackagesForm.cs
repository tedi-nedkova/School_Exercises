using CourierFirm.Core.Controllers;
using CourierFirm.Data;
using CourierFirm.Data.Enum;

namespace CourierFirmForms
{
    public partial class PackagesForm : Form
    {
        private CourierFirmDbContext context;
        private PackageController packageController;
        public PackagesForm()
        {
            context = new CourierFirmDbContext();
            packageController = new PackageController(context);
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int command = comboBox1.SelectedIndex;

            if (command == 0)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                button2.Visible = true;
                comboBox2.Visible = true;

                panel2.Visible = false;
                listBox1.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                button1.Visible = false;

            }
            else if (command == 1)
            {
                listBox1.Items.Clear();

                panel2.Visible = true;
                listBox1.Visible = true;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
                comboBox2.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                button1.Visible = false;

                foreach (var item in await packageController.GetAllAsync())
                {
                    listBox1.Items.Add($"{item.TrackingNumber} - {item.DeliveryAddress}");
                }
            }
            else if (command == 2)
            {
                listBox1.Items.Clear();

                panel2.Visible = true;
                listBox1.Visible = true;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
                comboBox2.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                button1.Visible = false;

                foreach (var item in await packageController.GetLateDeliveries())
                {
                    listBox1.Items.Add($"{item.TrackingNumber} - {item.DeliveryAddress}");
                }
            }
            else if (command == 3)
            {
                panel2.Visible = true;
                listBox1.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                textBox9.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                button1.Visible = true;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
                comboBox2.Visible = false;
            }
            else if (command == 4)
            {
                listBox1.Items.Clear();

                panel2.Visible = true;
                listBox1.Visible = true;

                textBox1.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
                comboBox2.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                button1.Visible = false;

                foreach (var item in await packageController.GetUnassignedPackages())
                {
                    listBox1.Items.Add($"{item.TrackingNumber} - {item.DeliveryAddress}");
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string trackingNumber = textBox1.Text;
                int weight = int.Parse(textBox2.Text);
                int customerId = int.Parse(textBox3.Text);
                int courierId = int.Parse(textBox4.Text);
                string type = textBox5.Text;
                string deliveryAddress = textBox6.Text;
                string deliveryStatus = comboBox2.Text;
                _ = Enum.TryParse<DeliveryStatusType>(deliveryStatus, out DeliveryStatusType deliveryStatusAsEnum);
                Package package = new()
                {
                    TrackingNumber = trackingNumber,
                    WeightInKg = weight,
                    CustomerId = customerId,
                    CourierId = courierId,
                    Type = type,
                    DeliveryAddress = deliveryAddress,
                    DeliveryStatus = deliveryStatusAsEnum,
                };

                await packageController.AddAsync(package);
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
                textBox6.Text = "";
                comboBox2.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            try
            {
                string type = textBox7.Text;
                int minWeight = int.Parse(textBox8.Text);
                int maxWeight = int.Parse(textBox9.Text);

                foreach (var item in await packageController.GetPackagesByTypeAndWeight(type, minWeight, maxWeight))
                {
                    listBox1.Items.Add($"{item.TrackingNumber} - {item.DeliveryAddress}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
