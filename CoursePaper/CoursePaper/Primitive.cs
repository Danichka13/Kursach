using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaper
{
    public class Primitive : Figure
    {

        // Конструктор
        public Primitive()
        {
            // VertexList = new List<PointF>();
        }

        public void Cross(PointF start, PointF finish)
        {
            float dx = (finish.X - start.X) * 3 / 8;
            float dy = (start.Y - finish.Y) * 3 / 8;
            VertexList.Add(new PointF(start.X + dx, start.Y));
            VertexList.Add(new PointF(finish.X - dx, start.Y));
            VertexList.Add(new PointF(finish.X - dx, start.Y - dy));
            VertexList.Add(new PointF(finish.X, start.Y - dy));
            VertexList.Add(new PointF(finish.X, finish.Y + dy));
            VertexList.Add(new PointF(finish.X - dx, finish.Y + dy));
            VertexList.Add(new PointF(finish.X - dx, finish.Y));
            VertexList.Add(new PointF(start.X + dx, finish.Y));
            VertexList.Add(new PointF(start.X + dx, finish.Y + dy));
            VertexList.Add(new PointF(start.X, finish.Y + dy));
            VertexList.Add(new PointF(start.X, start.Y - dy));
            VertexList.Add(new PointF(start.X + dx, start.Y - dy));
        }

        public void Figure4(PointF start, PointF finish)
        {
            if (start.X < finish.X && start.Y > finish.Y)
            {
                float dx = (finish.X - start.X) / 5;
                float dy = (start.Y - finish.Y) / 3;
                VertexList.Add(new PointF(start.X, finish.Y));
                VertexList.Add(new PointF(start.X + 2 * dx, finish.Y));
                VertexList.Add(new PointF(start.X + 5 * dx / 2, start.Y - dy));
                VertexList.Add(new PointF(finish.X - 2 * dx, finish.Y));
                VertexList.Add(new PointF(finish.X, finish.Y));
                VertexList.Add(new PointF(finish.X - dx, start.Y));
                VertexList.Add(new PointF(start.X + dx, start.Y));
            }
            else if (start.X < finish.X && start.Y < finish.Y)
            {
                float dx = (finish.X - start.X) / 5;
                float dy = (finish.Y - start.Y) / 3;
                VertexList.Add(new PointF(start.X, start.Y));
                VertexList.Add(new PointF(start.X + 2 * dx, start.Y));
                VertexList.Add(new PointF(start.X + 5 * dx / 2, finish.Y - dy));
                VertexList.Add(new PointF(finish.X - 2 * dx, start.Y));
                VertexList.Add(new PointF(finish.X, start.Y));
                VertexList.Add(new PointF(finish.X - dx, finish.Y));
                VertexList.Add(new PointF(start.X + dx, finish.Y));
            }
            else if (start.X > finish.X && start.Y > finish.Y)
            {
                float dx = (start.X - finish.X) / 5;
                float dy = (start.Y - finish.Y) / 3;
                VertexList.Add(new PointF(finish.X, finish.Y));
                VertexList.Add(new PointF(finish.X + 2 * dx, finish.Y));
                VertexList.Add(new PointF(finish.X + 5 * dx / 2, start.Y - dy));
                VertexList.Add(new PointF(start.X - 2 * dx, finish.Y));
                VertexList.Add(new PointF(start.X, finish.Y));
                VertexList.Add(new PointF(start.X - dx, start.Y));
                VertexList.Add(new PointF(finish.X + dx, start.Y));
            }
            else
            {
                float dx = (start.X - finish.X) / 5;
                float dy = (finish.Y - start.Y) / 3;
                VertexList.Add(new PointF(finish.X, start.Y));
                VertexList.Add(new PointF(finish.X + 2 * dx, start.Y));
                VertexList.Add(new PointF(finish.X + 5 * dx / 2, finish.Y - dy));
                VertexList.Add(new PointF(start.X - 2 * dx, start.Y));
                VertexList.Add(new PointF(start.X, start.Y));
                VertexList.Add(new PointF(start.X - dx, finish.Y));
                VertexList.Add(new PointF(finish.X + dx, finish.Y));
            }
        }
    }
}
