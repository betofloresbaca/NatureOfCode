using System;
using System.Collections.Generic;
using System.Linq;
using Raylib_cs;

namespace PSharp.Static
{
    public static class Math
    {
        private static Random random = new Random(0);

        #region Constants

        public const double PI = System.Math.PI;
        public const double HALF_PI = PI / 2;
        public const double QUARTER_PI = PI / 4;
        public const double TWO_PI = 2 * PI;
        public const double TAU = TWO_PI;

        #endregion Constants

        #region Random

        public static void RandomSeed(uint seed)
        {
            random = new Random((int)seed);
            Raylib.SetRandomSeed(seed);
        }

        public static double Random()
        {
            return random.NextDouble();
        }

        public static int Random(int maxValue)
        {
            return random.Next(maxValue);
        }

        public static int Random(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static T Random<T>(IEnumerable<T> enumerable)
        {
            var list = enumerable as IList<T> ?? enumerable.ToList();
            if (list.Count == 0)
            {
                throw new InvalidOperationException(
                    "Cannot select a random element from an empty sequence."
                );
            }
            int index = random.Next(list.Count);
            return list[index];
        }
        #endregion Random

        #region Basic Math

        public static double Abs(double x) => System.Math.Abs(x);

        public static double Floor(double x) => System.Math.Floor(x);

        public static double Ceil(double x) => System.Math.Ceiling(x);

        public static double Max(double n0, double n1) => System.Math.Max(n0, n1);

        public static double Max(double[] nums) => nums.Max();

        public static double Min(double n0, double n1) => System.Math.Min(n0, n1);

        public static double Min(double[] nums) => nums.Min();

        public static double Pow(double n, double e) => System.Math.Pow(n, e);

        public static double Sq(double n) => n * n;

        public static double Sqrt(double x) => System.Math.Sqrt(x);

        public static double Exp(double x) => System.Math.Exp(x);

        public static double Log(double x) => System.Math.Log(x);

        public static double Round(double x) => System.Math.Round(x);

        public static double Frac(double x) => x - Floor(x);
        #endregion Basic Math

        #region Trigonometry

        public static double Sin(double x) => System.Math.Sin(x);

        public static double Cos(double x) => System.Math.Cos(x);

        public static double Acos(double x) => System.Math.Acos(x);

        public static double Tan(double x) => System.Math.Tan(x);

        public static double Asin(double x) => System.Math.Asin(x);

        public static double ACos(double x) => System.Math.Acos(x);

        public static double Atan(double x) => System.Math.Atan(x);

        public static double Atan2(double y, double x) => System.Math.Atan2(y, x);

        public static double Degrees(double radians) => radians * 180 / PI;

        public static double Radians(double degrees) => degrees * PI / 180;

        #endregion Trigonometry

        #region Extended Math

        public static double Constrain(double x, double min, double max) =>
            System.Math.Clamp(x, min, max);

        public static double Dist(double x1, double y1, double x2, double y2) =>
            Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

        public static double Dist(
            double x1,
            double y1,
            double z1,
            double x2,
            double y2,
            double z2
        ) => Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));

        public static double Lerp(double start, double stop, double amt) =>
            start + (stop - start) * amt;

        public static double Mag(double x, double y) => Sqrt(x * x + y * y);

        public static double Map(
            double value,
            double start1,
            double stop1,
            double start2,
            double stop2,
            bool withinBounds = false
        )
        {
            double scaleFactor = (stop2 - start2) / (stop1 - start1);
            double mappedValue = start2 + (value - start1) * scaleFactor;
            if (withinBounds)
            {
                mappedValue = Constrain(mappedValue, start2, stop2);
            }
            return mappedValue;
        }

        public static double Norm(double value, double start, double stop) =>
            Map(value, start, stop, 0, 1);
        #endregion Extended Math
    }
}
