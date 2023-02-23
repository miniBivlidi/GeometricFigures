using System;

namespace GeometricFigures {
    public static class MathHelper {
        const double _epsilon = 0.001;

        public static bool CompareRealNumbers(double x, double y, double? epsilon = _epsilon) {
            return Math.Abs(x - y) <= epsilon;
        }

        public static bool IsRightAngled(this Triangle triangle) {
            //https://en.wikipedia.org/wiki/Pythagorean_theorem
            return CompareRealNumbers(triangle.FirstSide * triangle.FirstSide + triangle.SecondSide * triangle.SecondSide, triangle.ThirdSide * triangle.ThirdSide);
        }
    }
}
