using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization.UnitTests
{
    [TestFixture]
    class PointExtensions_Should
    {
        private static object[] Points =
        {
            new object[] {new Point(0, 0), new Point(0, 0)},
            new object[] {new Point(0, 0), new Point(10, 10)},
            new object[] {new Point(3, 4), new Point(7, 2)},
            new object[] {new Point(-3, -4), new Point(7, -2)},
            new object[] {new Point(7, 7), new Point(3, 3)}
        };

        [TestCaseSource(nameof(Points))]
        public void DistTo_HaveDistanceBetween(Point p1, Point p2)
        {
            var expectedDistance = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            p1.DistTo(p2).Should().Be(expectedDistance);
        }

        [TestCaseSource(nameof(Points))]
        public void DistTo_BeEquivalent(Point p1, Point p2)
        {
            p1.DistTo(p2).Should().Be(p2.DistTo(p1));
        }
    }
}
