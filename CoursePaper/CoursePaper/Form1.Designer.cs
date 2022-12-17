namespace CoursePaper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_remove = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button_rotate = new System.Windows.Forms.Button();
            this.label_angle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar_angle = new System.Windows.Forms.TrackBar();
            this.button_clear = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox_type = new System.Windows.Forms.ComboBox();
            this.comboBox_geom = new System.Windows.Forms.ComboBox();
            this.comboBox_Color = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Screen = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_angle)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_remove);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.button_rotate);
            this.panel1.Controls.Add(this.label_angle);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.trackBar_angle);
            this.panel1.Controls.Add(this.button_clear);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 559);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1121, 131);
            this.panel1.TabIndex = 0;
            // 
            // button_remove
            // 
            this.button_remove.Location = new System.Drawing.Point(949, 70);
            this.button_remove.Name = "button_remove";
            this.button_remove.Size = new System.Drawing.Size(128, 34);
            this.button_remove.TabIndex = 10;
            this.button_remove.Text = "Удалить";
            this.button_remove.UseVisualStyleBackColor = true;
            this.button_remove.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(464, 27);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 19);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Масштабировать";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button_rotate
            // 
            this.button_rotate.Location = new System.Drawing.Point(237, 79);
            this.button_rotate.Name = "button_rotate";
            this.button_rotate.Size = new System.Drawing.Size(121, 38);
            this.button_rotate.TabIndex = 8;
            this.button_rotate.Text = "Повернуть";
            this.button_rotate.UseVisualStyleBackColor = true;
            this.button_rotate.Click += new System.EventHandler(this.button_rotate_Click);
            // 
            // label_angle
            // 
            this.label_angle.AutoSize = true;
            this.label_angle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label_angle.Location = new System.Drawing.Point(228, 58);
            this.label_angle.Name = "label_angle";
            this.label_angle.Size = new System.Drawing.Size(0, 15);
            this.label_angle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(276, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Угол";
            // 
            // trackBar_angle
            // 
            this.trackBar_angle.Enabled = false;
            this.trackBar_angle.Location = new System.Drawing.Point(182, 28);
            this.trackBar_angle.Maximum = 360;
            this.trackBar_angle.Name = "trackBar_angle";
            this.trackBar_angle.Size = new System.Drawing.Size(222, 45);
            this.trackBar_angle.TabIndex = 5;
            this.trackBar_angle.Scroll += new System.EventHandler(this.trackBar_angle_Scroll);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(22, 58);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(117, 59);
            this.button_clear.TabIndex = 4;
            this.button_clear.Text = "Очистить";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(39, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Рисование";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox_type
            // 
            this.comboBox_type.Enabled = false;
            this.comboBox_type.FormattingEnabled = true;
            this.comboBox_type.Items.AddRange(new object[] {
            "Геометрические преобразования",
            "Теоретико-множественные операции"});
            this.comboBox_type.Location = new System.Drawing.Point(8, 152);
            this.comboBox_type.Name = "comboBox_type";
            this.comboBox_type.Size = new System.Drawing.Size(233, 23);
            this.comboBox_type.TabIndex = 0;
            this.comboBox_type.Text = "Операция";
            this.comboBox_type.SelectedIndexChanged += new System.EventHandler(this.comboBox_type_SelectedIndexChanged);
            // 
            // comboBox_geom
            // 
            this.comboBox_geom.Enabled = false;
            this.comboBox_geom.FormattingEnabled = true;
            this.comboBox_geom.Items.AddRange(new object[] {
            "Rc",
            "Mc",
            "MV"});
            this.comboBox_geom.Location = new System.Drawing.Point(88, 265);
            this.comboBox_geom.Name = "comboBox_geom";
            this.comboBox_geom.Size = new System.Drawing.Size(65, 23);
            this.comboBox_geom.TabIndex = 3;
            this.comboBox_geom.Text = "Тип ГП";
            this.comboBox_geom.SelectedIndexChanged += new System.EventHandler(this.comboBox_geom_SelectedIndexChanged);
            // 
            // comboBox_Color
            // 
            this.comboBox_Color.FormattingEnabled = true;
            this.comboBox_Color.Items.AddRange(new object[] {
            "Чёрный",
            "Красный",
            "Зелёный",
            "Синий"});
            this.comboBox_Color.Location = new System.Drawing.Point(76, 40);
            this.comboBox_Color.Name = "comboBox_Color";
            this.comboBox_Color.Size = new System.Drawing.Size(103, 23);
            this.comboBox_Color.TabIndex = 2;
            this.comboBox_Color.Text = "Чёрный";
            this.comboBox_Color.SelectedIndexChanged += new System.EventHandler(this.comboBox_Color_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.comboBox_geom);
            this.panel2.Controls.Add(this.comboBox_type);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.comboBox_Color);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(873, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 559);
            this.panel2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Кривая Бизье",
            "Правильный крест",
            "Фигура 4"});
            this.comboBox1.Location = new System.Drawing.Point(64, 375);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "Примитивы";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(72, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Виды примитивов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(82, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Тип операции";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(79, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "преобразования";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(64, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип геометрического";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(108, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Цвет";
            // 
            // Screen
            // 
            this.Screen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Screen.Location = new System.Drawing.Point(0, 0);
            this.Screen.Name = "Screen";
            this.Screen.Size = new System.Drawing.Size(873, 559);
            this.Screen.TabIndex = 2;
            this.Screen.TabStop = false;
            this.Screen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseDown);
            this.Screen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseMove);
            this.Screen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseUp);
            this.Screen.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Screen_MouseWheel);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(97, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Тип ТМО";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Объединение",
            "Разность"});
            this.comboBox2.Location = new System.Drawing.Point(64, 478);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.Text = "ТМО";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1121, 690);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_angle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Screen)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private Panel panel1;
        private Panel panel2;
        private PictureBox Screen;
        private ComboBox comboBox_type;
        private CheckBox checkBox1;
        private ComboBox comboBox_Color;
        private ComboBox comboBox_geom;
        private Button button_clear;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label5;
        private TrackBar trackBar_angle;
        private Label label4;
        private Label label_angle;
        private Button button_rotate;
        private CheckBox checkBox2;
        private ComboBox comboBox1;
        private Label label6;
        private Button button_remove;
        private ComboBox comboBox2;
        private Label label7;
    }
}