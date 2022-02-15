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
        int _0pos = 250;
        int _1pos = 250;

        int ym = 250;
        int xm = 500;

        int way = 0;

        

        const int buffrsize = 90;
        public MainWindow()
        {
            InitializeComponent();
      
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
            ////přeělat to na booly
        {//wasd (0)
            if(e.Key == Key.W)
            {
                if(_0pos != 500)
                {
                    _0pos -= 10;
                }
            }
            else if(e.Key == Key.S)
            {
                if(_0pos != 30)
                {
                    _0pos += 10;
                }
            }
        //arrows (1)
            if(e.Key == Key.Up)
            {
                if (_1pos != 500)
                {
                    _1pos -= 10;
                }
            }
            else if(e.Key == Key.Down)
            {
                if (_1pos != 30)
                {
                    _1pos += 10;
                }
                control.Content = _0pos + "__" + _1pos;
            }
            Draw_bufers(buffer0, buffer1, _0pos, _1pos);
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            DispatcherTimer myTimer = new DispatcherTimer();
            myTimer.Tick += new EventHandler(DisplayTimeEvent);
            myTimer.Interval = new TimeSpan(0,0,0,0,10);
            myTimer.Start();
            Field_main.Children.Add(ball);
            Field_main.Children.Add(buffer1);
            Field_main.Children.Add(buffer0);
            Canvas.SetLeft(buffer0, 10);
            Canvas.SetRight(buffer1, 10);

        }
        Rectangle buffer0 = new Rectangle() 
        { 
        Width = 15,
        Height = buffrsize,
        Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128))
        };
        Rectangle buffer1 = new Rectangle()
        {
            Width = 15,
            Height = buffrsize,
            Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128))
        };

        Ellipse ball = new Ellipse()
        {
            Height = 30,
            Width = 30,
            Fill = new SolidColorBrush(Color.FromRgb(128, 128, 128))
        };

        public void DisplayTimeEvent(object source, EventArgs e)
        {
            if(xm == 980 -15 // je nakraju a má dobrý y)
           switch(way)
            {
                case 0: 
                    if(xm != 20 + 15)
                    {
                        xm -= 5;
                        Draw_ball(ball,Field_main, xm, ym);
                    }
                    else 
                    {way = 1; }
                    break;
                case 1:
                    if(xm != 980 - 15)
                    {
                        xm += 5;
                        Draw_ball(ball,Field_main, xm, ym);
                    }
                    else { way = 0; }
                    break;  
            }
            
        }
        public void Draw_ball(Ellipse b, Canvas c, int x, int y)
        {                     
            Canvas.SetTop(b, y);
            Canvas.SetLeft(b, x);
        }

        public void Draw_bufers(Rectangle r0, Rectangle r1, int p0, int p1)
        {
            Canvas.SetTop(r0, p0);
            Canvas.SetTop(r1, p1);
        }
    }
}
