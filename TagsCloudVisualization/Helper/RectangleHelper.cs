using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    static class RectangleHelper
    {
        public static int FindRadiusMinCircumscribingCircleFor(List<Rectangle> rectangles, Point center)
        {
            //return rectangles.Max(r => r.DistTo(center));
            return 0;
        }



        public static bool IsNotIntersection(this Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Left >= rect2.Right ||
                rect1.Right <= rect2.Left ||
                rect1.Top >= rect2.Bottom ||
                rect1.Bottom <= rect2.Top)
                return true;

            return false;
        }
    }
}
