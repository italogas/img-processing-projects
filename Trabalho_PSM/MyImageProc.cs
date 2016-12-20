using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace ImageProcesing2010
{
    /// <summary>
    /// Summary description for MyImageProc.
    /// </summary>
    public class MyImageProc
    {
        //private int[,] GaussianKernel;

        public MyImageProc()
        {
            //
            // TODO: Add constructor logic here
            //
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
    }
}

