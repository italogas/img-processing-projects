using ProjetoPSM;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ImageProcessingAssignments
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }

        private void load2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpeg files (*.jpg)|*.jpg|(*.gif)|gif||";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                this.picOrigImage.Image = new Bitmap(dialog.FileName);
                FileInfo finfo = new FileInfo(dialog.FileName);
                lblImageUnderTest.Text = "Imagem: " + finfo.Name;
                inputImgDimensionsLabel.Text = "Altura: " + picOrigImage.Image.Height.ToString() + ", Largura: " + picOrigImage.Image.Width.ToString();
                //txtHeightOrig.Text = picOrigImage.Image.Height.ToString();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "jpeg files (*.jpg)|*.jpg";
            if (DialogResult.OK == dlg.ShowDialog())
                this.picEditedImage.Image.Save(dlg.FileName, ImageFormat.Jpeg);
        }

        private void xDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[][] kernel = new double[3][];
            for (int i = 0; i < 3; i++)
                kernel[i] = new double[3];
            //Filtro:
            //  -1  0  1
            //  -2  0  2
            //  -1  0  1
            //Gaussiano 3x3
            kernel[0][0] = 1.0;
            kernel[0][1] = 2.0;
            kernel[0][2] = 1.0;
            kernel[1][0] = 2.0;
            kernel[1][1] = 4;
            kernel[1][2] = 2.0;
            kernel[2][0] = 1.0;
            kernel[2][1] = 2.0;
            kernel[2][2] = 1.0;

            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            //MyImageProc.CovertToGray(bmp);
            //MyImageProc.GaussianFilter(bmp);
            if (MyImageProc.Convolve(bmp, kernel))
            {
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Altura: " + picEditedImage.Image.Height.ToString() + ", Largura: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Concluido!");
            }
        }


    }
}
