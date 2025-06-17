namespace CourierFirmForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CouriersForm couriersForm = new CouriersForm();
            couriersForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CouriersDeliveryRoutesForm couriersDeliveryRoutesForm = new CouriersDeliveryRoutesForm();
            couriersDeliveryRoutesForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PackagesForm packagesForm = new PackagesForm();
            packagesForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OfficesForm officesForm = new OfficesForm();
            officesForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CouriersVehiclesForm couriersVehiclesForm = new CouriersVehiclesForm();
            couriersVehiclesForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomersForm customersForm = new CustomersForm();
            customersForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeliveryRoutesForm deliveryRoutesForm = new DeliveryRoutesForm();
            deliveryRoutesForm.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VehiclesForm vehiclesForm = new VehiclesForm();
            vehiclesForm.Show();
            this.Hide();
        }
    }
}
