using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagsCloudVisualization
{
    class CircularCloudLayouter
    {
        public Point Center;
        private List<Rectangle> Rectangles = new List<Rectangle>();

        public CircularCloudLayouter(Point center)
        {
            this.Center = center;
        }

        public Rectangle PutNextRectangle(Size rectangleSize)
        {
            if(Rectangles.Count == 0) Rectangles.Add(new Rectangle(Center, rectangleSize));

            return new Rectangle();
        }
    }
}
