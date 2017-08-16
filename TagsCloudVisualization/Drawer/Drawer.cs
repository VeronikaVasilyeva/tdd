using System;
using System.Collections.Generic;
using System.Drawing;

namespace TagsCloudVisualization.Drawer
{
    public static class Drawer
    {
        private static readonly Action<Graphics, Point> CreateCentralPoint = (g, p) => g.FillEllipse(new SolidBrush(Color.Beige), p.X - 3, p.Y - 3, 6, 6);

        public static void Draw(Size imageSize, List<Rectangle> rectangles)
        {
            var imageBitmap = new Bitmap(imageSize.Width, imageSize.Height);
            var myPen = new Pen(Color.Red);

            using (var g = Graphics.FromImage(imageBitmap))
            {
                var centralPoint = new Point(imageSize.Width / 2, imageSize.Height / 2);
                CreateCentralPoint(g, centralPoint);
                rectangles.ForEach(r => g.DrawRectangle(myPen, r));
            }

            var fileName = DateTime.Now.ToString("yyyyMMddhhmmss");
            imageBitmap.Save($@"D:\Crash-course\TagsCloudVisualization\TagsCloudVisualization\images\{fileName}.bmp");
        }
    }
}