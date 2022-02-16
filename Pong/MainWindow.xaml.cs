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
using System.Timers;
using System.Windows.Threading;

namespace Pong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer myTimer = new DispatcherTimer();
        Random r = new Random();

        Ellipse ball = new Ellipse()
        {
            Height = 30,
            Width = 30,
            Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128))
        };
        Rectangle buffer0 = new Rectangle()
        {
            Width = 15,
            Height = buffrsize,
            Fill = new SolidColorBrush(Color.FromRgb(128, 0, 0))
        };
        Rectangle buffer1 = new Rectangle()
        {
            Width = 15,
            Height = buffrsize,
            Fill = new SolidColorBrush(Color.FromRgb(0, 0, 128))
        };

        int _0pos = 250;
        int _1pos = 250;

        int ym = 250;
        int xm = 500;

        int way_x;
        int way_y;

        int yct = 5;
        int xct = 5;

        const int buffrsize = 90;
        double scorenf = 0;

        public MainWindow()
        {
            InitializeComponent();
            way_x = r.Next(1);
            way_y = r.Next(1);
            yct= r.Next(5);

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
           
        {//wasd (0)
            if (e.Key == Key.S)
            {
                w = true;
            }
            else if (e.Key == Key.W)
            {
                s = true;
            }
            //ijkl (1)
            if (e.Key == Key.K)
            {
                up = true;
            }
            else if (e.Key == Key.I)
            {
                down = true;
            }
            if(e.Key == Key.Space)
            {
                start_Click(sender, e);
            }
        }
       

        private void start_Click(object sender, RoutedEventArgs e)
        {
            start.IsEnabled = false;
            
            myTimer.Tick += new EventHandler(DisplayTimeEvent);
            myTimer.Interval = new TimeSpan(0,0,0,0,10);
            myTimer.Start();
            Field_main.Children.Add(ball);
            Field_main.Children.Add(buffer1);
            Field_main.Children.Add(buffer0);
            Canvas.SetLeft(buffer0, 10);
            Canvas.SetTop(buffer0, 250 + buffrsize / 2);
            Canvas.SetLeft(buffer1, 990);
            Canvas.SetTop(buffer1, 250 + buffrsize / 2);

        }
        
        public void DisplayTimeEvent(object source, EventArgs e)
        {
            Draw_bufers(buffer0, buffer1, _0pos, _1pos);
            if (xm == 20)
            {
                if(_0pos + (buffrsize / 2) +5 > ym! & ym > _0pos - (buffrsize / 2) -5)
                { }
                else
                { Lose_0(); }
            }
            else if(xm == 980)
            {
                if (_1pos + (buffrsize / 2) +5 > ym! & ym > _1pos - (buffrsize / 2) -5)
                { }
                else
                { Lose_1(); }
            }


            if (w == true)
            {
                if (_0pos < 500)
                {
                    _0pos += 10;
                }
            }
            else if (s == true)
            {
                if (_0pos > 0)
                {
                    _0pos -= 10;
                }
            }
            //arrows (1)
            if (up == true)
            {
                if (_1pos < 500)
                {
                    _1pos += 10;
                }
            }
            else if (down == true)
            {
                if (_1pos > 0)
                {
                    _1pos -= 10;
                }

            }

            switch (way_x)
            {
                    case 0:
                        if (xm > 20)
                        {
                            xm -= xct;
                          
                        }
                        else
                        { way_x = 1; }
                        break;
                    case 1:
                        if (xm < 975)
                        {
                            xm += xct;
                            
                        }
                        else { way_x = 0; }
                        break;                
            }

           switch(way_y)
           {
                case 0:
                    if(ym - yct > 0 + 10)
                    { 
                        ym -= yct;
                        Draw_ball(ball, Field_main, xm, ym);
                    }
                    else
                    { way_y = 1; }
                    break;
                case 1:
                    if(ym + yct < 500 - 10)
                    {
                        ym += yct;
                        Draw_ball(ball, Field_main, xm, ym);
                    }
                    else
                    { way_y = 0; }
                    break;
           }
            
            scorenf += 0.04;
            scorep.Content = "Score: " + Math.Round(scorenf);
        }
        public void Draw_ball(Ellipse b, Canvas c, int x, int y)
        {                     
            Canvas.SetTop(b, y);
            Canvas.SetLeft(b, x);
        }

        public void Draw_bufers(Rectangle r0, Rectangle r1, int p0, int p1)
        {
            Canvas.SetTop(r0, p0 - (buffrsize / 2));
            Canvas.SetTop(r1, p1 - (buffrsize / 2));
        }

        public void Lose_0()
        {
            ball.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            winf.Background = new SolidColorBrush(Color.FromRgb(0, 0, 128));
            
            myTimer.Stop();
            Lose l = new Lose();
            l.Show();
            
            Close();
            
        }

        public void Lose_1()
        {
            ball.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            winf.Background = new SolidColorBrush(Color.FromRgb(128, 0, 0));
            
            myTimer.Stop();
            Lose l = new Lose();
            l.Show();

            Close();

        }

        bool up = false;
        bool down = false;
        bool w = false;
        bool s = false;

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
               w = false;
            }
            else if (e.Key == Key.W)
            {
              s= false;
            }
            //arrows (1)
            if (e.Key == Key.K)
            {
              up = false;
            }
            else if (e.Key == Key.I)
            {
             down = false;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            { xct = int.Parse(sss.Text); }
            catch
            { MessageBox.Show("!Input a whole number!"); }
            
        }
    }
}
