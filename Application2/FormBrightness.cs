using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingAssignments
{
    public partial class FormBrightness : Form
    {
        public FormBrightness()
        {
            InitializeComponent();
        }

        public int Brightness
        {
            get
            {
                return int.Parse(txtBrightness.Text);
            }
            set { txtBrightness.Text = value.ToString(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
