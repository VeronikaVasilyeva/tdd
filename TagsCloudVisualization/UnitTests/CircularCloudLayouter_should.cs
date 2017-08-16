using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Extensions;
using TagsCloudVisualization.Drawer;

namespace TagsCloudVisualization.UnitTests
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        [SetUp]
        public void SetUp()
        {
            center = new Point(1024 / 2, 1024 / 2);
            cloudLayouter = new CircularCloudLayouter(center);
        }

        [TearDown]
        public void Draw_CloudLayouter()
        {
            Drawer.Drawer.DrawRectanglesWithCenterIn(cloudLayouter.LauoutCenter, cloudLayouter.Rectangles);
        }

        private CircularCloudLayouter cloudLayouter;
        private Point center;

        [Test]
        public void PutNextRectangle_BeNotIntersection_AfterAddedTwoRectangles()
        {
            var rectangles = new List<Size> {new Size(20, 30), new Size(500, 500)};

            rectangles.ForEach(r => cloudLayouter.PutNextRectangle(r));

            var lastRect = cloudLayouter.Rectangles.LastOrDefault();
            lastRect.IsIntersectionWith(cloudLayouter.Rectangles).Should().BeFalse();
        }

        [Test]
        public void PutNextRectangle_BeOnCenter_AfterAddedFirstRectangle()
        {
            var sizeRect = new Size(15, 50);
            var excpectedLocation = new Point(center.X - sizeRect.Width / 2, center.Y - sizeRect.Height / 2);

            var resultRectangle = cloudLayouter.PutNextRectangle(sizeRect);

            resultRectangle.Location.ShouldBeEquivalentTo(excpectedLocation);
        }
    }
}