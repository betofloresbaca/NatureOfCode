using System;

namespace PSharp.Models
{
    public class PColor : ICloneable
    {
        public PColor(byte r, byte g, byte b, byte a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        //internal ColorMode Mode { get; set; }
        internal byte R { get; set; }
        internal byte G { get; set; }
        internal byte B { get; set; }
        internal byte A { get; set; }

        public object Clone()
        {
            return new PColor(this.R, this.G, this.B, this.A);
        }

        internal Raylib_cs.Color ToRaylibColor()
        {
            return new Raylib_cs.Color()
            {
                R = this.R,
                G = this.G,
                B = this.B,
                A = this.A
            };
        }
    }
}
