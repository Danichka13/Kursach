using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursePaper
{
    public class TMO : Figure
    {

        public TMO()
        {

        }

        /*public void TMOs()
        {
            g.Clear(Color.White);
            int Ymax, Ymin, Y, maxIndex;
            YminMax(out Ymin, out Ymax, true, out maxIndex);
            for (Y = Ymin; Y <= Ymax; Y++)
            {
                List<int> Xal = new List<int>();
                List<int> Xar = new List<int>();
                List<int> Xbl = new List<int>();
                List<int> Xbr = new List<int>();
                crossPointTMO(Xal, Xar, Y, ListOfVertexList[0], maxIndex);
                crossPointTMO(Xbl, Xbr, Y, ListOfVertexList[1], maxIndex);
                if (Xal.Count == 0 && Xbl.Count == 0)
                    continue;
                int[][] M = new int[Xal.Count * 2 + Xbl.Count * 2][];
                int n = Xal.Count;
                for (int i = 0; i < n; i++)
                {
                    M[i] = new int[2] { Xal[i], 2 };

                }
                int nM = n; n = Xar.Count;
                for (int i = 0; i < n; i++)
                {
                    M[nM + i] = new int[2] { Xar[i], -2 };
                }
                nM = nM + n; n = Xbl.Count;
                for (int i = 0; i < n; i++)
                {
                    M[nM + i] = new int[2] { Xbl[i], 1 };
                }
                nM = nM + n; n = Xbr.Count;
                for (int i = 0; i < n; i++)
                {
                    M[nM + i] = new int[2] { Xbr[i], -1 };
                }
                nM = nM + n;

                //общее число элементов в массиве M
                //сортировка массива М()
                for (int i = 0; i < M.Length; i++)
                {
                    for (int j = 0; j < M.Length - 1; j++)
                    {
                        if (M[j][0] > M[j + 1][0])
                        {
                            int[] tempArr1 = new int[2];
                            Array.Copy(M[j], tempArr1, 2);
                            int[] tempArr2 = new int[2];
                            Array.Copy(M[j + 1], tempArr2, 2);
                            M[j] = tempArr2;
                            M[j + 1] = tempArr1;
                        }
                    }
                }
                int k = 0, m = 0;
                int Q = 0, x = 0, Xemin = 0, Qnew = 0;
                int Xemax = pictureBox1.Size.Width;
                List<int> Xrl = new List<int>();
                List<int> Xrr = new List<int>();
                if (M[0][0] >= Xemin && M[0][1] < 0)
                {
                    Xrl.Add(0);
                    Q = -M[0][1];
                    k = 2;
                }
                for (int i = 0; i < nM; i++)
                {
                    x = M[i][0];
                    Qnew = Q + M[i][1];
                    if (!Array.Exists(SetQ, element => element == Q) &&
                    Array.Exists(SetQ, element => element == Qnew))
                    {
                        Xrl.Add(x);
                        k += 1;
                    }
                    if (Array.Exists(SetQ, element => element == Q) &&
                    !Array.Exists(SetQ, element => element == Qnew))
                    {
                        Xrr.Add(x);
                        m += 1;
                    }
                    Q = Qnew;
                }
                if (Array.Exists(SetQ, element => element == Q))
                {
                    Xrr.Add(Xemax);
                }
                for (int i = 0; i < Xrr.Count; i++)
                {
                    g.DrawLine(DrawPen, new Point(Xrr[i], Y), new Point(Xrl[i],
                    Y));
                }
            }
        }
*/
        void crossPointTMO(List<int> Xl, List<int> Xr, int Y, List<Point> FigNum, int maxIndex)
        {
            int k;
            bool CW;
            if (Opred(maxIndex, FigNum) < 0) CW = true; else CW = false;
            for (int i = 0; i < FigNum.Count; i++)
            {
                if (i < (FigNum.Count - 1))
                {
                    k = i + 1;
                }
                else
                {
                    k = 0;
                }
                //нахождение точек пересечения
                if ((FigNum[i].Y < Y) & (FigNum[k].Y >= Y) ||
                (FigNum[i].Y >= Y) & (FigNum[k].Y < Y))
                {
                    int x = (FigNum[i].X * FigNum[k].Y -
                    FigNum[k].X * FigNum[i].Y - Y * (FigNum[i].X - FigNum[k].X)) /
                    (FigNum[k].Y - FigNum[i].Y);
                    if (!CW)
                    {
                        if ((FigNum[k].Y - FigNum[i].Y) < 0)
                        {
                            Xl.Add(x);
                        }
                        else if ((FigNum[k].Y - FigNum[i].Y) > 0)
                        {
                            Xr.Add(x);
                        }
                    }
                    else
                    {
                        if ((FigNum[k].Y - FigNum[i].Y) < 0)
                        {
                            Xr.Add(x);
                        }
                        else if ((FigNum[k].Y - FigNum[i].Y) > 0)
                        {
                            Xl.Add(x);
                        }
                    }
                }
            }
            Xr.Sort();
            Xl.Sort();
        }

        private int Opred(int j, List<Point> FigNum)
        {
            int jl = j - 1;
            if (jl < 0) jl = FigNum.Count - 1;
            int jp = j + 1;
            if (jp >= FigNum.Count) jp = 0;
            Point p1 = FigNum[jl];
            Point p2 = FigNum[j];
            Point p3 = FigNum[jp];
            int op = (p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y) -
            (p3.X * p2.Y + p2.X * p1.Y + p1.X * p3.Y);
            op = op / 2;
            if (op == 0) op = Opred(jp, FigNum);
            return op;
        }


    }
}