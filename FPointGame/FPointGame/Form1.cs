using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPointGame.GenericTypes;

namespace FPointGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            chanSubscriber = new Prey(subscriber.Left, subscriber.Top, subscriber.Width);
            chanel = new Channel<Point>();
            chanel.AddSubscriber(chanSubscriber);
            hunt = new Hunter<Point>(chanel);        
        }

        private const int LEFT = 37;
        private const int REIGHT = 39;
        private const int TOP = 38;
        private const int BOTTOM = 40;

        private Hunter<Point> hunt;
        private Channel<Point> chanel;
        private Prey chanSubscriber;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case LEFT:
                    {
                        hunter.Left -= 5;
                        break;
                    }
                case REIGHT:
                    {
                        hunter.Left += 5;
                        break;
                    }
                case TOP:
                    {
                        hunter.Top -= 5;
                        break;
                    }
                case BOTTOM:
                    {
                        hunter.Top += 5;
                        break;
                    }
            }

            hunt.Content = new Point(hunter.Left, hunter.Top);
            subscriber.Left = chanSubscriber.SubContent.X;
            subscriber.Top = chanSubscriber.SubContent.Y;
        }








    }
}
