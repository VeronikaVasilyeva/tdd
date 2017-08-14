using System.Drawing;
using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;
using static TagsCloudVisualization.RectangleHelper;


namespace TagsCloudVisualization
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        private CircularCloudLayouter cloudLayouter;
        private Point center;

        [SetUp]
        public void SetUp()
        {
            center = new Point(1024 / 2, 1024 / 2);
            cloudLayouter = new CircularCloudLayouter(center);
        }

        [Test]
        public void PutNextRectangle_BeOnCenter_AfterAddedFirstRectangle()
        {
            var sizeRect = new Size(15, 50);
            var excpectedLocation = new Point(center.X - sizeRect.Width / 2, center.Y - sizeRect.Height / 2);

            var resultRectangle = cloudLayouter.PutNextRectangle(sizeRect);

            resultRectangle.Location.ShouldBeEquivalentTo(excpectedLocation);
        }

        [Test]
        public void PutNextRectangle_BeNotIntersection_AfterAddedTwoRectangles()
        {
            var rectangles = new List<Size>() { new Size(20, 30), new Size(500, 500) };

            rectangles.ForEach(r => cloudLayouter.PutNextRectangle(r));

            IsNotIntersectionLastRectangleWithAll(cloudLayouter.Rectangles).Should().BeTrue();
        }

        [TearDown]
        public void Draw_CloudLayouter()
        {
            Drawer.DrawCloudLayouter(cloudLayouter);
        }
    }
}