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
    public partial class FormResize : Form
    {
        public FormResize()
        {
            InitializeComponent();
        }

        public int newHeight
        {
            get
            {
                return int.Parse(txtNewHeight.Text);
            }
            set { txtNewHeight.Text = value.ToString(); }
        }

        public int newWidth
        {
            get
            {
                return int.Parse(txtNewWidth.Text);
            }
            set { txtNewWidth.Text = value.ToString(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
