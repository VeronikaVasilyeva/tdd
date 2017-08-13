using System.Drawing;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
        public void PutNextRectangle_CenterPut_AddedFirstRectangle()
        {
            var resultRectangle = cloudLayouter.PutNextRectangle(new Size(5, 5));
            resultRectangle.Location.ShouldBeEquivalentTo(cloudLayouter.Center);
        }

    }
}