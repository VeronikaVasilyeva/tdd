using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    static class Drawer
    {
        public static void Main(string[] args)
        {
            DrawCloudLayouter(new CircularCloudLayouter(new Point(5,5)));
        }

        public static void DrawCloudLayouter(CircularCloudLayouter cloudLayouter)
        {
            var image = new Bitmap(1024, 1024);

            using (var g = Graphics.FromImage(image))
            {
                var myPen = new Pen(Color.Red);
                g.DrawRectangle(myPen, new Rectangle(0, 0, 200, 300));
            }

            var fileName = DateTime.Now.Millisecond;
            image.Save($@"D:\Crash-course\TagsCloudVisualization\TagsCloudVisualization\images\{fileName}.bmp");
        }

    }
}
