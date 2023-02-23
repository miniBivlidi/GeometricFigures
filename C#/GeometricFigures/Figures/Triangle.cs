using System;

namespace GeometricFigures {
    public class Triangle : ImmutableFigure {
        public double FirstSide { get; }
        public double SecondSide { get; }
        public double ThirdSide { get; }

        public Triangle(double firstSide, double secondSide, double thirdSide) {
            Guard.ValidateSize(firstSide, nameof(FirstSide));
            Guard.ValidateSize(secondSide, nameof(SecondSide));
            Guard.ValidateSize(thirdSide, nameof(ThirdSide));
            ValidateTriangleSides(firstSide, secondSide, thirdSide);
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
        }
        static void ValidateTriangleSides(double firstSide, double secondSide, double thirdSide) {
            //https://en.wikipedia.org/wiki/Triangle_inequality
            if(!(firstSide + secondSide > thirdSide && firstSide + thirdSide > secondSide && secondSide + thirdSide > firstSide))
                throw new ArgumentException($"A triangle with such sides cannot exist");
        }

        protected sealed override double CalculateImmutableSquare() {
            //https://en.wikipedia.org/wiki/Heron%27s_formula
            var semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
        }

       
    }
}
