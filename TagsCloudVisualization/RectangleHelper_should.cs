using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace TagsCloudVisualization
{
    [TestFixture]
    class RectangleHelper_Should
    {
        private CircularCloudLayouter cloudLayouter;
        private Point center;

        [SetUp]
        public void SetUp()
        {
            center = new Point(1024 / 2, 1024 / 2);
            cloudLayouter = new CircularCloudLayouter(center);
        }

        private static object[] OneInsideOther = 
        {
            new object[] { new Rectangle(70, 40, 30, 30), new Rectangle(50, 20, 70, 70) },
            new object[] { new Rectangle(50, 20, 70, 70), new Rectangle(70, 40, 30, 30) }
        };

        private static object[] SelfIntersection =
        {
            new object[] {new Rectangle(70, 40, 30, 30), new Rectangle(70, 40, 30, 30)}
        };

        private static object[] Intersections =
        {
            new object[] {new Rectangle(70, 40, 30, 30), new Rectangle(70, 40, 30, 30)}
        };

        [TestCaseSource(nameof(OneInsideOther))]
        public void IsNotIntersection_BeFalse_OneInsideOther(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsNotIntersection(rect2).Should().BeFalse();
        }

        [TestCaseSource(nameof(SelfIntersection))]
        public void IsNotIntersection_BeFalse_SelfIntersection(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsNotIntersection(rect2).Should().BeFalse();
        }

        [TearDown]
        public void Draw_CloudLayouter()
        {
            Drawer.DrawRectanglesWithCenterIn(cloudLayouter.LauoutCenter, cloudLayouter.Rectangles);
        }

    }
}
