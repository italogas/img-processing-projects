//-----------------MyImageProc.cs------------------------
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ProjetoPSM
{
    /// <summary>
    /// Summary description for MyImageProc.
    /// </summary>
    public static class MyImageProc
    {

        public static Boolean GaussianFilter(Bitmap Data, int KernelSize)
        {
            
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

        public static Bitmap CartoonEffectFilter(Bitmap sourceBitmap, byte threshold = 0)
        {
            //sourceBitmap = sourceBitmap.SmoothingFilter(smoothFilter);
            Console.Write("Cheguei aqui! ");

            //Bitmap bSrc = (Bitmap)sourceBitmap.Clone();
            //BitmapData bmData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
            //                    ImageLockMode.ReadWrite,
            //                    PixelFormat.Format32bppArgb);
            //BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
            //                   ImageLockMode.ReadWrite,
            //                   PixelFormat.Format32bppArgb);

            BitmapData bmData = sourceBitmap.LockBits(new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                                                            ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[bmData.Stride * bmData.Height];
            byte[] resultBuffer = new byte[bmData.Stride * bmData.Height];
            //System.IntPtr Scan0 = bmData.Scan0;
            //System.IntPtr SrcScan0 = bmSrc.Scan0;
            System.Runtime.InteropServices.Marshal.Copy(bmData.Scan0, pixelBuffer, 0, pixelBuffer.Length);

            //sourceBitmap.UnlockBits(bmData);
            sourceBitmap.UnlockBits(bmData);
            Console.Write("Cheguei aqui 2: unsafe! ");
            //unsafe
            //{
                //byte* pixelBuffer = (byte*)(void*)Scan0;
                //byte* resultBuffer = (byte*)(void*)SrcScan0;


                int byteOffset = 0;
                int blueGradient, greenGradient, redGradient = 0;
                double blue = 0, green = 0, red = 0;

                bool exceedsThreshold = false;

                for (int offsetY = 1; offsetY < sourceBitmap.Height - 1; offsetY++)
                {
                    for (int offsetX = 1; offsetX < sourceBitmap.Width - 1; offsetX++)
                    {
                        byteOffset = offsetY * bmData.Stride + offsetX * 4;

                        blueGradient = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                        blueGradient += Math.Abs(pixelBuffer[byteOffset - bmData.Stride] - pixelBuffer[byteOffset + bmData.Stride]);

                        byteOffset++;

                        greenGradient = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                        greenGradient += Math.Abs(pixelBuffer[byteOffset - bmData.Stride] - pixelBuffer[byteOffset + bmData.Stride]);

                        byteOffset++;

                        redGradient = Math.Abs(pixelBuffer[byteOffset - 4] - pixelBuffer[byteOffset + 4]);

                        redGradient += Math.Abs(pixelBuffer[byteOffset - bmData.Stride] - pixelBuffer[byteOffset + bmData.Stride]);

                        if (blueGradient + greenGradient + redGradient > threshold)
                        { exceedsThreshold = true; }
                        else
                        {
                            byteOffset -= 2;

                            blueGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                    pixelBuffer[byteOffset + 4]);
                            byteOffset++;

                            greenGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                     pixelBuffer[byteOffset + 4]);
                            byteOffset++;

                            redGradient = Math.Abs(pixelBuffer[byteOffset - 4] -
                                                   pixelBuffer[byteOffset + 4]);

                            if (blueGradient + greenGradient + redGradient > threshold)
                            { exceedsThreshold = true; }
                            else
                            {
                                byteOffset -= 2;

                                blueGradient =
                                Math.Abs(pixelBuffer[byteOffset - bmData.Stride] -
                                pixelBuffer[byteOffset + bmData.Stride]);

                                byteOffset++;

                                greenGradient =
                                Math.Abs(pixelBuffer[byteOffset - bmData.Stride] -
                                pixelBuffer[byteOffset + bmData.Stride]);

                                byteOffset++;

                                redGradient =
                                Math.Abs(pixelBuffer[byteOffset - bmData.Stride] -
                                pixelBuffer[byteOffset + bmData.Stride]);

                                if (blueGradient + greenGradient +
                                          redGradient > threshold)
                                { exceedsThreshold = true; }
                                else
                                {
                                    byteOffset -= 2;

                                    blueGradient =
                                    Math.Abs(pixelBuffer[byteOffset - 4 - bmData.Stride] -
                                    pixelBuffer[byteOffset + 4 + bmData.Stride]);

                                    blueGradient +=
                                    Math.Abs(pixelBuffer[byteOffset - bmData.Stride + 4] -
                                    pixelBuffer[byteOffset + bmData.Stride - 4]);

                                    byteOffset++;

                                    greenGradient =
                                    Math.Abs(pixelBuffer[byteOffset - 4 - bmData.Stride] -
                                    pixelBuffer[byteOffset + 4 + bmData.Stride]);

                                    greenGradient +=
                                    Math.Abs(pixelBuffer[byteOffset - bmData.Stride + 4] -
                                    pixelBuffer[byteOffset + bmData.Stride - 4]);

                                    byteOffset++;

                                    redGradient =
                                    Math.Abs(pixelBuffer[byteOffset - 4 - bmData.Stride] -
                                    pixelBuffer[byteOffset + 4 + bmData.Stride]);

                                    redGradient +=
                                    Math.Abs(pixelBuffer[byteOffset - bmData.Stride + 4] -
                                    pixelBuffer[byteOffset + bmData.Stride - 4]);

                                    if (blueGradient + greenGradient + redGradient > threshold)
                                    { exceedsThreshold = true; }
                                    else
                                    { exceedsThreshold = false; }
                                }
                            }
                        }

                        byteOffset -= 2;

                        if (exceedsThreshold)
                        {
                            blue = 0;
                            green = 0;
                            red = 0;
                        }
                        else
                        {
                            blue = pixelBuffer[byteOffset];
                            green = pixelBuffer[byteOffset + 1];
                            red = pixelBuffer[byteOffset + 2];
                        }

                        blue = (blue > 255 ? 255 :
                               (blue < 0 ? 0 :
                                blue));

                        green = (green > 255 ? 255 :
                                (green < 0 ? 0 :
                                 green));

                        red = (red > 255 ? 255 :
                              (red < 0 ? 0 :
                               red));

                        resultBuffer[byteOffset] = (byte)blue;
                        resultBuffer[byteOffset + 1] = (byte)green;
                        resultBuffer[byteOffset + 2] = (byte)red;
                        resultBuffer[byteOffset + 3] = 255;
                        //Console.Write("Cheguei aqui 3: result buffer! ");
                    }
                }
            //}

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), 
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            System.Runtime.InteropServices.Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            //Marshal.Copy(resultBuffer, 0, resultData.Scan0,
            //                                       resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);
            //sourceBitmap = resultBitmap;
            //sourceBitmap.UnlockBits(bmData);
            //bSrc.UnlockBits(bmData);
            Console.Write("Cheguei aqui 4: return ");
            return resultBitmap;
        }

    }
}

