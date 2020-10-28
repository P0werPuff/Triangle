using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle
{
    public partial class Form1 : Form
    {
        Label txt1, txt2;
        TextBox txtA, txtB, txtC, txtH, txtP, txtS;
        CheckBox checkA, checkB, checkC, checkD, checkF, checkG;
        Button btn1, btn2;
        ListView lView;
        PictureBox img;
        Panel panel;
        Graphics gp;
        Pen p = new Pen(Brushes.Black, 2);
        private bool byHeight;

        public Form1()
        {
            InitializeComponent(); //

            //Button "Ввод данных"

            Width = 470;  //
            Height = 400;
            txt1 = new Label();
            txt1.Text = "Ввод данных";
            txt1.Size = new Size(132, 19);
            txt1.Location = new Point(13, 13);
            Controls.Add(txt1);

            //Button "Решение"

            txt2 = new Label();
            txt2.Text = "Решение";
            txt2.Size = new Size(70, 19);
            txt2.Location = new Point(214, 13);
            Controls.Add(txt2);

            txtA = new TextBox();
            txtA.Location = new Point(88, 39);
            txtA.Size = new Size(100, 20);
            Controls.Add(txtA);
            txtA.TextChanged += 
                TxtA_TextChanged;

            txtB = new TextBox();
            txtB.Location = new Point(88, 65);
            txtB.Size = new Size(100, 20);
            Controls.Add(txtB);
            txtB.TextChanged += 
                TxtB_TextChanged;

            txtC = new TextBox();
            txtC.Location = new Point(88, 91);
            txtC.Size = new Size(100, 20);
            Controls.Add(txtC);
            txtC.TextChanged += 
                TxtC_TextChanged;

            txtH = new TextBox();
            txtH.Location = new Point(88, 117);
            txtH.Size = new Size(100, 20);
            Controls.Add(txtH);
            txtH.TextChanged += 
                TxtH_TextChanged;

            txtS = new TextBox();
            txtS.Location = new Point(88, 143);
            txtS.Size = new Size(100, 20);
            Controls.Add(txtS);
            txtS.TextChanged += 
                TxtS_TextChanged;

            txtP = new TextBox();
            txtP.Location = new Point(88, 169);
            txtP.Size = new Size(100, 20);
            Controls.Add(txtP);
            txtP.TextChanged += 
                TxtP_TextChanged;

            //Button "Сторона A"

            checkA = new CheckBox();
            checkA.Text = "Сторона A";
            checkA.Size = new Size(78, 17);
            checkA.Location = new Point(13, 42);
            Controls.Add(checkA);

            //Button "Сторона B"

            checkB = new CheckBox();
            checkB.Text = "Сторона B";
            checkB.Size = new Size(78, 17);
            checkB.Location = new Point(13, 68);
            Controls.Add(checkB);

            //Button "Сторона C"

            checkC = new CheckBox();
            checkC.Text = "Сторона C";
            checkC.Size = new Size(78, 17);
            checkC.Location = new Point(13, 94);
            Controls.Add(checkC);

            //Button "Высота"

            checkD = new CheckBox();
            checkD.Text = "Высота";
            checkD.Size = new Size(78, 17);
            checkD.Location = new Point(13, 120);
            Controls.Add(checkD);

            //Button "Площадь"

            checkG = new CheckBox();
            checkG.Text = "Площадь";
            checkG.Size = new Size(78, 17);
            checkG.Location = new Point(13, 146);
            Controls.Add(checkG);

            //Button "Периметр"

            checkF = new CheckBox();
            checkF.Text = "Периметр";
            checkF.Size = new Size(78, 17);
            checkF.Location = new Point(13, 172);
            Controls.Add(checkF);

            //Button "Создать"

            btn1 = new Button();
            btn1.Text = "Создать";
            btn1.Size = new Size(90, 45);
            btn1.Location = new Point(13, 200);
            Controls.Add(btn1);
            btn1.Click += Btn1_Click;

            //Button Нарисовать"

            btn2 = new Button();
            btn2.Text = "Нарисовать";
            btn2.Size = new Size(90, 45);
            btn2.Location = new Point(13, 250);
            Controls.Add(btn2);
            btn2.Click += Btn2_Click;

            //Button "Параметр"
            //Button "Значение"

            lView = new ListView();
            lView.Size = new Size(217, 238);
            lView.Location = new Point(214, 38);
            lView.View = View.Details;
            lView.Columns.Add("Параметр", 
            107, HorizontalAlignment.Left);
            lView.Columns.Add("Значение", 
            106, HorizontalAlignment.Right);
            Controls.Add(lView);

            img = new PictureBox();
            img.Size = new Size(80, 80);
            img.Location = new Point(120, 200);
            Controls.Add(img);

            panel = new Panel();
            panel.Size = new Size(80, 80);
            panel.Location = new Point(120, 280);
            Controls.Add(panel);
            gp = panel.CreateGraphics();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (lView.Items.Count > 0)
            {
                lView.Items.Clear();
            }
            if (txtA.Text.Length > 0 && 
                txtB.Text.Length > 0 && 
                txtC.Text.Length > 0)
            {

                //считывается значение стороны "A"
                //считывается значение высоты "h"
                //создал класса с названием "Triangle" с именем "triangle"
                //добавляем соответсвующие ячейки в коллекцию "Items" объекта "listview1"
                //При нажатии на кнопку "Запуск" первый столбик заполняется нами указанными значениями

                double a, b, c;
                a = Convert.ToDouble(txtA.Text); 
                b = Convert.ToDouble(txtB.Text); 
                c = Convert.ToDouble(txtC.Text); 
                Triangle triangle = new Triangle(a, b, c); 
                lView.Items.Add("Сторона A"); 
                lView.Items.Add("Сторона B"); 
                lView.Items.Add("Сторона C"); 
                lView.Items.Add("Периметр"); 
                lView.Items.Add("Полупериметр"); 
                lView.Items.Add("Площадь"); 
                lView.Items.Add("Существует?"); 
                lView.Items.Add("Спецификатор");

                //методы, которые по выводу сторон a, b ,c. Выводит из значения
                //выводим периметр
                //выводим значение площади
                //Вид треугольника выводим

                lView.Items[0].SubItems.Add(triangle.OutputA()); 
                lView.Items[1].SubItems.Add(triangle.OutputB()); 
                lView.Items[2].SubItems.Add(triangle.OutputC()); 
                lView.Items[3].SubItems.Add(Convert.ToString(triangle.Perimeter())); 
                lView.Items[4].SubItems.Add(Convert.ToString(triangle.HalfPerimeter())); 
                lView.Items[5].SubItems.Add(Convert.ToString(triangle.Surface())); 
                if (triangle.ExistTriangle) { lView.Items[6].SubItems.Add("Существует"); } 
                else lView.Items[6].SubItems.Add("Не существует");
                lView.Items[7].SubItems.Add(triangle.TriangleType); 
                if (triangle.TriangleType == "Равносторонний" 
                    && triangle.ExistTriangle == true)
                {
                    panel.Refresh();
                    Point p1 = new Point(10, 5);
                    Point p2 = new Point(70, 5);
                    Point p3 = new Point(40, 50);

                    gp.DrawLine(p, p1, p2);
                    gp.DrawLine(p, p2, p3);
                    gp.DrawLine(p, p3, p1);
                }
                else if (triangle.TriangleType == "Равнобедренный"
                    && triangle.ExistTriangle == true)
                {
                    panel.Refresh();
                    Point p1 = new Point(15, 5);
                    Point p2 = new Point(65, 5);
                    Point p3 = new Point(40, 60);

                    gp.DrawLine(p, p1, p2);
                    gp.DrawLine(p, p2, p3);
                    gp.DrawLine(p, p3, p1);
                }
                else if (triangle.TriangleType == "Разносторонний" 
                    && triangle.ExistTriangle == true)
                {
                    panel.Refresh();
                    Point p1 = new Point(10, 5);
                    Point p2 = new Point(70, 5);
                    Point p3 = new Point(55, 40);

                    gp.DrawLine(p, p1, p2);
                    gp.DrawLine(p, p2, p3);
                    gp.DrawLine(p, p3, p1);
                }
                else
                {
                    panel.Refresh();
                }
            }
            else if (txtA.Text.Length > 0 && txtH.Text.Length > 0)
            {

                //считывается значение стороны "A"
                //считывается значение высоты "h"
                //создал класса с названием "Triangle" с именем "triangle"
                //добавляем соответсвующие ячейки в коллекцию "Items" объекта "listview1"
                //При нажатии на кнопку "Запуск" первый столбик заполняется нами указанными значениями

                double a, h;
                a = Convert.ToDouble(txtA.Text);
                h = Convert.ToDouble(txtH.Text); 
                Triangle triangle = new Triangle(byHeight, a, h); 
                lView.Items.Add("Сторона а"); 
                lView.Items.Add("Сторона b"); 
                lView.Items.Add("Сторона c"); 
                lView.Items.Add("Высота"); 
                lView.Items.Add("Периметр");
                lView.Items.Add("Площадь"); 
                lView.Items.Add("Существует?"); 
                lView.Items.Add("Спецификатор");

                //методы, которые по выводу сторон a, b ,c. Выводит из значения
                //выводим периметр
                //выводим значение площади
                //Вид треугольника выводим

                lView.Items[0].SubItems.Add(triangle.OutputA()); 
                lView.Items[1].SubItems.Add(triangle.OutputB()); 
                lView.Items[2].SubItems.Add(triangle.OutputC()); 
                lView.Items[3].SubItems.Add(triangle.OutputH()); 
                lView.Items[4].SubItems.Add(Convert.ToString(triangle.Perimeter()));
                lView.Items[5].SubItems.Add(Convert.ToString(triangle.Surface())); 
                if (triangle.ExistTriangle) { lView.Items[6].SubItems.Add("Существует"); } 
                else lView.Items[6].SubItems.Add("Не существует");
                lView.Items[7].SubItems.Add(triangle.TriangleType); 
                if (triangle.TriangleType == "Равносторонний" 
                    && triangle.ExistTriangle == true)
                {
                    panel.Refresh();
                    Point p1 = new Point(10, 5);
                    Point p2 = new Point(70, 5);
                    Point p3 = new Point(40, 50);

                    gp.DrawLine(p, p1, p2);
                    gp.DrawLine(p, p2, p3);
                    gp.DrawLine(p, p3, p1);
                }
                else if (triangle.TriangleType == "Равнобедренный"
                    && triangle.ExistTriangle == true)
                {
                    panel.Refresh();
                    Point p1 = new Point(15, 5);
                    Point p2 = new Point(65, 5);
                    Point p3 = new Point(40, 60);

                    gp.DrawLine(p, p1, p2);
                    gp.DrawLine(p, p2, p3);
                    gp.DrawLine(p, p3, p1);
                }
                else if (triangle.TriangleType == "Разносторонний" 
                    && triangle.ExistTriangle == true)
                {
                    panel.Refresh();
                    Point p1 = new Point(10, 5);
                    Point p2 = new Point(70, 5);
                    Point p3 = new Point(55, 40);

                    gp.DrawLine(p, p1, p2);
                    gp.DrawLine(p, p2, p3);
                    gp.DrawLine(p, p3, p1);
                }
                else
                {
                    panel.Refresh();
                }
            }
        }
        private void TxtH_TextChanged(object sender, EventArgs e)
        {
            if (txtH.TextLength > 0)
            {
                checkD.Enabled = false;
            }
            else
            {
                checkD.Enabled = true;
            }
        }

        private void TxtC_TextChanged(object sender, EventArgs e)
        {
            if (txtC.TextLength > 0)
            {
                checkC.Enabled = false;
            }
            else
            {
                checkC.Enabled = true;
            }
        }

        private void TxtB_TextChanged(object sender, EventArgs e)
        {
            if (txtB.TextLength > 0)
            {
                checkB.Enabled = false;
            }
            else
            {
                checkB.Enabled = true;
            }
        }

        private void TxtP_TextChanged(object sender, EventArgs e)
        {
            if (txtP.TextLength > 0)
            {
                checkF.Enabled = false;
            }
            else
            {
                checkF.Enabled = true;
            }
        }

        private void TxtS_TextChanged(object sender, EventArgs e)
        {
            if (txtS.TextLength > 0)
            {
                checkG.Enabled = false;
            }
            else
            {
                checkG.Enabled = true;
            }
        }

        private void TxtA_TextChanged(object sender, EventArgs e)
        {
            if (txtA.TextLength > 0)
            {
                checkA.Enabled = false;
            }
            else
            {
                checkA.Enabled = true;
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (lView.Items.Count > 0)
            {
                lView.Items.Clear();
            }
            if (txtA.Text.Length > 0 && txtB.Text.Length > 0 && txtC.Text.Length > 0)
            {

                //считывается значение стороны "A"
                //считывается значение высоты "h"
                //создал класса с названием "Triangle" с именем "triangle"
                //добавляем соответсвующие ячейки в коллекцию "Items" объекта "listview1"
                //При нажатии на кнопку "Запуск" первый столбик заполняется нами указанными значениями

                double a, b, c;
                a = Convert.ToDouble(txtA.Text); 
                b = Convert.ToDouble(txtB.Text); 
                c = Convert.ToDouble(txtC.Text); 
                Triangle triangle = new Triangle(a, b, c);
                lView.Items.Add("Сторона A"); 
                lView.Items.Add("Сторона B"); 
                lView.Items.Add("Сторона C"); 
                lView.Items.Add("Периметр"); 
                lView.Items.Add("Полупериметр"); 
                lView.Items.Add("Площадь"); 
                lView.Items.Add("Существует?"); 
                lView.Items.Add("Спецификатор");

                //методы, которые по выводу сторон a, b ,c. Выводит из значения
                //выводим периметр
                //выводим значение площади
                //Вид треугольника выводим

                lView.Items[0].SubItems.Add(triangle.OutputA()); 
                lView.Items[1].SubItems.Add(triangle.OutputB()); 
                lView.Items[2].SubItems.Add(triangle.OutputC()); 
                lView.Items[3].SubItems.Add(Convert.ToString(triangle.Perimeter())); 
                lView.Items[4].SubItems.Add(Convert.ToString(triangle.HalfPerimeter())); 
                lView.Items[5].SubItems.Add(Convert.ToString(triangle.Surface())); 
                if (triangle.ExistTriangle) { lView.Items[6].SubItems.Add("Существует"); } 
                else lView.Items[6].SubItems.Add("Не существует");
                lView.Items[7].SubItems.Add(triangle.TriangleType); 
                if (triangle.TriangleType == "Равносторонний"
                    && triangle.ExistTriangle == true)
                {
                    img.Image = new Bitmap("triangleFil1.jpg");
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (triangle.TriangleType == "Равнобедренный" 
                    && triangle.ExistTriangle == true)
                {
                    img.Image = new Bitmap("triangleFil2.jpg");
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (triangle.TriangleType == "Разносторонний"
                    && triangle.ExistTriangle == true)
                {
                    img.Image = new Bitmap("triangleFil3.jpg");
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    img.Image = new Bitmap("none.png");
                }
            }
            else if (txtA.Text.Length > 0 && txtH.Text.Length > 0)
            {
                //считывается значение стороны "A"
                //считывается значение высоты "h"
                //создал класса с названием "Triangle" с именем "triangle"
                //добавляем соответсвующие ячейки в коллекцию "Items" объекта "listview1"
                //При нажатии на кнопку "Запуск" первый столбик заполняется нами указанными значениями

                double a, h;
                a = Convert.ToDouble(txtA.Text); 
                h = Convert.ToDouble(txtH.Text);
                Triangle triangle = new Triangle(byHeight, a, h); 
                lView.Items.Add("Сторона а"); 
                lView.Items.Add("Сторона b"); 
                lView.Items.Add("Сторона c"); 
                lView.Items.Add("Высота"); 
                lView.Items.Add("Периметр"); 
                lView.Items.Add("Площадь"); 
                lView.Items.Add("Существует?"); 
                lView.Items.Add("Спецификатор");

                //методы, которые по выводу сторон a, b ,c. Выводит из значения
                //выводим периметр
                //выводим значение площади
                //Вид треугольника выводим

                lView.Items[0].SubItems.Add(triangle.OutputA()); 
                lView.Items[1].SubItems.Add(triangle.OutputB()); 
                lView.Items[2].SubItems.Add(triangle.OutputC()); 
                lView.Items[3].SubItems.Add(triangle.OutputH()); 
                lView.Items[4].SubItems.Add(Convert.ToString(triangle.Perimeter())); 
                lView.Items[5].SubItems.Add(Convert.ToString(triangle.Surface())); 
                if (triangle.ExistTriangle) { lView.Items[6].SubItems.Add("Существует"); } 
                else lView.Items[6].SubItems.Add("Не существует");
                lView.Items[7].SubItems.Add(triangle.TriangleType); 
                if (triangle.TriangleType == "Равносторонний")
                {
                    img.Image = new Bitmap(@"..\..\Resources\triangleFil1.jpg");
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (triangle.TriangleType == "Равнобедренный")
                {
                    img.Image = new Bitmap(@"..\..\Resources\triangleFil2.jpg");
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (triangle.TriangleType == "Разносторонний" 
                    && triangle.ExistTriangle == true)
                {
                    img.Image = new Bitmap(@"..\..\Resources\triangleFil3.jpg");
                    img.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    img.Image = new Bitmap(@"..\..\Resources\none.png");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
