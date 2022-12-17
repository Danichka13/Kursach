using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaper
{
    public class LineColor
    {
        Line line;
        Pen DrawPen;

        public LineColor()
        {
            line = new Line();
            DrawPen = new Pen(Color.Black, 1);
        }

        public LineColor(Line line, Pen DrawPen)
        {
            this.line = line;
            this.DrawPen = DrawPen;
        }

        public Line getLine()
        {
            return line;
        }

        public Pen getColor()
        {
            return DrawPen;
        }
    }
}
