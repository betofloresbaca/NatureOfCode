using System;

namespace PSharp
{
    public class PColor : ICloneable
    {
        public PColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        internal byte R { get; set; }
        internal byte G { get; set; }
        internal byte B { get; set; }
        internal byte A { get; set; }

        public object Clone()
        {
            return new PColor(R, G, B, A);
        }

        public override string ToString()
        {
            return $"(R:{R}, G:{G}, B:{B}, A:{A})";
        }

        internal Raylib_cs.Color ToRaylibColor()
        {
            return new Raylib_cs.Color()
            {
                R = R,
                G = G,
                B = B,
                A = A
            };
        }
    }
}
