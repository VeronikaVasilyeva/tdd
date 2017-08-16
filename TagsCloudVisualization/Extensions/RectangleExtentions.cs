using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TagsCloudVisualization.Extensions
{
    public static class RectangleExtentions
    {
        public static int GetArea(this Rectangle rect)
        {
            return rect.Width * rect.Height;
        }

        public static int MaxDistTo(this Rectangle rect, Point center)
        {
            var vertices = new List<Point>
            {
                rect.Location,
                new Point(rect.Left, rect.Bottom),
                new Point(rect.Right, rect.Bottom),
                new Point(rect.Right, rect.Top)
            };

            return vertices.Select(v => (int)center.DistTo(v)).Max();
        }

        public static bool IsIntersectionWith(this Rectangle rectangle, IList<Rectangle> rectangles)
        {
            if (rectangle == null) throw new ArgumentException();

            return rectangles.Any(r => r.IsIntersection(rectangle));
        }

        public static bool IsIntersection(this Rectangle rect1, Rectangle rect2)
        {
            return !(rect1.Left >= rect2.Right ||
                     rect1.Right <= rect2.Left ||
                     rect1.Top >= rect2.Bottom ||
                     rect1.Bottom <= rect2.Top);
        }
    }
}