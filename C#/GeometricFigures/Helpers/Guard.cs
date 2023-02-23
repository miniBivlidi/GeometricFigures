using System;

namespace GeometricFigures {
    public static class Guard {
        public static void ValidateSize(double size, string sizeName) {
            if(size < 0 || double.IsNaN(size))
                throw new ArgumentException($"Argument {sizeName} cannot be negative or not a number");
        }
    }
}
