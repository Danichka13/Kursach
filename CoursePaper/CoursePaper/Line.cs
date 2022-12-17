using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaper
{
    public class Line : Figure
    {
        //public List<PointF> VertexList;

        public Line()
        {
            VertexList = new List<PointF>();
        }


        // метод Добавление вершины
        public void AddP(PointF NewVertex)
        {
            VertexList.Add(NewVertex);
        }

        public void Fill(Graphics g, Pen DrawPen)
        {
            PointF[] res = new PointF[VertexList.Count];
            for (int i = 0; i < VertexList.Count; i++)
            {
                res[i] = VertexList[i];
            }
            g.DrawLines(DrawPen, res);// Рисуем полученную кривую Безье
        }

        // Кривая Безье
        public void Bizie(List<PointF> P)
        {
            int j = 0;
            float step = 0.02f;// Возьмем шаг 0.01 для большей точности

            //List<PointF> result = new List<PointF>(); //Конечный массив точек кривой
            for (float t = 0; t < 1; t += step)
            {
                float ytmp = 0;
                float xtmp = 0;
                for (int i = 0; i < P.Count; i++)
                { // проходим по каждой точке
                    float b = polinom(i, P.Count - 1, t); // вычисляем наш полином Бернштейна
                    xtmp += P[i].X * b; // записываем и прибавляем результат
                    ytmp += P[i].Y * b;
                }
                VertexList.Add(new PointF(xtmp, ytmp));
                j++;

            }
        }

        float polinom(int i, int n, float t)// Функция вычисления полинома Бернштейна
        {
            return (Factorial(n) / (Factorial(i) * Factorial(n - i))) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }

        // факториал
        int Factorial(int n)
        {
            int x = 1;
            for (int i = 1; i <= n; i++)
                x *= i;
            return x;
        }

        public bool ThisLine(float mX, float mY)
        {
            int n = VertexList.Count() - 1, k, m = 0;
            bool check = false;
            for (int i = 0; i < n; i++)
            {
                k = i + 1;
                if ((VertexList[i].X - 10 < mX && VertexList[k].X + 10 >= mX) || (VertexList[i].X - 10 <= mX && VertexList[k].X + 10 > mX))
                {
                    if ((VertexList[i].Y + 10 >= mY && VertexList[k].Y - 10 < mY) || (VertexList[i].Y + 10 > mY && VertexList[k].Y - 10 <= mY))
                    {
                        m++;
                    }
                }
            }
            if (m > 0)
            {
                check = true;
                //findCenter();
            }
            return check;
        }
    }
}
