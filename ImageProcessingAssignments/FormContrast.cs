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
    public partial class FormContrast : Form
    {
        public FormContrast()
        {
            InitializeComponent();
        }

        public int Contrast
        {
            get
            {
                return int.Parse(txtContrast.Text);
            }
            set { txtContrast.Text = value.ToString(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
