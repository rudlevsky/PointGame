using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FPointGame.Interfaces;

namespace FPointGame.GenericTypes
{
    public class Prey : ISubscriber<Point>
    {
        private Point Content;
        public Point SubContent;
        private readonly int imageLength;
        private readonly int fixedLength = 10;

        public Prey(int X, int Y, int length)
        {
            SubContent.X = X;
            SubContent.Y = Y;
            imageLength = length;
        }

        public void Update(Message<Point> message)
        {
            Content = message.Content;
            MovePoint();
        }

        private void MovePoint()
        {
            //SubContent.X = 0;
            //SubContent.Y = 0;

            int[,] array = new int[4, 2]
            {
                { Content.X - fixedLength, Content.Y - fixedLength },
                { Content.X + imageLength + fixedLength, Content.Y - fixedLength },
                { Content.X - fixedLength, Content.Y + fixedLength },
                { Content.X + imageLength + fixedLength, Content.Y + imageLength + fixedLength }
            };

            //bool IsFree = false;

            //while(!IsFree)
            // {


            if ((SubContent.Y + imageLength) >= array[0, 1] && (SubContent.X >= array[0, 0] && SubContent.X <= array[1, 0] ||
                SubContent.X + imageLength >= array[0, 0] && SubContent.X <= array[1, 0]))
            {
                SubContent.Y += 10;
                return;
            } 

            if (SubContent.X <= array[1, 0] && (SubContent.Y >= array[1, 1] && SubContent.Y <= array[3, 1] ||
                 SubContent.Y + imageLength >= array[1, 1] && SubContent.Y <= array[3, 1]))
            {
                SubContent.Y += 10;
                return;
            }

            if ((SubContent.Y) <= array[2, 1] && (SubContent.X >= array[2, 0] && SubContent.X <= array[3, 0] ||
                SubContent.X + imageLength >= array[2, 0] && SubContent.X <= array[3, 0]))
            {
                SubContent.Y += 10;
                return;
            }

            if ((SubContent.X + imageLength) >= array[0, 0] && (SubContent.Y >= array[0, 1] && SubContent.Y <= array[2, 1] ||
                SubContent.Y + imageLength >= array[0, 1] && SubContent.Y + imageLength <= array[2, 1]))
            {
                SubContent.Y += 10;
                return;
            }
            //  }



        }

    }
}
