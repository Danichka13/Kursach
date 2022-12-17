using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoursePaper
{
    public class Figure
    {
        public List<PointF> VertexList;
        PointF center = new PointF();

        public Figure()
        {
            VertexList = new List<PointF>();
        }


        // метод Добавление вершины
        public void AddP(PointF NewVertex)
        {
            VertexList.Add(NewVertex);
        }


        // Закрашивание фигуры
        /*public void Fill(Graphics g, Pen DrawPen)
        {
            Brush DrawBrush = new SolidBrush(DrawPen.Color);
            int n = VertexList.Count() - 1;
            Point[] PgVertex = new Point[VertexList.Count()]; // массив вершин
            for (int i = 0; i <= n; i++)
            {
                PgVertex[i].X = (int)Math.Round(VertexList[i].X);
                PgVertex[i].Y = (int)Math.Round(VertexList[i].Y);
            }
            g.FillPolygon(DrawBrush, PgVertex);
        }*/


        // Метод закрашивания
        public void Fill(Graphics g, Pen DrawPen)
        {
            float Y, Ymin, Ymax;
            List<float> Xb = new List<float>();
            int k = 0;
            //YminMax(out Ymin, out Ymax);
            Ymin = VertexList[0].Y;
            Ymax = VertexList[0].Y;
            for (int i = 1; i < VertexList.Count; i++)
            {
                float curY = VertexList[i].Y;
                if (curY > Ymax)
                {
                    Ymax = curY;
                }
                if (curY < Ymin)
                {
                    Ymin = curY;
                }
            }
            for (Y = Ymin; Y <= Ymax; Y++)
            {
                Xb.Clear();
                for (int i = 0; i < VertexList.Count - 1; i++)
                {
                    if (i < VertexList.Count)
                    {
                        k = i + 1;
                    }
                    else
                    {
                        k = 1;
                    }
                    if ((VertexList[i].Y < Y && VertexList[k].Y >= Y) ||
                    (VertexList[i].Y >= Y && VertexList[k].Y < Y))
                    {
                        Xb.Add((VertexList[i].X * VertexList[k].Y - VertexList[k].X * VertexList[i].Y - Y * (VertexList[i].X - VertexList[k].X)) / (VertexList[k].Y - VertexList[i].Y));
                    }
                }
                if ((VertexList[k].Y < Y && VertexList[0].Y >= Y) ||
                (VertexList[k].Y >= Y && VertexList[0].Y < Y))
                {
                    Xb.Add((VertexList[k].X * VertexList[0].Y - VertexList[0].X * VertexList[k].Y - Y * (VertexList[k].X - VertexList[0].X)) / (VertexList[0].Y - VertexList[k].Y));
                }
                Xb.Sort();
                //Закрашивание многоугольника
                for (int i = 0; i + 1 < Xb.Count; i += 2)
                {
                    g.DrawLine(DrawPen, new PointF(Xb[i], Y), new PointF(Xb[i + 1], Y));
                }
            }
        }

        //Сортировка Y
        public void YminMax(out float min, out float max)
        {
            min = VertexList[0].Y;
            max = VertexList[0].Y;
            for (int i = 1; i < VertexList.Count; i++)
            {
                float curY = VertexList[i].Y;
                if (curY > max)
                {
                    max = curY;
                }
                if (curY < min)
                {
                    min = curY;
                }
            }
        }


        // Метод проверки выбрана ли фигура
        public bool ThisFigure(float mX, float mY)
        {
            int n = VertexList.Count() - 1, k, m = 0;
            bool check = false;
            for (int i = 0; i <= n; i++)
            {
                if (i < n) k = i + 1; else k = 0;
                if ((VertexList[i].Y < mY) & (VertexList[k].Y >= mY) | (VertexList[i].Y >= mY) & (VertexList[k].Y < mY))
                    if ((mY - VertexList[i].Y) * (VertexList[k].X - VertexList[i].X) / (VertexList[k].Y - VertexList[i].Y) + VertexList[i].X < mX) m++;
            }
            if (m % 2 == 1)
            {
                check = true;
                //findCenter();
            }
            return check;
        }

        // Метод перемещения
        public void Move(float dx, float dy)
        {
            List<VertexForMatrix> VFMList = VtoVFM();
            float[,] matrix =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { dx, dy, 1 }
            };
            for (int i = 0; i < VertexList.Count; i++)
            {
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrix);
            }
            for (int i = 0; i < VertexList.Count; i++)
            {
                VertexList[i] = new PointF(VFMList[i].X, VFMList[i].Y);
            }
        }

        // Метод поворота
        public void Rotate(int angle, PointF pRotate)
        {
            List<VertexForMatrix> VFMList = VtoVFM();
            float[,] matrixToCenter =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { -pRotate.X, -pRotate.Y, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrixToCenter);

            double angleRadian = angle * Math.PI / 180; //переводим угол в радианты
            float[,] matrix =
            {
                { (float)Math.Cos(angleRadian), (float)Math.Sin(angleRadian), 0.0f },
                { -(float)Math.Sin(angleRadian), (float)Math.Cos(angleRadian), 0.0f },
                { 0, 0, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrix);

            float[,] matrixFromCenter =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { pRotate.X, pRotate.Y, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrixFromCenter);
            for (int i = 0; i < VFMList.Count; i++)
                VertexList[i] = new PointF(VFMList[i].X, VFMList[i].Y);
        }

        //  Метод масштабирования
        public void Scale(MouseEventArgs e)
        {
            List<VertexForMatrix> VFMList = VtoVFM();
            float sx = 1, sy = 1;
            //findCenter();
            //PointF vec = new PointF(VertexList[i].X - center.X, VertexList[i].Y - center.Y);
            if (e.Delta > 0)
            {
                sx = 1.05f;
                sy = 1.05f;
            }
            else if (e.Delta < 0)
            {
                sx = 0.95f;
                sy = 0.95f;
            }

            float[,] matrixToCenter =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { -center.X, -center.Y, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrixToCenter);

            float[,] matrix =
            {
                    { sx, 0, 0 },
                    { 0, sy, 0 },
                    { 0,  0, 1 }
                };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrix);

            float[,] matrixFromCenter =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { center.X, center.Y, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrixFromCenter);
            for (int i = 0; i < VFMList.Count; i++)
                VertexList[i] = new PointF(VFMList[i].X, VFMList[i].Y);
        }

        // Метод отражение относительно заданной вертикальной прямой
        public void Mirror(PointF p, short GP)
        {
            List<VertexForMatrix> VFMList = VtoVFM();
            float dx = 1, dy = 1;
            float[,] matrixToCenter =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { -p.X, -p.Y, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrixToCenter);

            if (GP == 2)
            {
                dx = -1;
            } else if (GP == 1)
            {
                dx = -1;
                dy = -1;
            }
            float[,] matrix =
            {
                { dx, 0, 0 },
                { 0, dy, 0 },
                { 0, 0, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrix);

            float[,] matrixFromCenter =
            {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { p.X, p.Y, 1 }
            };
            for (int i = 0; i < VFMList.Count; i++)
                VFMList[i] = Matrix13ToMatrix33(VFMList[i], matrixFromCenter);
            for (int i = 0; i < VFMList.Count; i++)
                VertexList[i] = new PointF(VFMList[i].X, VFMList[i].Y);
        }

        // Метод умножения матрицы 1x3 на матрицу 3x3
        public VertexForMatrix Matrix13ToMatrix33(VertexForMatrix vertex, float[,] matrix33)
        {
            VertexForMatrix newVertex = new VertexForMatrix();
            newVertex.X = vertex.X * matrix33[0, 0] + vertex.Y * matrix33[1, 0] + vertex.C * matrix33[2, 0];
            newVertex.Y = vertex.X * matrix33[0, 1] + vertex.Y * matrix33[1, 1] + vertex.C * matrix33[2, 1];
            newVertex.C = vertex.X * matrix33[0, 2] + vertex.Y * matrix33[1, 2] + vertex.C * matrix33[2, 2];
            return newVertex;
        }

        // Метод преобразования VertexList в матрицу 
        public List<VertexForMatrix> VtoVFM()
        {
            List<VertexForMatrix> VFMList = new List<VertexForMatrix>();
            for (int i = 0; i < VertexList.Count; i++)
            {
                VFMList.Add(new VertexForMatrix(VertexList[i].X, VertexList[i].Y));
            }
            return VFMList;
        }

        // Метод нахождения центра фигуры
        public void findCenter()
        {
            float Xcenter = 0, Ycenter = 0;
            for (int i = 0; i < VertexList.Count; i++)
            {
                Xcenter += VertexList[i].X;
                Ycenter += VertexList[i].Y;
            }
            center.X = Xcenter / VertexList.Count;
            center.Y = Ycenter / VertexList.Count;
        }

        // Метод удаления
        public void remove()
        {
            
        }
    }
}