using System;

namespace GeometricFigures {
    /// <summary>
    /// Represents a figure that cannot be modified.
    /// </summary>
    public abstract class ImmutableFigure : IFigure {
        readonly Lazy<double> squareFactory;
        public double Square => squareFactory.Value;

        public ImmutableFigure() {
            squareFactory = new Lazy<double>(CalculateImmutableSquare);
        }

        /// <summary>
        /// Calculates the square of the figure once when it is requested first time.
        /// </summary>
        protected abstract double CalculateImmutableSquare();
    }
}
