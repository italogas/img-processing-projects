//-----------------MyImageProc.cs------------------------
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace ImageProcesing2010
{
    /// <summary>
    /// Summary description for MyImageProc.
    /// </summary>
    public class MyImageProc
    {
        public MyImageProc()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static Boolean GaussianFilter(Bitmap Data)
        {
            int KernelSize = 5;
            float Sigma = 1.4F;
            int KernelWeight = 1;

            int[,] GaussianKernel = GenerateGaussianKernel(KernelSize, Sigma, out KernelWeight);

            int i, j, k, l;
            int Limit = KernelSize / 2;

            float SumR = 0;
            float SumG = 0;
            float SumB = 0;

            for (i = Limit; i <= ((Data.Width - 1) - Limit); i++)
            {
                for (j = Limit; j <= ((Data.Height - 1) - Limit); j++)
                {
                    SumR = 0;
                    SumG = 0;
                    SumB = 0;
                    for (k = -Limit; k <= Limit; k++)
                    {
                        for (l = -Limit; l <= Limit; l++)
                        {
                            SumR = SumR + (((float)Data.GetPixel(i + k, j + l).R) * GaussianKernel[Limit + k, Limit + l]);
                            SumG = SumG + (((float)Data.GetPixel(i + k, j + l).G) * GaussianKernel[Limit + k, Limit + l]);
                            SumB = SumB + (((float)Data.GetPixel(i + k, j + l).B) * GaussianKernel[Limit + k, Limit + l]);

                        }
                    }
                    int R = (int)(Math.Round(SumR / (float)KernelWeight));
                    int G = (int)(Math.Round(SumG / (float)KernelWeight));
                    int B = (int)(Math.Round(SumB / (float)KernelWeight));

                    Color newColor = Color.FromArgb(R, G, B);
                    Data.SetPixel(i, j, newColor);
                }

            }

            return true;
        }

        public static int[,] GenerateGaussianKernel(int N, float S, out int Weight)
        {

            float Sigma = S;
            float pi;
            pi = (float)Math.PI;
            int i, j;
            int SizeofKernel = N;

            float[,] Kernel = new float[N, N];
            int[,] GaussianKernel = new int[N, N];
            float[,] OP = new float[N, N];
            float D1, D2;


            D1 = 1 / (2 * pi * Sigma * Sigma);
            D2 = 2 * Sigma * Sigma;

            float min = 1000;

            for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
            {
                for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
                {
                    Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = ((1 / D1) * (float)Math.Exp(-(i * i + j * j) / D2));
                    if (Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] < min)
                        min = Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];

                }
            }
            int mult = (int)(1 / min);
            int sum = 0;
            if ((min > 0) && (min < 1))
            {

                for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
                {
                    for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
                    {
                        Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (float)Math.Round(Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] * mult, 0);
                        GaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (int)Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                        sum = sum + GaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                    }

                }

            }
            else
            {
                sum = 0;
                for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
                {
                    for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
                    {
                        Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (float)Math.Round(Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j], 0);
                        GaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (int)Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                        sum = sum + GaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                    }

                }

            }
            //Normalizing kernel Weight
            Weight = sum;

            return GaussianKernel;
        }

        public static bool HistogramEqualization(Bitmap bmp)
        {
            try
            {
                uint pixels = (uint)bmp.Height * (uint)bmp.Width;
                decimal Const = 255 / (decimal)pixels;

                int[] redm = new int[pixels];
                int[] greenm = new int[pixels];
                int[] bluem = new int[pixels];
                int index = 0;
                for (int i = 0; i < bmp.Width; i++)
                {
                    for (int j = 0; j < bmp.Height; j++)
                    {
                        Color c1 = bmp.GetPixel(i, j);
                        redm[index] = (int)c1.R;
                        greenm[index] = (int)c1.G;
                        bluem[index] = (int)c1.B;
                        index++;
                    }
                }

                int[] cdfR = new int[256];
                int[] cdfG = new int[256];
                int[] cdfB = new int[256];

                for (int x = 0; x < pixels; x++)
                {
                    cdfR[redm[x]]++;
                    cdfG[greenm[x]]++;
                    cdfB[bluem[x]]++;
                }

                //Convert arrays to cumulative distribution frequency data
                for (int r = 1; r <= 255; r++)
                {
                    cdfR[r] = cdfR[r] + cdfR[r - 1];
                    cdfG[r] = cdfG[r] + cdfG[r - 1];
                    cdfB[r] = cdfB[r] + cdfB[r - 1];
                }

                //Convert Image according to cdf data
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        Color pixelColor = bmp.GetPixel(x, y);

                        int R = (int)((decimal)cdfR[pixelColor.R] * Const);
                        int G = (int)((decimal)cdfG[pixelColor.G] * Const);
                        int B = (int)((decimal)cdfB[pixelColor.B] * Const);

                        Color newColor = Color.FromArgb(R, G, B);
                        bmp.SetPixel(x, y, newColor);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return true;
        }

        public static bool Convolve(Bitmap b, double[][] kernel)
        {  // assumes kernel is symmetric or already rotated by 180 degrees
            //  the return format is BGR, NOT RGB.
            Bitmap bSrc = (Bitmap)b.Clone();
            BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                               ImageLockMode.ReadWrite,
                               PixelFormat.Format24bppRgb);

            int stride = bmData.Stride; // number of bytes in a row 3*b.Width + even bits
            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pc = (byte*)(void*)SrcScan0;

                byte red, green, blue;
                int nOffset = stride - b.Width * 3;
                for (int y = 0; y < b.Height - 2; ++y)
                {
                    for (int x = 0; x < b.Width - 2; ++x)
                    {
                        double[][] bluem = new double[3][];
                        for (int i = 0; i < 3; i++)
                            bluem[i] = new double[3];
                        double[][] greenm = new double[3][];
                        for (int i = 0; i < 3; i++)
                            greenm[i] = new double[3];
                        double[][] redm = new double[3][];
                        for (int i = 0; i < 3; i++)
                            redm[i] = new double[3];
                        bluem[0][0] = pc[0];
                        greenm[0][0] = pc[1];
                        redm[0][0] = pc[2];

                        bluem[0][1] = pc[3];
                        greenm[0][1] = pc[4];
                        redm[0][1] = pc[5];

                        bluem[0][2] = pc[6];
                        greenm[0][2] = pc[7];
                        redm[0][2] = pc[8];

                        bluem[1][0] = pc[0 + stride];
                        greenm[1][0] = pc[1 + stride];
                        redm[1][0] = pc[2 + stride];

                        bluem[1][1] = pc[3 + stride];
                        greenm[1][1] = pc[4 + stride];
                        redm[1][1] = pc[5 + stride];

                        bluem[1][2] = pc[6 + stride];
                        greenm[1][2] = pc[7 + stride];
                        redm[1][2] = pc[8 + stride];

                        bluem[2][0] = pc[0 + stride * 2];
                        greenm[2][0] = pc[1 + stride * 2];
                        redm[2][0] = pc[2 + stride * 2];

                        bluem[2][1] = pc[3 + stride * 2];
                        greenm[2][1] = pc[4 + stride * 2];
                        redm[2][1] = pc[5 + stride * 2];

                        bluem[2][2] = pc[6 + stride * 2];
                        greenm[2][2] = pc[7 + stride * 2];
                        redm[2][2] = pc[8 + stride * 2];

                        double cblue = bluem[0][0] * kernel[0][0] +
                            bluem[0][1] * kernel[0][1] +
                            bluem[0][2] * kernel[0][2] +
                            bluem[1][0] * kernel[1][0] +
                            bluem[1][1] * kernel[1][1] +
                            bluem[1][2] * kernel[1][2] +
                            bluem[2][0] * kernel[2][0] +
                            bluem[2][1] * kernel[2][1] +
                            bluem[2][2] * kernel[2][2];
                        double cgreen = greenm[0][0] * kernel[0][0] +
                           greenm[0][1] * kernel[0][1] +
                           greenm[0][2] * kernel[0][2] +
                           greenm[1][0] * kernel[1][0] +
                           greenm[1][1] * kernel[1][1] +
                           greenm[1][2] * kernel[1][2] +
                           greenm[2][0] * kernel[2][0] +
                           greenm[2][1] * kernel[2][1] +
                           greenm[2][2] * kernel[2][2];

                        double cred = redm[0][0] * kernel[0][0] +
                           redm[0][1] * kernel[0][1] +
                           redm[0][2] * kernel[0][2] +
                           redm[1][0] * kernel[1][0] +
                           redm[1][1] * kernel[1][1] +
                           redm[1][2] * kernel[1][2] +
                           redm[2][0] * kernel[2][0] +
                           redm[2][1] * kernel[2][1] +
                           redm[2][2] * kernel[2][2];

                        if (cblue < 0) cblue = 0;
                        if (cblue > 255) cblue = 255;
                        if (cgreen < 0) cgreen = 0;
                        if (cgreen > 255) cgreen = 255;
                        if (cred < 0) cred = 0;
                        if (cred > 255) cred = 255;

                        p[3 + stride] = (byte)cblue;
                        p[4 + stride] = (byte)cgreen;
                        p[5 + stride] = (byte)cred;

                        p += 3;
                        pc += 3;
                    }
                    p += nOffset;
                    pc += nOffset;
                }
            }
            b.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return true;
        }

        public static bool CovertToGray(Bitmap b)
        {
            //  the return format is BGR, NOT RGB. 
            /*	BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), 
					ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); 
				int stride = bmData.Stride; // number of bytes in a row 3*b.Width + even bits
				System.IntPtr Scan0 = bmData.Scan0; 
				unsafe 
				{ 
					byte * p = (byte *)(void *)Scan0;
					byte red, green, blue;
					int nOffset = stride - b.Width*3;
					for(int y=0;y < b.Height;++y)
					{
						for(int x=0; x < b.Width; ++x )
						{
							blue = p[0];
							green = p[1];
							red = p[2];
							p[0] = p[1] = p[2] = (byte)(.299 * red 
								+ .587 * green 
								+ .114 * blue);
							p += 3;
						}
						p += nOffset;
					}
				}
				b.UnlockBits(bmData);
				return true; */

            //		BitmapArr = new int[b.Width * b.Height];
            //		int k = 0;
            for (int i = 0; i < b.Width; i++)
                for (int j = 0; j < b.Height; j++)
                {
                    Color c1 = b.GetPixel(i, j);
                    int r1 = c1.R;
                    int g1 = c1.G;
                    int b1 = c1.B;
                    int gray = (byte)(.299 * r1
                        + .587 * g1
                        + .114 * b1);
                    r1 = gray;
                    g1 = gray;
                    b1 = gray;
                    //		BitmapArr[k++] = gray;

                    b.SetPixel(i, j, Color.FromArgb(r1, g1, b1));
                }
            return true;
        }


        public static Bitmap Brighten(Bitmap use, int nBrightness)
        {

            int Red, Green, Blue;
            if (nBrightness < -255 || nBrightness > 255)
                return use;

            Bitmap Bright = new Bitmap(use.Width, use.Height);
            for (int r = 0; r < use.Height; r++)
            {
                for (int c = 0; c < use.Width; c++)
                {
                    Color cr = use.GetPixel(c, r);
                    Red = nBrightness + Convert.ToInt32(cr.R);
                    Green = nBrightness + Convert.ToInt32(cr.G);
                    Blue = nBrightness + Convert.ToInt32(cr.B);

                    if (Red > 255) Red = 255;
                    if (Red < 0) Red = 0;
                    if (Green > 255) Green = 255;
                    if (Green < 0) Green = 0;
                    if (Blue > 255) Blue = 255;
                    if (Blue < 0) Blue = 0;

                    Bright.SetPixel(c, r, Color.FromArgb(Red, Green, Blue));

                }
            }

            return Bright;

        }

        public static Bitmap Contrast(Bitmap b, sbyte nContrast)
        {
            Bitmap Contrast = new Bitmap(b.Width, b.Height);

            if (nContrast < -100) nContrast = -100;
            if (nContrast > 100) nContrast = 100;

            double pixel = 0, contrast = (100.0 + nContrast) / 100.0;

            contrast *= contrast;

            int red, green, blue;

            for (int y = 0; y < b.Height; ++y)
            {
                for (int x = 0; x < b.Width; ++x)
                {
                    Color cr = b.GetPixel(x, y);

                    red = Convert.ToInt32(cr.R);
                    green = Convert.ToInt32(cr.G);
                    blue = Convert.ToInt32(cr.B);

                    pixel = red / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    red = (int)pixel;


                    pixel = green / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    green = (int)pixel;

                    pixel = blue / 255.0;
                    pixel -= 0.5;
                    pixel *= contrast;
                    pixel += 0.5;
                    pixel *= 255;
                    if (pixel < 0) pixel = 0;
                    if (pixel > 255) pixel = 255;
                    blue = (int)pixel;

                    Contrast.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }

            }

            return Contrast;
        }
        public static Bitmap RecoverBitmapFromArray(double[] BitmapArr, int w1, int h1)
        {

            Bitmap brecov = new Bitmap(w1, h1);
            int p = 0;
            int q = 0;
            for (int i = 0; i < BitmapArr.Length; i++)
            {
                int val = (int)(BitmapArr[i] / (1375669f * 900f));
                if (val < 0)
                    val = 0;
                //if (val > 255)
                //	val = 255;
                Color c1 = Color.FromArgb(val, val, val);
                brecov.SetPixel(p, q, c1);
                p++;
                if (p == w1)
                {
                    p = 0;
                    q++;
                }
            }
            return brecov;
        }


        public static bool RotateClear(Image img, ref Bitmap bm, double Rot)
        {
            if (Rot < -360 || Rot > 360)
                return false;
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.Clear(Color.White);
            dc.RotateTransform((float)Rot);
            //	dc.DrawImage(img,new Rectangle((int)Rot,(int)-Rot,img.Width,img.Height));
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

            return true;
        }

        public static bool RotateByPoints(Image img, ref Bitmap bm, Point p1, Point p2)
        {
            if ((p1.X == p2.X)) // no need to rotate
                return true;
            Point midPt = new Point();
            midPt.X = (int)((p1.X + p2.X) / 2.0);
            midPt.Y = (int)((p1.Y + p2.Y) / 2.0);
            double RotRadians = Math.Atan2(-(p2.Y - p1.Y), (p2.X - p1.X));
            Point newmidPt = new Point();
            newmidPt.X = (int)(midPt.X * Math.Cos(RotRadians) -
                midPt.Y * Math.Sin(RotRadians));
            newmidPt.Y = (int)(midPt.Y * Math.Cos(RotRadians) +
                midPt.X * Math.Sin(RotRadians));
            //MessageBox.Show(newmidPt.ToString());


            double Rot = RotRadians * 180 / 3.141516;
            return MyImageProc.RotateFill2(img, ref bm, Rot, midPt, newmidPt);
        }

        public static bool RotateFill(Image img, ref Bitmap bm, double Rot)
        {
            if (Rot < -360 || Rot > 360)
                return false;
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            dc.RotateTransform((float)Rot);
            double rdegrees = Rot * 3.141516 / 180;
            int shift = (int)(bm.Height / 2 * Math.Tan(rdegrees));
            if (rdegrees > 0)
                //dc.DrawImage(img,new Rectangle((int)shift-(int)(1.2*Rot),(int)-shift,img.Width,img.Height));
                dc.DrawImage(img, new Rectangle((int)shift, (int)-shift, img.Width, img.Height));
            else
                dc.DrawImage(img, new Rectangle((int)shift, (int)-shift / 2, img.Width, img.Height));
            return true;
        }

        public static bool RotateFill2(Image img, ref Bitmap bm, double Rot, Point mpt, Point newmpt)
        {
            if (Rot < -360 || Rot > 360)
                return false;
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            dc.RotateTransform((float)Rot);
            double rdegrees = Rot * 3.141516 / 180;
            int shift = (int)(bm.Height / 2 * Math.Tan(rdegrees));
            if (rdegrees > 0)
                //dc.DrawImage(img,new Rectangle((int)shift-(int)(1.2*Rot),(int)-shift,img.Width,img.Height));
                dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            else
                dc.DrawImage(img, new Rectangle(new Point(0, 0), new Size(img.Width, img.Height)));
            return true;
        }

        public static bool DrawRectangle(Image img, ref Bitmap bm, Rectangle rect)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            dc.DrawRectangle(new Pen(Color.Red), rect);
            return true;
        }

        public static bool DrawX(Image img, ref Bitmap bm, Point pt)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1 = new Point(pt.X - 3, pt.Y - 3);
            Point p2 = new Point(pt.X + 3, pt.Y + 3);
            dc.DrawLine(new Pen(Color.Blue), p1, p2);
            Point p3 = new Point(pt.X + 3, pt.Y - 3);
            Point p4 = new Point(pt.X - 3, pt.Y + 3);
            dc.DrawLine(new Pen(Color.Blue), p3, p4);

            //	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
            //		br,pt);
            return true;
        }

        public static bool Draw2X(Image img, ref Bitmap bm, Point pt1, Point pt2)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1a = new Point(pt1.X - 3, pt1.Y - 3);
            Point p2a = new Point(pt1.X + 3, pt1.Y + 3);
            dc.DrawLine(new Pen(Color.Red), p1a, p2a);
            Point p3a = new Point(pt1.X + 3, pt1.Y - 3);
            Point p4a = new Point(pt1.X - 3, pt1.Y + 3);
            dc.DrawLine(new Pen(Color.Red), p3a, p4a);

            Point p1b = new Point(pt2.X - 3, pt2.Y - 3);
            Point p2b = new Point(pt2.X + 3, pt2.Y + 3);
            dc.DrawLine(new Pen(Color.Red), p1b, p2b);
            Point p3b = new Point(pt2.X + 3, pt2.Y - 3);
            Point p4b = new Point(pt2.X - 3, pt2.Y + 3);
            dc.DrawLine(new Pen(Color.Red), p3b, p4b);

            //	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
            //		br,pt);
            return true;
        }

        public static bool Draw2Xbold(Image img, ref Bitmap bm, Point pt1, Point pt2)
        {
            bm = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            Brush br = new SolidBrush(Color.Red);
            Point p1a = new Point(pt1.X - 6, pt1.Y - 6);
            Point p2a = new Point(pt1.X + 6, pt1.Y + 6);
            dc.DrawLine(new Pen(Color.Red, 2), p1a, p2a);
            Point p3a = new Point(pt1.X + 6, pt1.Y - 6);
            Point p4a = new Point(pt1.X - 6, pt1.Y + 6);
            dc.DrawLine(new Pen(Color.Red, 2), p3a, p4a);

            Point p1b = new Point(pt2.X - 6, pt2.Y - 6);
            Point p2b = new Point(pt2.X + 6, pt2.Y + 6);
            dc.DrawLine(new Pen(Color.Red, 2), p1b, p2b);
            Point p3b = new Point(pt2.X + 6, pt2.Y - 6);
            Point p4b = new Point(pt2.X - 6, pt2.Y + 6);
            dc.DrawLine(new Pen(Color.Red, 2), p3b, p4b);

            //	dc.DrawString("x",new Font(FontFamily.GenericSansSerif,10),
            //		br,pt);
            return true;
        }

        public static bool ResizeImage(Image img, ref Bitmap bm, Rectangle rect)
        {
            bm = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            dc.DrawImage(img, rect);
            return true;
        }

        public static bool ResizeImageProportional(Image img, ref Bitmap bm, Rectangle rect)
        {
            Rectangle newR = new Rectangle(rect.X, rect.Y, rect.Width, img.Height * rect.Width / img.Width);
            bm = new Bitmap(newR.Width, newR.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bm);
            //dc.InterpolationMode = InterpolationMode.High;
            dc.DrawImage(img, newR);
            return true;
        }

        public static bool CropImage(Image img, ref Bitmap bm, Rectangle rect)
        {
            Bitmap bmpCrop = new Bitmap
                (rect.Width, rect.Height,
                img.PixelFormat);

            Graphics dc = Graphics.FromImage(bmpCrop);
            Rectangle recDest = new Rectangle(0, 0, rect.Width, rect.Height);

            dc.DrawImage(bm, recDest, rect.X, rect.Y, rect.Width, rect.Height,
                GraphicsUnit.Pixel);

            bm = bmpCrop;
            return true;
        }

        public static bool ShiftImageHorizontal(Image img, ref Bitmap bmp, int shiftAmt)
        {
            if (shiftAmt > img.Width)
                return false;
            //bmp = new Bitmap(img.Width + Math.Abs(shiftAmt), img.Height, PixelFormat.Format24bppRgb);
            bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bmp);
            dc.Clear(Color.White);
            dc.TranslateTransform(shiftAmt, 0);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return true;
        }

        public static bool ShiftImageVertical(Image img, ref Bitmap bmp, int shiftAmt)
        {
            if (shiftAmt > img.Height)
                return false;
            //bmp = new Bitmap(img.Width, img.Height + Math.Abs(shiftAmt), PixelFormat.Format24bppRgb);
            bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
            Graphics dc = Graphics.FromImage(bmp);
            dc.Clear(Color.White);
            dc.TranslateTransform(0, shiftAmt);
            dc.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));
            return true;
        }
    }
}

