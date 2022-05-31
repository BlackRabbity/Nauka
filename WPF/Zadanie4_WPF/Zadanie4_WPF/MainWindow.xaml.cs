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

namespace Zadanie4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point start, point;
        private Rectangle rectLast, rect;
        private double height, width, maxY, maxX, minX, minY;
        private double pom1, pom2;

        bool click;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void canv_MouseDown(object sender, MouseButtonEventArgs e)
        {
            canv.CaptureMouse();
            start = e.GetPosition(canv);
            rect = new Rectangle
            {
                Fill = new SolidColorBrush(Color.FromRgb(150, 100, 200)),
                Stroke = Brushes.DarkBlue,
                StrokeThickness = 2,
            };

            //Canvas.SetTop(rect, start.Y);
            //Canvas.SetLeft(rect, start.X);
            click = true;


            rectLast = rect;

            canv.Children.Add(rect);
        }

        private void canv_MouseMove(object sender, MouseEventArgs e)
        {
            point = e.GetPosition(canv);

            if (click == true)
            {

                minX = Math.Min(start.X, point.X);
                minY = Math.Min(start.Y, point.Y);
                maxX = Math.Max(start.X, point.X);
                maxY = Math.Max(start.Y, point.Y);

                height = maxY - minY;
                width = maxX - minX;

                Canvas.SetTop(rect, minY);
                Canvas.SetLeft(rect, minX);

                rect.Height = Math.Abs(height);
                rect.Width = Math.Abs(width);

            }
        }

        private void canv_MouseUp(object sender, MouseButtonEventArgs e)
        {
            click = false;
            pom1 = rectLast.Height;
            pom2 = rectLast.Width;
            Mouse.Capture(null);
        }

        private void canv_KeyDown(object sender, KeyEventArgs e)
        {
            if (rectLast != null)
            {
                // zmienianie rozmiaru

                if (Keyboard.IsKeyDown(Key.LeftShift))
                {
                    if (Keyboard.IsKeyDown(Key.Up))
                    {
                        if (rectLast.Height > 0)
                        {
                            rectLast.Height -= 1;
                        }
                        else if (rectLast.Height == 0)
                        {
                            rectLast.Height += pom1;
                        }            
                    }
                    if (Keyboard.IsKeyDown(Key.Down))
                    {
                        rectLast.Height += 1;
                    }

                    if (Keyboard.IsKeyDown(Key.Left))
                    {
                        if (rectLast.Width > 0)
                        {
                            rectLast.Width -= 1;
                        }
                        else if (rectLast.Width == 0)
                        {
                            rectLast.Width += pom2;
                        }
                    }

                    if (Keyboard.IsKeyDown(Key.Right))
                    {
                        rectLast.Width += 1;
                    }

                }else
                {
                    // przemieszczanie się

                    if (Keyboard.IsKeyDown(Key.Up))
                    {
                        Canvas.SetTop(rectLast, Canvas.GetTop(rectLast) - 5);
                    }

                    if (Keyboard.IsKeyDown(Key.Down))
                    {
                        Canvas.SetTop(rectLast, Canvas.GetTop(rectLast) + 5);
                    }

                    if (Keyboard.IsKeyDown(Key.Left))
                    {
                        Canvas.SetLeft(rectLast, Canvas.GetLeft(rectLast) - 5);
                    }

                    if (Keyboard.IsKeyDown(Key.Right))
                    {
                        Canvas.SetLeft(rectLast, Canvas.GetLeft(rectLast) + 5);
                    }
                }
              
            }

        }

    }
}
