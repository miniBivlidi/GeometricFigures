using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;

namespace GeometricFigures.Tests {
    [TestFixture]
    public class FigureTests {
        static TestCaseData[] InvalidParametersSource = new TestCaseData[] {
            new TestCaseData(new Func<IFigure>(() => new Triangle(-1, 1, 1)), nameof(Triangle.FirstSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(double.NaN, 1, 1)), nameof(Triangle.FirstSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(1, -1, 1)), nameof(Triangle.SecondSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(1, double.NaN, 1)), nameof(Triangle.SecondSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(1, 1, -1)), nameof(Triangle.ThirdSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(1, 1, double.NaN)), nameof(Triangle.ThirdSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(double.NaN, 1, double.NaN)), nameof(Triangle.FirstSide)),
            new TestCaseData(new Func<IFigure>(() => new Triangle(1.5, 9.3, 6.2)), "cannot exist"),
            new TestCaseData(new Func<IFigure>(() => new Cycle(-1)), nameof(Cycle.Radius)),
            new TestCaseData(new Func<IFigure>(() => new Cycle(double.NaN)), nameof(Cycle.Radius)),
        };
        [TestCaseSource(nameof(InvalidParametersSource))]
        public void InvalidParameters(Func<IFigure> invalidFigureFactory, string argumentName) {
            Assert.That(() => { invalidFigureFactory(); }, Throws.ArgumentException.With.Property(nameof(Exception.Message)).Contains(argumentName));
        }

        static TestCaseData[] SquareSource = new TestCaseData[] {
            new TestCaseData(new Triangle(3, 4, 5), 6),
            new TestCaseData(new Triangle(5.2, 7.4, 9.3), 19.204),
            new TestCaseData(new Cycle(3.9), 47.783),
        };
        [TestCaseSource(nameof(SquareSource))]
        public void Square(IFigure figure, double expectedSquare) {
            Assert.That(MathHelper.CompareRealNumbers(expectedSquare, figure.Square), Is.True);
        }

        [Test]
        public void ImmutableFigureSquareCalculationCount() {
            var mock = new Mock<ImmutableFigure>();
            mock.Protected()
                .Setup<double>("CalculateImmutableSquare")
                .Returns(() => 0)
                .Verifiable();

            var firstSquareValue = mock.Object.Square;
            mock.Verify();

            var secondSquareValue = mock.Object.Square;
            Assert.That(mock.Invocations.Count, Is.EqualTo(1));
        }

        static TestCaseData[] IsTriangleRightAngledSource = new TestCaseData[] {
            new TestCaseData(new Triangle(3, 4, 5), true),
            new TestCaseData(new Triangle(3.7461, 4.9948, 6.2435), true),
            new TestCaseData(new Triangle(5.2, 7.4, 9.3), false),
        };
        [TestCaseSource(nameof(IsTriangleRightAngledSource))]
        public void IsTriangleRightAngled(Triangle triangle, bool expectedIsRightAngled) {
            Assert.That(triangle.IsRightAngled(), Is.EqualTo(expectedIsRightAngled));
        }
    }
}
