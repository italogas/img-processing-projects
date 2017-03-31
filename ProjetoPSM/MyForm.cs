using ProjetoPSM;
using System;
using System.Diagnostics;
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
                lblImageUnderTest.Text = "Imagem Original: " + finfo.Name;
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

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            //MyImageProc.CovertToGray(bmpOrig);
            if (MyImageProc.GaussianFilter(bmpOrig, 5))
            {
                picEditedImage.Image = bmpOrig;
                outputImgDimensionsLabel.Text = "Altura: " + picEditedImage.Image.Height.ToString() + ", Largura: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Concluido!");
            }
        }

        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            //MyImageProc.CovertToGray(bmpOrig);
            if (MyImageProc.GaussianFilter(bmpOrig, 7))
            {
                picEditedImage.Image = bmpOrig;
                outputImgDimensionsLabel.Text = "Altura: " + picEditedImage.Image.Height.ToString() + ", Largura: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Concluido!");
            }
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            //MyImageProc.CovertToGray(bmpOrig);
            if (MyImageProc.GaussianFilter(bmpOrig, 3))
            {
                picEditedImage.Image = bmpOrig;
                outputImgDimensionsLabel.Text = "Altura: " + picEditedImage.Image.Height.ToString() + ", Largura: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Concluido!");
            }
        }

        private void edgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            MyImageProc.GaussianFilter(bmpOrig, 7);
            Bitmap result = MyImageProc.CartoonEffectFilter(bmpOrig, 100);
            picEditedImage.Image = result;
            outputImgDimensionsLabel.Text = "Altura: " + picEditedImage.Image.Height.ToString() + ", Largura: " + picEditedImage.Image.Width.ToString();
            MessageBox.Show("Concluido!");
        }
    }
}
