using ProjetoPSM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                lblImageUnderTest.Text = "Image Under Test: " + finfo.Name;
                inputImgDimensionsLabel.Text = "Height: " + picOrigImage.Image.Height.ToString() + ", Width: " + picOrigImage.Image.Width.ToString();
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

        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            MyImageProc.CovertToGray(bmpOrig);
            if (MyImageProc.GaussianFilter(bmpOrig))
            {
                picEditedImage.Image = bmpOrig;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }

        private void cannyEdgeDetectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[][] kernel = new double[3][];
            for (int i = 0; i < 3; i++)
                kernel[i] = new double[3];
            //Right Sobel (X direction):
            //  -1  0  1
            //  -2  0  2
            //  -1  0  1
            //Testing Gaussian 3x3
            //kernel[0][0] = 1.0;
            //kernel[0][1] = 2;
            //kernel[0][2] = 1.0;
            //kernel[1][0] = 2.0;
            //kernel[1][1] = 4;
            //kernel[1][2] = 2.0;
            //kernel[2][0] = 1.0;
            //kernel[2][1] = 2;
            //kernel[2][2] = 1.0;

            //Mean 3x3
            kernel[0][0] = 1.0;
            kernel[0][1] = 1.0;
            kernel[0][2] = 1.0;
            kernel[1][0] = 1.0;
            kernel[1][1] = 1.0;
            kernel[1][2] = 1.0;
            kernel[2][0] = 1.0;
            kernel[2][1] = 1.0;
            kernel[2][2] = 1.0;

            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            //MyImageProc.CovertToGray(bmp);
            //MyImageProc.GaussianFilter(bmp);
            if (MyImageProc.Convolve(bmp, kernel))
            {
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }

        private void yDirectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[][] kernel = new double[3][];
            for (int i = 0; i < 3; i++)
                kernel[i] = new double[3];
            //Sobel (Y direction):
            // -1 -2 -1
            //  0  0  0
            //  1  2  1
            //Sobel (fliped):
            //  1  2  1
            //  0  0  0
            // -1 -2 -1
            kernel[0][0] = 1.0;
            kernel[0][1] = 2.0;
            kernel[0][2] = 1.0;
            kernel[1][0] = 0;
            kernel[1][1] = 0;
            kernel[1][2] = 0;
            kernel[2][0] = -1.0;
            kernel[2][1] = -2.0;
            kernel[2][2] = -1.0;

            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            //MyImageProc.CovertToGray(bmp);
            MyImageProc.GaussianFilter(bmp);
            if (MyImageProc.Convolve(bmp, kernel))
            {
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }

        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[][] kernelX = new double[3][];
            for (int i = 0; i < 3; i++)
                kernelX[i] = new double[3];
            //Right Sobel (X direction):
            //  -1  0  1
            //  -2  0  2
            //  -1  0  1
            kernelX[0][0] = -1.0;
            kernelX[0][1] = 0;
            kernelX[0][2] = 1.0;
            kernelX[1][0] = -2.0;
            kernelX[1][1] = 0;
            kernelX[1][2] = 2.0;
            kernelX[2][0] = -1.0;
            kernelX[2][1] = 0;
            kernelX[2][2] = 1.0;

            double[][] kernelY = new double[3][];
            for (int i = 0; i < 3; i++)
                kernelY[i] = new double[3];
            //Sobel (Y direction):
            // -1 -2 -1
            //  0  0  0
            //  1  2  1
            //Sobel (fliped):
            //  1  2  1
            //  0  0  0
            // -1 -2 -1
            kernelY[0][0] = 1.0;
            kernelY[0][1] = 2.0;
            kernelY[0][2] = 1.0;
            kernelY[1][0] = 0;
            kernelY[1][1] = 0;
            kernelY[1][2] = 0;
            kernelY[2][0] = -1.0;
            kernelY[2][1] = -2.0;
            kernelY[2][2] = -1.0;

            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            MyImageProc.CovertToGray(bmp);
            MyImageProc.GaussianFilter(bmp);
            if (MyImageProc.Convolve(bmp, kernelX) && MyImageProc.Convolve(bmp, kernelY))
            {
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }

        private void nonMaximumSupressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            MyImageProc.CovertToGray(bmp);
            MyImageProc.GaussianFilter(bmp);
            if (MyImageProc.NonMaximumSupression(bmp))
            {
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }

        private void doubleThresholdingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);
                MyImageProc.CovertToGray(bmp);
                MyImageProc.GaussianFilter(bmp);
                MyImageProc.NonMaximumSupression(bmp);
                if (MyImageProc.doubleThresholding(bmp, 30, 80))
                {
                    picEditedImage.Image = bmp;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    MessageBox.Show("Done... ");
                }
            } catch (Exception ex)
            {
                Debug.Print(ex.Message); 
            }

        }
    }
}
