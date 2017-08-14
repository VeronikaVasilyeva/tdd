using System.Drawing;
using NUnit.Framework;
using FluentAssertions;


namespace TagsCloudVisualization
{
    [TestFixture]
    public class CircularCloudLayouter_Should
    {
        private CircularCloudLayouter cloudLayouter;

        [SetUp]
        public void SetUp()
        {
            cloudLayouter = new CircularCloudLayouter(new Point(50, 50));
        }

        [Test]
        public void PutNextRectangle_BeOnCenter_AfterAddedFirstRectangle()
        {
            var resultRectangle = cloudLayouter.PutNextRectangle(new Size(5, 5));
            resultRectangle.Location.ShouldBeEquivalentTo(cloudLayouter.Center);
        }

        [Test]
        public void PutNextRectangle_BeNotIntersection_AfterAddedTwoRectangles()
        {
            var resultRectangle = cloudLayouter.PutNextRectangle(new Size(5, 5));
            cloudLayouter.PutNextRectangle(new Size(5, 5));

            resultRectangle.Location.ShouldBeEquivalentTo(cloudLayouter.Center);
        }

        [TearDown]
        public void Draw_CloudLayouter()
        {
            Drawer.DrawCloudLayouter(cloudLayouter);
        }
    }
}