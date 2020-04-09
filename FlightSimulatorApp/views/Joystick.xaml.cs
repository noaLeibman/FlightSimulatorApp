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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightSimulatorApp.Views
{
    /// <summary>
    /// Interaction logic for Joystick.xaml
    /// </summary>
    public partial class Joystick : UserControl
    {
        Storyboard mySTB;
        public Joystick()
        {
            
            InitializeComponent();
            mySTB = Knob.FindResource("CenterKnob") as Storyboard;
            mySTB.Stop();
        }
        Point first_pos_point = new Point();
        private void Knob_MouseDown(object sender, MouseButtonEventArgs e)
        {
            mySTB.Stop();
            if (e.ChangedButton == MouseButton.Left)
            {
                first_pos_point = e.GetPosition(this);
            }
        }

        private void Knob_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                double x = e.GetPosition(this).X - first_pos_point.X;
                double y = e.GetPosition(this).Y - first_pos_point.Y;
                Point last_good = new Point();
                if (Math.Sqrt(x * x + y * y) <= KnobBase.Width / 2)
                {
                    knobPosition.X = x;
                    knobPosition.Y = y;
                    last_good = new Point(x, y);
                    if (Math.Sqrt(x * x + y * y) > KnobBase.Width / 2)
                    {
                        knobPosition.X = x;
                        knobPosition.Y = y;
                    }
                }

            }
        }

        public Point returnValues()
        {
           double xpos = knobPosition.X;
           double ypos = knobPosition.Y;
            
            Point currPoint = new Point(xpos,ypos);
            return currPoint;
        }

        private void Base_MouseUp(object sender, MouseButtonEventArgs e)
        {
            knobPosition.X = 0;
            knobPosition.Y = 0;
            mySTB.Begin();
        }
    }
}
