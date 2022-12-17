using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CoursePaper
{
    public partial class Form1 : Form
    {
        Bitmap myBitmap;
        Graphics g;
        Pen DrawPen = new Pen(Color.Black, 1);
        List<PointF> VertexList = new List<PointF>(); // для отрисовки сторон
        Figure fig = new Figure();
        Figure figRot = new Figure();
        FigureColor fc = new FigureColor();
        LineColor lc = new LineColor();
        List<FigureColor> figures = new List<FigureColor>();
        List<LineColor> lines = new List<LineColor>();
        int numOfFig = -1, numOfLine = -1;
        short GP, prim = -1;

        Primitive primitive = new Primitive();
        Line line = new Line();
        Line lineMove = new Line();

        bool checkPrint = true, checkScale = false;

        int Operation; //0 - ГП, 1 - ТМ
        bool checkPgn = false, checkline = false;
        Point ScreenMousePos = new Point();
        Point pRotate = new Point(-1, -1);
        Point pUp = new Point(-1, -1);
        int angel;

        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(Screen.Width, Screen.Height);
            g = Graphics.FromImage(myBitmap);
        }

        private void Screen_MouseDown(object sender, MouseEventArgs e)
        {
            ScreenMousePos = e.Location;
            if (checkPrint)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (prim == 1 || prim == 2)
                    {
                        pRotate = e.Location;
                    }
                    if (prim == 0)
                    {
                        VertexList.Add(e.Location);
                    }
                }
                else
                {
                    VertexList.Add(e.Location);
                    line.Bizie(VertexList);
                    line.Fill(g, DrawPen);

                    lc = new LineColor(line, DrawPen);
                    lines.Add(lc);
                    line = new Line();
                    VertexList.Clear();
                    Screen.Image = myBitmap;
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    checkPgn = false;
                    checkline = false;

                    if (figures.Count > 0)
                    {
                        for (int i = figures.Count - 1; i >= 0; i--)
                        {
                            fig = figures[i].getFig();
                            if (fig.ThisFigure(e.X, e.Y))
                            {
                                g.DrawEllipse(new Pen(Color.Blue), e.X - 2, e.Y - 2, 5, 5);
                                checkPgn = true;
                                checkline = false;
                            }
                            if (checkPgn)
                            {
                                if (GP > -1)
                                {
                                    figRot = fig;
                                }
                                if (checkScale)
                                {
                                    figRot = fig;
                                    //figRot.findCenter();
                                }
                                numOfFig = i;
                                i = 0;
                            }
                            Screen.Image = myBitmap;
                        }
                    }
                    if (lines.Count > 0)
                    {
                        for (int i = lines.Count - 1; i >= 0; i--)
                        {
                            line = lines[i].getLine();
                            if (line.ThisLine(ScreenMousePos.X, ScreenMousePos.Y))
                            {
                                g.DrawEllipse(new Pen(Color.Blue), e.X - 2, e.Y - 2, 5, 5);
                                checkline = true;
                                checkPgn = false;
                            }
                            if (checkline)
                            {
                                lineMove = line;
                                numOfLine = i;
                                i = 0;
                            }
                            Screen.Image = myBitmap;
                        }
                    }
                }
                else { pRotate = e.Location; }
                // копирование из myBitmap в Screen.Image
                Screen.Image = myBitmap;
            }
        }

        // Обработчик событий - отжатие кнопки мыши
        private void Screen_MouseUp(object sender, MouseEventArgs e)
        {
            //checkPgn = false;
            //checkline = false;
            if (checkPrint && prim == 1)
            {
                pUp = e.Location;
                primitive.Cross(pRotate, pUp);
                primitive.Fill(g, DrawPen);
                fc = new FigureColor(primitive, DrawPen);
                figures.Add(fc);
                VertexList.Clear();
                primitive = new Primitive();
                Screen.Image = myBitmap;
            }
            if (checkPrint && prim == 2)
            {
                pUp = e.Location;
                primitive.Figure4(pRotate, pUp);
                primitive.Fill(g, DrawPen);
                fc = new FigureColor(primitive, DrawPen);
                figures.Add(fc);
                VertexList.Clear();
                primitive = new Primitive();
                Screen.Image = myBitmap;
            }
        }

        // Прокрутка колёсика мышки
        private void Screen_MouseWheel(object sender, MouseEventArgs e)
        {
            if (checkScale && !checkPrint)
            {
                if (checkPgn)
                {
                    figRot.findCenter();
                    figRot.Scale(e);
                    g.Clear(Screen.BackColor);
                    for (int i = 0; i < figures.Count; i++)
                    {
                        fig = figures[i].getFig();
                        DrawPen = figures[i].getColor();
                        fig.Fill(g, DrawPen); // перерисовка
                        Screen.Image = myBitmap;
                    }
                    for (int i = 0; i < lines.Count; i++)
                    {
                        line = lines[i].getLine();
                        DrawPen = lines[i].getColor();
                        line.Fill(g, DrawPen);
                        Screen.Image = myBitmap;
                    }
                }
                if (checkline)
                {
                    lineMove.findCenter();
                    lineMove.Scale(e);
                    g.Clear(Screen.BackColor);
                    for (int i = 0; i < figures.Count; i++)
                    {
                        fig = figures[i].getFig();
                        DrawPen = figures[i].getColor();
                        fig.Fill(g, DrawPen); // перерисовка
                        Screen.Image = myBitmap;
                    }
                    for (int i = 0; i < lines.Count; i++)
                    {
                        line = lines[i].getLine();
                        DrawPen = lines[i].getColor();
                        line.Fill(g, DrawPen);

                        Screen.Image = myBitmap;
                        ScreenMousePos = e.Location;
                    }
                }
            }
        }


        private void comboBox_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_type.SelectedIndex) // выбор цвета
            {
                case 0:
                    comboBox_geom.Enabled = true;
                    Operation = 0;
                    break;
                case 1:
                    comboBox_geom.Enabled = false;
                    trackBar_angle.Enabled = false;
                    trackBar_angle.Value = 0;
                    label_angle.Text = "";
                    comboBox_geom.Text = "Тип ГП";
                    Operation = 1;
                    break;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox_type.Enabled = false;
                comboBox_geom.Enabled = false;
                trackBar_angle.Enabled = false;
                comboBox_Color.Enabled = true;
                trackBar_angle.Value = 0;
                comboBox_geom.Text = "Тип ГП";
                comboBox_type.Text = "Тип операции";
                checkPrint = true;
                checkBox2.Enabled = false;
                label_angle.Text = "";

                VertexList.Clear();
                line = new Line();
                Operation = 1;
                /*fig = new Figure();
                figRot = new Figure();
                fc = new FigureColor();*/
                DrawPen = new Pen(Color.Black, 1);
            }
            else
            {
                comboBox_type.Enabled = true;
                checkBox2.Enabled = true;
                comboBox_Color.Enabled = false;

                checkPrint = false;
            }
        }

        private void comboBox_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_Color.SelectedIndex) // выбор цвета
            {
                case 0:
                    DrawPen.Color = Color.Black;
                    break;
                case 1:
                    DrawPen.Color = Color.Red;
                    break;
                case 2:
                    DrawPen.Color = Color.Green;
                    break;
                case 3:
                    DrawPen.Color = Color.Blue;
                    break;
            }
        }

        private void comboBox_geom_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox_geom.SelectedIndex) // выбор цвета
            {
                case 0: // Поворот на произвольный угол относительно заданного центра
                    GP = 0;
                    button_rotate.Text = "Повернуть";
                    trackBar_angle.Enabled = true;
                    break;
                case 1: // Зеркальное отражение относительно заданного центра
                    GP = 1;
                    button_rotate.Text = "Отразить";
                    trackBar_angle.Value = 0;
                    label_angle.Text = "";
                    trackBar_angle.Enabled = false;
                    break;
                case 2: // Зеркальное отражение относительно заданной вертикальной прямой
                    GP = 2;
                    button_rotate.Text = "Отразить";
                    trackBar_angle.Value = 0;
                    label_angle.Text = "";
                    trackBar_angle.Enabled = false;
                    break;
            }
        }

        // Обработчик события - движения мыши
        private void Screen_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!checkPrint & checkPgn)
                {
                    fig = figures[numOfFig].getFig();
                    fig.Move(e.X - ScreenMousePos.X, e.Y - ScreenMousePos.Y);
                    g.Clear(Screen.BackColor);
                    for (int i = 0; i < figures.Count; i++)
                    {
                        fig = figures[i].getFig();
                        DrawPen = figures[i].getColor();
                        fig.Fill(g, DrawPen); // перерисовка

                        Screen.Image = myBitmap;
                        ScreenMousePos = e.Location;
                    }
                    for (int i = 0; i < lines.Count; i++)
                    {
                        line = lines[i].getLine();
                        DrawPen = lines[i].getColor();
                        line.Fill(g, DrawPen);

                        Screen.Image = myBitmap;
                        ScreenMousePos = e.Location;
                    }
                }
                if (!checkPrint & checkline)
                {
                    line = lines[numOfLine].getLine();
                    lineMove.Move(e.X - ScreenMousePos.X, e.Y - ScreenMousePos.Y);
                    g.Clear(Screen.BackColor);
                    for (int i = 0; i < figures.Count; i++)
                    {
                        fig = figures[i].getFig();
                        DrawPen = figures[i].getColor();
                        fig.Fill(g, DrawPen); // перерисовка

                        Screen.Image = myBitmap;
                        ScreenMousePos = e.Location;
                    }
                    for (int i = 0; i < lines.Count; i++)
                    {
                        line = lines[i].getLine();
                        DrawPen = lines[i].getColor();
                        line.Fill(g, DrawPen);

                        Screen.Image = myBitmap;
                        ScreenMousePos = e.Location;
                    }
                }
            }
        }

        // Обработчик события - нажатие кнопки "Очистить"
        private void button_clear_Click(object sender, EventArgs e)
        {
            VertexList.Clear();
            figures.Clear();
            lines.Clear();
            g.Clear(Screen.BackColor);
            Screen.Image = myBitmap;
            Operation = 1;
            fig = new Figure();
            figRot = new Figure();
            fc = new FigureColor();
            line = new Line();
            lc = new LineColor();
            DrawPen = new Pen(Color.Black, 1);

            checkBox1.Enabled = true;
            comboBox_Color.Text = "Чёрный";
            comboBox_type.Enabled = false;
            comboBox_geom.Enabled = false;
            trackBar_angle.Enabled = false;
            label_angle.Text = "";
            comboBox_geom.Text = "Тип ГП";
            comboBox_type.Text = "Тип операции";
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            if (checkPgn)
                figures.RemoveAt(numOfFig);
            if (checkline)
                lines.RemoveAt(numOfLine);

            g.Clear(Screen.BackColor);
            for (int i = 0; i < figures.Count; i++)
            {
                fig = figures[i].getFig();
                DrawPen = figures[i].getColor();
                fig.Fill(g, DrawPen); // перерисовка
                Screen.Image = myBitmap;
            }
            for (int i = 0; i < lines.Count; i++)
            {
                line = lines[i].getLine();
                DrawPen = lines[i].getColor();
                line.Fill(g, DrawPen);
                Screen.Image = myBitmap;;
            }

            Screen.Image = myBitmap;
        }

        // Обраборчик события - передвижение ползунка трэкбара
        private void trackBar_angle_Scroll(object sender, EventArgs e)
        {
            angel = trackBar_angle.Value;
            label_angle.Text = String.Format("Угол {0} градусов", trackBar_angle.Value);

        }

        // Обработчик события - нажатие кнопки "Повернуть/Отразить"
        private void button_rotate_Click(object sender, EventArgs e)
        {
            if (GP == 0 && pRotate.X > -1 && checkPgn)
            {
                figRot.Rotate(angel, pRotate);

            }
            if (GP == 0 && pRotate.X > -1 && checkline)
            {
                lineMove.Rotate(angel, pRotate);

            }
            if ((GP == 1 || GP == 2) && pRotate.X > -1 && checkPgn)
            {
                figRot.Mirror(pRotate, GP);
            }
            if ((GP == 1 || GP == 2) && pRotate.X > -1 && checkline)
            {
                lineMove.Mirror(pRotate, GP);
            }
            g.Clear(Screen.BackColor);
            for (int i = 0; i < figures.Count; i++)
            {
                fig = figures[i].getFig();
                DrawPen = figures[i].getColor();
                fig.Fill(g, DrawPen); // перерисовка
                Screen.Image = myBitmap;
            }
            for (int i = 0; i < lines.Count; i++)
            {
                line = lines[i].getLine();
                DrawPen = lines[i].getColor();
                line.Fill(g, DrawPen);

                Screen.Image = myBitmap;
            }
        }

        // Обработчик событий - выбор примитива
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) // выбор цвета
            {
                case 0: // Кривая Бизье
                    prim = 0;
                    break;
                case 1: // Привильный крест
                    prim = 1;

                    break;
                case 2: // Фигура 4
                    prim = 2;

                    break;
            }
        }


        // Обработчик события - флажок "Масштабировать"
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                //comboBox_type.Enabled = false;
                //comboBox_geom.Enabled = false;
                //trackBar_angle.Enabled = false;
                checkScale = true;
            }
            else
            {
                // comboBox_type.Enabled = true;

                checkScale = false;
            }
        }
    }
}