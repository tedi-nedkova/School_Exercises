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
        public CouriersForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int commanad = comboBox1.SelectedIndex;

            if (commanad == 0)
            {

            }
            else if (commanad == 1)
            {

            }
            else if (commanad == 2)
            {

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
