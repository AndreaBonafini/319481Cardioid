using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _319481CulminatingProject.Cardioid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Ellipse Circle = new Ellipse();
        public int angle;
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Hello and welcome to the visualization of a Cardioid.\nFor the size of the line we advice a size smaller that 1,but bigger than 0.1");
        }

        private void BtnCardioid_Click(object sender, RoutedEventArgs e)
        {
            double LineSize;
            double.TryParse(txtLineSize.Text, out LineSize);
            int Dots;
            int.TryParse(txtDots.Text, out Dots);
            int MF;
            int.TryParse(txtMF.Text, out MF);
            Circle.Width = 500;
            Circle.Height = 500;
            Circle.Stroke = Brushes.Red;
            Circle.StrokeThickness = 2;
            canvas.Children.Add(Circle);
            Canvas.SetLeft(Circle, 100);
            Canvas.SetTop(Circle, 50);
            angle = 360 / Dots;
            Point[] points = new Point[Dots * 4];
            Ellipse[] Dot = new Ellipse[Dots * 4];
            Line[] Cardioid = new Line[360];
            for (int i = 0; i < 1080; i++)
            {
                points[0].X = 100;
                points[0].Y = 275;
                points[i].X = Math.Sin(i * angle * Math.PI / 180) * 250 + 348;
                points[i].Y = Math.Cos(i * angle * Math.PI / 180) * 250 + 298;
                points[i] = new Point(points[i].X, points[i].Y);
                Dot[i] = new Ellipse();
                Dot[i].Width = 4;
                Dot[i].Height = 4;
                Dot[i].Fill = Brushes.Black;
                Dot[i].Stroke = Brushes.Black;
                canvas.Children.Add(Dot[i]);
                Canvas.SetLeft(Dot[i], points[i].X);
                Canvas.SetTop(Dot[i], points[i].Y);
                for (int k = 0; k < Dots; k++)
                {
                    if (i == 0)
                    {
                    }
                    else if (k % i == 0)
                    {
                        Cardioid[k] = new Line();
                        points[k].X = Math.Sin(i * MF * angle * Math.PI / 180) * 250 + 350;
                        points[k].Y = Math.Cos(i * MF * angle * Math.PI / 180) * 250 + 300;
                        Cardioid[k].X1 = points[i].X;
                        Cardioid[k].Y1 = points[i].Y;
                        Cardioid[k].X2 = points[k].X;
                        Cardioid[k].Y2 = points[k].Y;
                        Cardioid[k].Stroke = Brushes.Black;
                        Cardioid[k].StrokeThickness = LineSize;
                        canvas.Children.Add(Cardioid[k]);
                    }
                }
            }
        }
        private void BtnIncreasingMF_Click(object sender, RoutedEventArgs e)
        {
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += update;
            timer.Start();
        }
        public void update(object sender, EventArgs e)
        {
            canvas.Children.Clear();
            int j = 1;
            j = j - 1;
            int Dots;
            int.TryParse(txtDots.Text, out Dots);
            int MF;
            int.TryParse(txtMF.Text, out MF);
            Circle.Width = 500;
            Circle.Height = 500;
            Circle.Stroke = Brushes.Red;
            Circle.StrokeThickness = 2;
            canvas.Children.Add(Circle);
            Canvas.SetLeft(Circle, 100);
            Canvas.SetTop(Circle, 50);
            angle = 360 / Dots;
            Point[] points = new Point[Dots * 4];
            Ellipse[] Dot = new Ellipse[Dots * 4];
            Line[] Cardioid = new Line[360];
            for (int i = 0; i < 1080; i++)
            {
                points[0].X = 100;
                points[0].Y = 275;
                points[i].X = Math.Sin(i * angle * Math.PI / 180) * 250 + 348;
                points[i].Y = Math.Cos(i * angle * Math.PI / 180) * 250 + 298;
                points[i] = new Point(points[i].X, points[i].Y);
                Dot[i] = new Ellipse();
                Dot[i].Width = 4;
                Dot[i].Height = 4;
                Dot[i].Fill = Brushes.Black;
                Dot[i].Stroke = Brushes.Black;
                canvas.Children.Add(Dot[i]);
                Canvas.SetLeft(Dot[i], points[i].X);
                Canvas.SetTop(Dot[i], points[i].Y);
                for (int k = 0; k < Dots; k++)
                {
                    if (i == 0)
                    {
                    }
                    else if (k % i == 0)
                    {
                        Cardioid[k] = new Line();
                        points[k].X = Math.Sin((j + MF) * i * angle * Math.PI / 180) * 250 + 350;
                        points[k].Y = Math.Cos((j + MF) * i * angle * Math.PI / 180) * 250 + 300;
                        Cardioid[k].X1 = points[i].X;
                        Cardioid[k].Y1 = points[i].Y;
                        Cardioid[k].X2 = points[k].X;
                        Cardioid[k].Y2 = points[k].Y;
                        Cardioid[k].Stroke = Brushes.Black;
                        Cardioid[k].StrokeThickness = 0.5;
                        canvas.Children.Add(Cardioid[k]);
                    }
                }
            }
        }
    }
}