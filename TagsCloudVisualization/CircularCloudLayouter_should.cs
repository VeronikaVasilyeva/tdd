using System.Drawing;
using NUnit.Framework;
using FluentAssertions;


namespace TagsCloudVisualization
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        private CircularCloudLayouter CloudLayouter;
        private Point Center;

        [SetUp]
        public void SetUp()
        {
            Center = new Point(1024, 1024);
            CloudLayouter = new CircularCloudLayouter(Center);
        }

        [Test]
        public void PutNextRectangle_BeOnCenter_AfterAddedFirstRectangle()
        {
            var sizeRect = new Size(5, 5);
            var excpectedLocation = new Point(Center.X - sizeRect.Width / 2, Center.Y - sizeRect.Height / 2);

            var resultRectangle = CloudLayouter.PutNextRectangle(sizeRect);

            resultRectangle.Location.ShouldBeEquivalentTo(excpectedLocation);
        }

        //[Test]
        //public void PutNextRectangle_BeNotIntersection_AfterAddedTwoRectangles()
        //{
        //    var resultRectangle = cloudLayouter.PutNextRectangle(new Size(5, 5));
        //    cloudLayouter.PutNextRectangle(new Size(5, 5));

        //    resultRectangle.Location.ShouldBeEquivalentTo(cloudLayouter.LauoutCenter);
        //}

        [TearDown]
        public void Draw_CloudLayouter()
        {
            Drawer.DrawCloudLayouter(CloudLayouter);
        }
    }
}