using System;
using System.Numerics;
using static PSharp.Static.Math;

namespace PSharp
{
    /// <summary>
    /// A class to describe a two or three dimensional vector, specifically a Euclidean (also known as geometric) vector.
    /// A vector is an entity that has both magnitude and direction. The datatype, however, stores the components of the
    /// vector (x,y for 2D, and x,y,z for 3D). The magnitude and direction can be accessed via the methods mag() and heading()
    /// </summary>
    public class PVector : ICloneable
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        internal Vector3 Vector
        {
            get { return new Vector3((float)X, (float)Y, (float)Z); }
        }

        public PVector()
            : this(0, 0, 0) { }

        public PVector(double x, double y)
            : this(x, y, 0) { }

        private PVector(Vector3 vector)
            : this(vector.X, vector.Y, vector.Z) { }

        public PVector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static PVector Random2D()
        {
            return new PVector(Random(), Random(), 0);
        }

        public static PVector Random3D()
        {
            return new PVector(Random(), Random(), Random());
        }

        public static bool operator ==(PVector a, PVector b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(PVector a, PVector b)
        {
            return a.X != b.X || a.Y != b.Y || a.Z != b.Z;
        }

        public static PVector operator +(PVector a, PVector b)
        {
            return new PVector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static PVector operator -(PVector a)
        {
            return new PVector(-a.X, -a.Y, -a.Z);
        }

        public static PVector operator -(PVector a, PVector b)
        {
            return new PVector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static PVector operator *(PVector a, double scalar)
        {
            return new PVector(a.X * scalar, a.Y * scalar, a.Z * scalar);
        }

        public static PVector operator /(PVector a, double scalar)
        {
            return new PVector(a.X / scalar, a.Y / scalar, a.Z / scalar);
        }

        public PVector Copy()
        {
            return (PVector)Clone();
        }

        public double Mag()
        {
            return Sqrt(Sq(X) + Sq(Y) + Sq(Z));
        }

        public double MagSq()
        {
            return Sq(X) + Sq(Y) + Sq(Z);
        }

        public PVector Add(PVector other)
        {
            return this + other;
        }

        public PVector Sub(PVector other)
        {
            return this - other;
        }

        public PVector Mult(double scalar)
        {
            return this * scalar;
        }

        public PVector Div(double scalar)
        {
            return this / scalar;
        }

        public double Dist(PVector other)
        {
            return (this - other).Mag();
        }

        public double Dot(PVector other)
        {
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        public PVector Cross(PVector other)
        {
            return new PVector(
                Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X
            );
        }

        public PVector Normalize()
        {
            return this / Mag();
        }

        public PVector Limit(double max)
        {
            var mag = Mag();
            if (mag <= max)
            {
                return this.Copy();
            }
            return this * (max / mag);
        }

        public void SetMag(double mag)
        {
            var newVector = Normalize() * mag;
            X = newVector.X;
            Y = newVector.Y;
            Z = newVector.Z;
        }

        public double[] Array()
        {
            return [X, Y, Z];
        }

        public object Clone()
        {
            return new PVector(X, Y, Z);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PVector other = (PVector)obj;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}
