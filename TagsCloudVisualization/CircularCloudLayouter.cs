﻿using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization
{
    public class CircularCloudLayouter
    {
        public Point LauoutCenter;
        public List<Rectangle> Rectangles = new List<Rectangle>();

        public CircularCloudLayouter(Point center)
        {
            LauoutCenter = center;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            Point location;

            if (Rectangles.Count == 0)
            {
                location = new Point(LauoutCenter.X - rectangleSize.Width / 2,
                    LauoutCenter.Y - rectangleSize.Height / 2);
            }
            else
            {
                location = new Point(LauoutCenter.X - rectangleSize.Width / 2,
                    LauoutCenter.Y - rectangleSize.Height / 2);
            }

            var rectangle = new Rectangle(location, rectangleSize);
            Rectangles.Add(rectangle);
            return rectangle;
        }
    }
}