using System.Drawing;

namespace TagsCloudVisualization
{
    class Program
    {
        public static void Main(string[] args)
        {
            var c = new CircularCloudLayouter(new Point(500, 500));
            c.PutNextRectangle(new Size(20, 20));
            c.PutNextRectangle(new Size(200, 300));
            c.PutNextRectangle(new Size(300, 100));

            var imageSize = new Size(1000, 1000);
            Drawer.Drawer.Draw(imageSize, c.Rectangles);

            //Console.WriteLine("Press enter...");
            //Console.ReadLine();
        }
    }
}