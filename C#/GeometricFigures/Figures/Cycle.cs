using System;

namespace GeometricFigures {
    public class Cycle : ImmutableFigure {
        public double Radius { get; }

        public Cycle(double radius) {
            Guard.ValidateSize(radius, nameof(Radius));
            Radius = radius;
        }

        protected override double CalculateImmutableSquare() {
            //https://en.wikipedia.org/wiki/Area_of_a_circle
            return Math.PI * Radius * Radius;
        }
    }
}
