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
        private List<int> iks;
        private List<int> igr;

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

        private bool Contains(int coord1, int coord2, bool flagXY)
        {
            for (int i = coord1; i < coord1 + imageLength; i++)
            {
                if (iks.Contains(i) && igr.Contains(coord2) && flagXY)
                {
                    return true;
                }

                if (iks.Contains(coord2) && igr.Contains(i) && !flagXY)
                {
                    return true;
                }
            }

            return false;
        }

        private void MovePoint()
        {
            int[,] array = new int[4, 2]
            {
                { Content.X - fixedLength, Content.Y - fixedLength },
                { Content.X + imageLength + fixedLength, Content.Y - fixedLength },
                { Content.X - fixedLength, Content.Y + imageLength + fixedLength },
                { Content.X + imageLength + fixedLength, Content.Y + imageLength + fixedLength }
            };

            iks = new List<int>();
            igr = new List<int>();

            int Y = array[0, 1];

            while (Y != array[2, 1])
            {
                for (int i = array[0, 0]; i < array[1, 0]; i++)
                {
                    iks.Add(i);
                    igr.Add(Y);
                }

                Y++;
            }

            if (Contains(SubContent.X, SubContent.Y - fixedLength, true))
            {
                SubContent.Y += 20;
                return;
            }

            if (Contains(SubContent.X,SubContent.Y + imageLength + fixedLength, true))
            {
                SubContent.Y -= 20;
                return;
            }

            if (Contains(SubContent.Y, SubContent.X - fixedLength, false))
            {
                SubContent.X += 20;
                return;
            }

            if (Contains(SubContent.Y, SubContent.X + imageLength + fixedLength, false))
            {
                SubContent.X -= 20;
                return;
            }

            //int[,] coordinates = new int[]

            //bool IsFree = false;

            //while(!IsFree)
            // {


            /*if ((SubContent.Y + imageLength) >= array[0, 1] && (SubContent.X >= array[0, 0] && SubContent.X <= array[1, 0] ||
                SubContent.X + imageLength >= array[0, 0] && SubContent.X <= array[1, 0]))
            {
                SubContent.Y += 10;
                return;
            } */

            /*if ( (SubContent.X <= array[1, 0] && array[1, 0] <= SubContent.X + imageLength) && (  ((SubContent.Y >= array[1, 1]) && (SubContent.Y <= array[3, 1])) ||
                 (((SubContent.Y + imageLength) >= array[1, 1]) && (SubContent.Y <= array[3, 1]))) )
            {
                SubContent.Y += 10;
                return;
            }
            /*
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
            //  }*/



        }

    }
}
