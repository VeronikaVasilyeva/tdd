using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Drawer
{
    public static class Drawer
    {
        private static readonly Action<Graphics, Point> CreateCentralPoint =
            (g, p) => g.FillEllipse(new SolidBrush(Color.Beige), p.X - 3, p.Y - 3, 6, 6);

        public static void Main(string[] args)
        {
            var c = new CircularCloudLayouter(new Point(500, 500));
            c.PutNextRectangle(new Size(20, 20));
            c.PutNextRectangle(new Size(200, 300));
            c.PutNextRectangle(new Size(300, 100));

            DrawRectanglesWithCenterIn(c.LauoutCenter, c.Rectangles);
        }

        public static void DrawRectanglesWithCenterIn(Point center, List<Rectangle> rectangles)
        {
            var image = new Bitmap(center.X * 2, center.Y * 2);
            var myPen = new Pen(Color.Red);

            using (var g = Graphics.FromImage(image))
            {
                CreateCentralPoint(g, center);
                rectangles.ForEach(r => g.DrawRectangle(myPen, r));
            }

            var fileName = DateTime.Now.GetHashCode();
            image.Save($@"D:\Crash-course\TagsCloudVisualization\TagsCloudVisualization\images\{fileName}.bmp");
        }
    }
}