using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization.Helpers
{
    public static class CloudLayouterMetricsHelper
    {
        private static readonly double epsilon = 0.1;

        public static bool IsDenseCloudLayouter(CircularCloudLayouter cloudLayouter)
        {
            return cloudLayouter.GetDense() > epsilon;
        }

        private static double GetDense(this CircularCloudLayouter cloudLayouter)
        {
            var center = cloudLayouter.LauoutCenter;
            var rectangles = cloudLayouter.Rectangles;

            if (rectangles.Count == 0) return 0.0;

            var rectanglesAreaSum = rectangles.Select(r => r.GetArea()).Sum();
            var circleArea = GetRadiusCircumscribingCircleFor(rectangles, center);

            return rectanglesAreaSum / circleArea;
        }

        public static int GetRadiusCircumscribingCircleFor(List<Rectangle> rectangles, Point center)
        {
            return rectangles.Max(r => r.MaxDistTo(center));
        }

        public static bool IsCircleFormForCloudLayouter(CircularCloudLayouter cloudLayouter)
        {
            var averageRadius = cloudLayouter.Rectangles.Select(r => cloudLayouter.LauoutCenter.MaxDistTo(r)).Average();
            var maxRadius = cloudLayouter.Rectangles.Select(r => cloudLayouter.LauoutCenter.MaxDistTo(r)).Max();

            return maxRadius <= averageRadius * 2;
        }

    }
}