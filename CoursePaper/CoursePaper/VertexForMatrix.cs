using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePaper
{
    public class VertexForMatrix
    {
        public float X;
        public float Y;
        public float C;

        public VertexForMatrix(float x = 0.0f, float y = 0.0f, float constanta = 1.0f)
        {
            X = x;
            Y = y;
            C = constanta;
        }
    }
}
