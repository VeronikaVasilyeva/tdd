using System;
using System.Drawing;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization.UnitTests
{
    [TestFixture]
    internal class RectangExtensions_Should
    {
        #region GetArea

        private static object[] Rectangles =
        {
            new object[] {new Rectangle(70, 40, 30, 30)},
            new object[] {new Rectangle(70, 40, 30, 0)},
            new object[] {new Rectangle(70, 40, 0, 0)},
            new object[] {new Rectangle(50, 20, 70, 70)}
        };

        [Test, TestCaseSource(nameof(Rectangles))]
        public void GetArea_HaveArea(Rectangle rectangle)
        {
            rectangle.GetArea().Should().Be(rectangle.Width * rectangle.Height);
        }

        #endregion

        #region IsIntersection

        private static object[] OneInsideOtherRectangles =
        {
            new object[] {new Rectangle(70, 40, 30, 30), new Rectangle(50, 20, 70, 70)},
            new object[] {new Rectangle(50, 20, 70, 70), new Rectangle(70, 40, 30, 30)}
        };

        private static object[] SelfIntersectionRectangle =
        {
            new object[] {new Rectangle(70, 40, 30, 30), new Rectangle(70, 40, 30, 30)}
        };

        private static object[] VariousIntersectingRectangles =
        {
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(50, 20, 100, 200)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(40, 20, 30, 30)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(40, 45, 60, 10)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(20, 20, 70, 30)}
        };

        private static object[] VariousNotIntersectingRectangles =
        {
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(10, 20, 30, 20)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(50, 20, 100, 20)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(60, 10, 30, 300)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(55, 70, 60, 10)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(25, 50, 25, 10)},
            new object[] {new Rectangle(50, 40, 10, 30), new Rectangle(60, 20, 25, 20)}
        };

        [TestCaseSource(nameof(OneInsideOtherRectangles))]
        [TestCaseSource(nameof(SelfIntersectionRectangle))]
        [TestCaseSource(nameof(VariousIntersectingRectangles))]
        [TestCaseSource(nameof(VariousNotIntersectingRectangles))]
        public void IsInersections_BeEquivalent(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsIntersection(rect2).Should().Be(rect2.IsIntersection(rect1));
        }

        [TestCaseSource(nameof(OneInsideOtherRectangles))]
        public void IsIntersection_BeTrue_OneInsideOther(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsIntersection(rect2).Should().BeTrue();
        }

        [TestCaseSource(nameof(SelfIntersectionRectangle))]
        public void IsIntersection_BeTrue_SelfIntersection(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsIntersection(rect2).Should().BeTrue();
        }

        [TestCaseSource(nameof(VariousIntersectingRectangles))]
        public void IsIntersection_BeTrue_IntersectingRectangles(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsIntersection(rect2).Should().BeTrue();
        }

        [TestCaseSource(nameof(VariousNotIntersectingRectangles))]
        public void IsIntersection_BeFalse_NotIntersectingRectangles(Rectangle rect1, Rectangle rect2)
        {
            rect1.IsIntersection(rect2).Should().BeFalse();
        }

        #endregion

        #region IsIntersectionsWith

        //TODO: create test! 

        #endregion


        #region MaxDistTo
        
        private static object[] CenterWithRectangle =
        {
            new object[] { new Point(10, 10), new Rectangle(5, 5, 4, 2) }
        };

       // [TestCaseSource(nameof(CenterWithRectangle))]
       [Test]
        public void MaxDistTo_HaveMaxDistance()
        {
            var r = new Rectangle(5, 5, 4, 2).MaxDistTo(new Point(10, 10)).Should().Be((int)Math.Sqrt(50));
        }

        #endregion
    }
}