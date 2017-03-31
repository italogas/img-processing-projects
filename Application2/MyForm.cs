using ProjetoPSM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void convertToGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.picEditedImage.Image = this.picOrigImage.Image;

            try
            {
                Bitmap copy = new Bitmap((Bitmap)this.picOrigImage.Image);
                MyImageProc.CovertToGray(copy);
                picEditedImage.Image = null;
                picEditedImage.Image = copy;
                //txtWidthProc.Text = picEditedImage.Image.Width.ToString();
                //txtHeightProc.Text = picEditedImage.Image.Height.ToString();
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void brightenImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBrightness dlg = new FormBrightness();
            dlg.Brightness = 30;  // default brightness of 30

            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    Bitmap copy = new Bitmap((Bitmap)this.picOrigImage.Image);
                    copy = MyImageProc.Brighten(copy, dlg.Brightness);

                    picEditedImage.Image = null;
                    picEditedImage.Image = copy;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    //txtWidthProc.Text = picProcImage.Image.Width.ToString();
                    //txtHeightProc.Text = picProcImage.Image.Height.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void contrastImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContrast dlg = new FormContrast();
            dlg.Contrast = 0;  // default contrast of 0

            if (DialogResult.OK == dlg.ShowDialog())
            {
                try
                {
                    Bitmap copy = new Bitmap((Bitmap)this.picOrigImage.Image);
                    copy = MyImageProc.Contrast(copy, (sbyte)dlg.Contrast);

                    picEditedImage.Image = null;
                    picEditedImage.Image = copy;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    //txtWidthProc.Text = picProcImage.Image.Width.ToString();
                    //txtHeightProc.Text = picProcImage.Image.Height.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "jpeg files (*.jpg)|*.jpg";
            if (DialogResult.OK == dlg.ShowDialog())
                this.picEditedImage.Image.Save(dlg.FileName, ImageFormat.Jpeg);
        }

        private void shiftHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShift dlg = new FormShift();
            dlg.ShiftAmount = 0;
            Image origimg = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origimg);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (MyImageProc.ShiftImageHorizontal(origimg, ref bmp, dlg.ShiftAmount))
                {
                    picEditedImage.Image = null;
                    picEditedImage.Image = bmp;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    //txtWidthProc.Text = picProcImage.Image.Width.ToString();
                    //txtHeightProc.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void shiftVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShift dlg = new FormShift();
            dlg.ShiftAmount = 0;
            Image origimg = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origimg);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                if (MyImageProc.ShiftImageVertical(origimg, ref bmp, dlg.ShiftAmount))
                {
                    picEditedImage.Image = null;
                    picEditedImage.Image = bmp;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    //txtWidthProc.Text = picProcImage.Image.Width.ToString();
                    //txtHeightProc.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void rotateClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRotate frmRotate = new FormRotate();
            frmRotate.RotationAngle = 0;
            Image origimg = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origimg);
            if (DialogResult.OK == frmRotate.ShowDialog())
            {
                if (MyImageProc.RotateClear(origimg, ref bmp, frmRotate.RotationAngle))
                {
                    picEditedImage.Image = null;
                    picEditedImage.Image = bmp;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    //txtWidthProc.Text = picProcImage.Image.Width.ToString();
                    //txtHeightProc.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void rotateFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRotate frmRotate = new FormRotate();
            frmRotate.RotationAngle = 0;
            Image origimg = picOrigImage.Image;
            Bitmap bmp = new Bitmap(origimg);
            if (DialogResult.OK == frmRotate.ShowDialog())
            {
                if (MyImageProc.RotateFill(origimg, ref bmp, frmRotate.RotationAngle))
                {
                    picEditedImage.Image = null;
                    picEditedImage.Image = bmp;
                    outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    //txtWidthProc.Text = picProcImage.Image.Width.ToString();
                    //txtHeightProc.Text = picProcImage.Image.Height.ToString();
                }
            }
        }

        private void resizeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //modeRectangle = false;
                FormResize formResize = new FormResize();
                formResize.newHeight = 0;
                formResize.newWidth = 0;
                if (DialogResult.OK == formResize.ShowDialog())
                {
                    int Width = formResize.newHeight;
                    int Height = formResize.newWidth;
                    Rectangle rect = new Rectangle(new Point(0, 0), new Size(Width, Height));
                    Image img = this.picOrigImage.Image;
                    Bitmap bmp = new Bitmap(img);
                    if (MyImageProc.ResizeImageProportional(img, ref bmp, rect))
                    {
                        picEditedImage.Image = null;
                        picEditedImage.Image = bmp;
                        outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kernel1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double[][] kernel = new double[3][];
                for (int i = 0; i < 3; i++)
                    kernel[i] = new double[3];
                kernel[0][0] = 1 / 9.0;
                kernel[0][1] = 1 / 9.0;
                kernel[0][2] = 1 / 9.0;
                kernel[1][0] = 1 / 9.0;
                kernel[1][1] = 1 / 9.0;
                kernel[1][2] = 1 / 9.0;
                kernel[2][0] = 1 / 9.0;
                kernel[2][1] = 1 / 9.0;
                kernel[2][2] = 1 / 9.0;

                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);
                Bitmap bmpOrig = (Bitmap)bmp.Clone();
                MyImageProc.CovertToGray(bmp);
                MyImageProc.Convolve(bmp, kernel);
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kernel3GaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //double[][] kernel = new double[3][];
                //for (int i = 0; i < 3; i++)
                //    kernel[i] = new double[3];
                //3x3 Gaussian filter:
                //  1/16 2/16 1/16
                //  2/16 4/16 2/16
                //  1/16 2/16 1/16
                //kernel[0][0] = 1 / 16;
                //kernel[0][1] = 2 / 16;
                //kernel[0][2] = 1 / 16;
                //kernel[1][0] = 2 / 16;
                //kernel[1][1] = 4 / 16;
                //kernel[1][2] = 2 / 16;
                //kernel[2][0] = 1 / 16;
                //kernel[2][1] = 2 / 16;
                //kernel[2][2] = 1 / 16;

                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);
                MyImageProc.CovertToGray(bmp);
                //MyImageProc.Convolve(bmp, kernel);
                MyImageProc.GaussianFilter(bmp);
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void topSobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double[][] kernel = new double[3][];
                for (int i = 0; i < 3; i++)
                    kernel[i] = new double[3];
                //Sobel:
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
                MyImageProc.CovertToGray(bmp);
                MyImageProc.Convolve(bmp, kernel);
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void leftSobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double[][] kernel = new double[3][];
                for (int i = 0; i < 3; i++)
                    kernel[i] = new double[3];
                //Left Sobel:
                //  1  0  -1
                //  2  0  -2
                //  1  0  =1
                kernel[0][0] = 1.0;
                kernel[0][1] = 0;
                kernel[0][2] = -1.0;
                kernel[1][0] = 2.0;
                kernel[1][1] = 0;
                kernel[1][2] = -2.0;
                kernel[2][0] = -1.0;
                kernel[2][1] = 0;
                kernel[2][2] = -1.0;

                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);
                MyImageProc.CovertToGray(bmp);
                MyImageProc.Convolve(bmp, kernel);
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rightSobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                double[][] kernel = new double[3][];
                for (int i = 0; i < 3; i++)
                    kernel[i] = new double[3];
                //Right Sobel:
                //  -1  0  1
                //  -2  0  2
                //  -1  0  1
                kernel[0][0] = -1.0;
                kernel[0][1] = 0;
                kernel[0][2] = 1.0;
                kernel[1][0] = -2.0;
                kernel[1][1] = 0;
                kernel[1][2] = 2.0;
                kernel[2][0] = -1.0;
                kernel[2][1] = 0;
                kernel[2][2] = 1.0;

                Image img = this.picOrigImage.Image;
                Bitmap bmp = new Bitmap(img);
                MyImageProc.CovertToGray(bmp);
                MyImageProc.Convolve(bmp, kernel);
                picEditedImage.Image = bmp;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void convertToGrayFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            MyImageProc.CovertToGray(bmpOrig);
            if (MyImageProc.HistogramEqualization(bmpOrig))
            {
                picEditedImage.Image = bmpOrig;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }

        private void usingOriginalImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image img = this.picOrigImage.Image;
            Bitmap bmp = new Bitmap(img);
            Bitmap bmpOrig = (Bitmap)bmp.Clone();
            if (MyImageProc.HistogramEqualization(bmpOrig))
            {
                picEditedImage.Image = bmpOrig;
                outputImgDimensionsLabel.Text = "Height: " + picEditedImage.Image.Height.ToString() + ", Width: " + picEditedImage.Image.Width.ToString();
                MessageBox.Show("Done... ");
            }
        }
    }
}
