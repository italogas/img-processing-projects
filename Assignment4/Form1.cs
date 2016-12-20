using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCALib;
using System.Diagnostics;

namespace Assignment4
{
    public partial class MyForm : Form
    {
        List<Point> Shape1 = new List<Point>();
        List<Point> Shape2 = new List<Point>();

        public MyForm()
        {
            InitializeComponent();
        }

        private void initializeShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shape1.Clear();
            Shape2.Clear();
            Point p1a = new Point(20, 30);
            Point p2a = new Point(120, 50);
            Point p3a = new Point(160, 80);
            Point p4a = new Point(180, 300);
            Point p5a = new Point(100, 220);
            Point p6a = new Point(50, 280);
            Point p7a = new Point(20, 140);
            Shape1.Add(p1a); Shape1.Add(p2a);
            Shape1.Add(p3a); Shape1.Add(p4a);
            Shape1.Add(p5a); Shape1.Add(p6a);
            Shape1.Add(p7a);

            Transformation T2 = new Transformation();
            T2.A = 1.05; T2.B = 0.05; T2.T1 = 15; T2.T2 = 22;
            Shape2 = ApplyTransformation(T2, Shape1);
            Shape2[2] = new Point(Shape2[2].X + 10, Shape2[2].Y + 3); // change one point

            Pen pBlue = new Pen(Brushes.Blue, 1);
            Pen pRed = new Pen(Brushes.Red, 1);
            Graphics g = panShape1.CreateGraphics();
            DisplayShape(Shape1, pBlue, g);
            DisplayShape(Shape2, pRed, g);
        }

        private List<Point> ApplyTransformation(Transformation t2, List<Point> shape)
        {
            List<Point> new_shape = new List<Point>();
            Point[] temp = shape.ToArray();
            int length = temp.Length;
            for (int i=0; i < length; i++)
            {
                int X = (int)((t2.A * temp[i].X) + (t2.B  * temp[i].Y) + t2.T1);
                int Y = (int)(((-1)*t2.B * temp[i].X) + (t2.A * temp[i].Y) + t2.T2);
                Point p = new Point(X, Y);
                new_shape.Add(p);
            }
            return new_shape;
        }

        void DisplayShape(List<Point> Shp, Pen pen, Graphics g)
        {
            Point? prevPoint = null; // nullable
            foreach (Point pt in Shp)
            {
                g.DrawEllipse(pen, new Rectangle(pt.X - 2, pt.Y - 2, 4, 4));
                if (prevPoint != null)
                    g.DrawLine(pen, (Point)prevPoint, pt);
                prevPoint = pt;
            }
            g.DrawLine(pen, Shp[0], Shp[Shp.Count - 1]);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void applyTransformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Matriz A:
            // 2x1x2 + 2y1y2
            // -2x2y1 + 2y2x1 
            // 2x1 
            // 2y1 
            //Matrix B:
            //(2x2**2 + 2y2**2) 0                 2x2 2y2
            //0                 (2x2**2 - 2y2**2) 2y2 -2x2
            //2x2               2y2               2   0 
            //2y2               2x2               0   2
            double[][] A = new double[1][];
            A[0] = new double[4];
            A[0][0] = 0; A[0][1] = 0; A[0][2] = 0; A[0][3] = 0;
            Point[] shape1 = Shape1.ToArray();
            Point[] shape2 = Shape2.ToArray();
            int length = shape1.Length;
            for (int i = 0; i < length; i++)
            {
                double a1 = (2 * shape1[i].X * shape2[i].X) + (2 * shape1[i].Y * shape2[i].Y);
                double a2 = ((-2) * shape1[i].Y * shape2[i].X) + (2 * shape1[i].X * shape2[i].Y);
                double a3 = (2 * shape1[i].X);
                double a4 = (2 * shape1[i].Y);
                A[0][0] += a1; A[0][1] += a2; A[0][2] += a3; A[0][3] += a4;
            }

            double[][] B = new double[4][];
            for (int x = 0; x<4; x++)
            {
                B[x] = new double[4];
                B[x][0] = 0; B[x][1] = 0; B[x][2] = 0; B[x][3] = 0;
            }

            int length2 = shape2.Length;
            for (int i = 0; i < length2; i++)
            {
                double b1b1 = (2 * shape2[i].X * shape2[i].X) + (2 * shape2[i].Y * shape2[i].Y);
                double b1b2 = 0;
                double b1b3 = (2 * shape2[i].X);
                double b1b4 = (2 * shape2[i].Y);
                double b2b1 = 0;
                double b2b2 = (2 * shape2[i].X * shape2[i].X) - (2 * shape2[i].Y * shape2[i].Y);
                double b2b3 = (2 * shape2[i].Y);
                double b2b4 = ((-2) * shape2[i].Y);
                double b3b1 = (2 * shape2[i].X);
                double b3b2 = (2 * shape2[i].Y);
                double b3b3 = 2;
                double b3b4 = 0;
                double b4b1 = (2 * shape2[i].Y);
                double b4b2 = (2 * shape2[i].X);
                double b4b3 = 0;
                double b4b4 = 2;
                B[0][0] += b1b1; B[0][1] += b1b2; B[0][2] += b1b3; B[0][3] += b1b4;
                B[1][0] += b2b1; B[1][1] += b2b2; B[1][2] += b2b3; B[1][3] += b2b4;
                B[2][0] += b3b1; B[2][1] += b3b2; B[2][2] += b3b3; B[2][3] += b3b4;
                B[3][0] += b4b1; B[3][1] += b4b2; B[3][2] += b4b3; B[3][3] += b4b4;
            }

            //names may be inverted
            PCALib.Matrix matrixA = new PCALib.Matrix(A);
            PCALib.Matrix matrixB = new PCALib.Matrix(B);
            PCALib.Matrix matrixATrans = (PCALib.Matrix) matrixA.Transpose();
            PCALib.Matrix matrixBInv = (PCALib.Matrix)matrixB.Inverse;

            Debug.Print("Matrix A (Transpose): ");
            Debug.Print(matrixATrans.ToString());
            Debug.Print("Matrix B: ");
            Debug.Print(matrixB.ToString());

            PCALib.Matrix matrixTransformationValues = (PCALib.Matrix) matrixBInv.Multiply(matrixATrans);

            Debug.Print("Matrix Transformation: ");
            Debug.Print(matrixTransformationValues.ToString());

            Transformation T2 = new Transformation();
            T2.A = matrixTransformationValues[0,0]; 
            T2.B = matrixTransformationValues[1,0];
            T2.T1 = matrixTransformationValues[2,0];
            T2.T2 = matrixTransformationValues[3,0];

            Shape2 = ApplyTransformation(T2, Shape2);

            Pen pRed = new Pen(Brushes.Red, 1);
            Pen pBlack = new Pen(Brushes.Black, 1);
            Graphics g = panShape2.CreateGraphics();
            DisplayShape(Shape1, pRed, g);
            DisplayShape(Shape2, pBlack, g);

            return;
        }

        private void applyTransformation2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Point> new_shape = new List<Point>();

            double[][] A = new double[1][];
            A[0] = new double[4];

            double[][] B = new double[4][];
            for (int x = 0; x < 4; x++)
            {
                B[x] = new double[4];
            }

            Point[] shape1 = Shape1.ToArray();
            Point[] shape2 = Shape2.ToArray();
            int length = shape1.Length;
            for (int i = 0; i < length; i++)
            {
                A[0][0] = (2 * shape1[i].X * shape2[i].X) + (2 * shape1[i].Y * shape2[i].Y);
                A[0][1] = ((-2) * shape1[i].Y * shape2[i].X) + (2 * shape1[i].X * shape2[i].Y);
                A[0][2] = (2 * shape1[i].X);
                A[0][3] = (2 * shape1[i].Y);

                B[0][0] = (2 * shape2[i].X * shape2[i].X) + (2 * shape2[i].Y * shape2[i].Y);
                B[0][0] = 0;
                B[0][0] = (2 * shape2[i].X);
                B[0][0] = (2 * shape2[i].Y);
                B[1][0] = 0;
                B[1][1] = (2 * shape2[i].X * shape2[i].X) - (2 * shape2[i].Y * shape2[i].Y);
                B[1][2] = (2 * shape2[i].Y);
                B[1][3] = ((-2) * shape2[i].Y);
                B[2][0] = (2 * shape2[i].X);
                B[2][1] = (2 * shape2[i].Y);
                B[2][2] = 2;
                B[2][3] = 0;
                B[3][0] = (2 * shape2[i].Y);
                B[3][1] = (2 * shape2[i].X);
                B[3][2] = 0;
                B[3][3] = 2;

                PCALib.Matrix matrixA = new PCALib.Matrix(A);
                PCALib.Matrix matrixB = new PCALib.Matrix(B);
                PCALib.Matrix matrixATrans = (PCALib.Matrix)matrixA.Transpose();
                PCALib.Matrix matrixBInv = (PCALib.Matrix)matrixB.Inverse;

                PCALib.Matrix matrixTransformationValues = (PCALib.Matrix)matrixBInv.Multiply(matrixATrans);

                Transformation T2 = new Transformation();
                T2.A = matrixTransformationValues[0, 0];
                T2.B = matrixTransformationValues[1, 0];
                T2.T1 = matrixTransformationValues[2, 0];
                T2.T2 = matrixTransformationValues[3, 0];

                int X = (int)((T2.A * shape2[i].X) + (T2.B * shape2[i].Y) + T2.T1);
                int Y = (int)(((-1) * T2.B * shape2[i].X) + (T2.A * shape2[i].Y) + T2.T2);

                shape2[i].X = X;
                shape2[i].Y = Y;

                Debug.Print("Point " + i + ": " + shape2[i].X + ", " + shape2[i].Y );

                new_shape.Add(shape2[i]);

            }

            Pen pRed = new Pen(Brushes.Red, 1);
            Pen pBlack = new Pen(Brushes.Blue, 1);
            Graphics g = panShape2.CreateGraphics();
            DisplayShape(Shape1, pRed, g);
            DisplayShape(new_shape, pBlack, g);

            return;
        }
    }
}
