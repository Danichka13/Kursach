using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaper
{
    public class FigureColor
    {
        Figure figure;
        Pen DrawPen;

        public FigureColor()
        {
            figure = new Figure();
            DrawPen = new Pen(Color.Black, 1);
        }

        public FigureColor(Figure figure, Pen DrawPen)
        {
            this.figure = figure;
            this.DrawPen = DrawPen;
        }

        public Figure getFig()
        {
            return figure;
        }

        public Pen getColor()
        {
            return DrawPen;
        }

    }
}
