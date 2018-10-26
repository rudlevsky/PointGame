using System.Collections.Generic;
using System.Drawing;
using FPointGame.Interfaces;

namespace FPointGame.GenericTypes
{
    /// <summary>
    /// Class contains methods and realization of ISubscriber interface.
    /// </summary>
    public class Prey : ISubscriber<Point>
    {
        /// <summary>
        /// Current point of the instance.
        /// </summary>
        public Point SubContent;
        private readonly int imageLength;
        private const int fixedLength = 10;
        private const int moveLength = 20;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="X">X coordinate of the point.</param>
        /// <param name="Y">y coordinate of the point.</param>
        /// <param name="length">Instanse length.</param>
        public Prey(int X, int Y, int length)
        {
            SubContent.X = X;
            SubContent.Y = Y;
            imageLength = length;
        }

        /// <summary>
        /// Updates instance's information.
        /// </summary>
        /// <param name="message">Passed message.</param>
        public void Update(Message<Point> message)
        {
            message.Dispose();
            MovePoint(message.Content);
        }

        private bool Contains(int coord1, int coord2, List<int> xCoord, List<int> yCoord, bool flagXY)
        {
            for (int i = coord1; i < coord1 + imageLength; i++)
            {
                if (xCoord.Contains(i) && yCoord.Contains(coord2) && flagXY)
                {
                    return true;
                }

                if (xCoord.Contains(coord2) && yCoord.Contains(i) && !flagXY)
                {
                    return true;
                }
            }

            return false;
        }

        private void MovePoint(Point content)
        {
            int[,] array = new int[4, 2]
            {
                { content.X - fixedLength, content.Y - fixedLength },
                { content.X + imageLength + fixedLength, content.Y - fixedLength },
                { content.X - fixedLength, content.Y + imageLength + fixedLength },
                { content.X + imageLength + fixedLength, content.Y + imageLength + fixedLength }
            };

            var xCoord = new List<int>();
            var yCoord = new List<int>();

            int Y = array[0, 1];

            while (Y != array[2, 1])
            {
                for (int i = array[0, 0]; i < array[1, 0]; i++)
                {
                    xCoord.Add(i);
                    yCoord.Add(Y);
                }

                Y++;
            }

            if (Contains(SubContent.X, SubContent.Y - fixedLength, xCoord, yCoord, true))
            {
                SubContent.Y += moveLength;
                return;
            }

            if (Contains(SubContent.X,SubContent.Y + imageLength + fixedLength, xCoord, yCoord, true))
            {
                SubContent.Y -= moveLength;
                return;
            }

            if (Contains(SubContent.Y, SubContent.X - fixedLength, xCoord, yCoord, false))
            {
                SubContent.X += moveLength;
                return;
            }

            if (Contains(SubContent.Y, SubContent.X + imageLength + fixedLength, xCoord, yCoord, false))
            {
                SubContent.X -= moveLength;
                return;
            }
        }
    }
}
