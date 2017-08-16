using System;
using System.Drawing;

namespace TagsCloudVisualization.Extensions
{
    public static class PointExtentions
    {
        public static double DistTo(this Point point1, Point point2)
        {
            var x = point1.X - point2.X;
            var y = point1.Y - point2.Y;
            return Math.Sqrt(x * x + y * y);
        }
    }
}