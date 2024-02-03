using System;
using PSharp.Models;
using Raylib_cs;

namespace PSharp
{
    public static class Graphics
    {
        // FrameCount
        public static int FrameCount { get; internal set; }

        internal static RenderTexture2D RendererTexture;
        private static PColor fillColor = Color.WHITE;
        private static PColor strokeColor = Color.BLACK;

        public static void CreateCanvas(int width, int height)
        {
            Raylib.InitWindow(width, height, "PSharp");
            RendererTexture = Raylib.LoadRenderTexture(width, height);
            Raylib.SetTextureFilter(RendererTexture.Texture, TextureFilter.Bilinear);
            Raylib.SetTargetFPS(120);
            Math.RandomSeed((uint)System.DateTime.Now.Ticks);
        }

        #region Background

        public static void Background(byte r, byte g, byte b, byte a)
        {
            Raylib.BeginTextureMode(RendererTexture);
            Raylib.DrawRectangle(
                0,
                0,
                RendererTexture.Texture.Width,
                RendererTexture.Texture.Height,
                new PColor(r, g, b, a).ToRaylibColor()
            );
            Raylib.EndTextureMode();
        }

        public static void Background(byte r, byte g, byte b)
        {
            Background(r, g, b, 255);
        }

        public static void Background(byte gray, byte a)
        {
            Background(gray, gray, gray, a);
        }

        public static void Background(byte gray)
        {
            Background(gray, gray, gray, 255);
        }

        public static void Background(PColor color)
        {
            Background(color.R, color.G, color.B, color.A);
        }

        #endregion Background

        #region Fill

        public static void Fill(byte r, byte g, byte b, byte a)
        {
            fillColor = new PColor(r, g, b, a);
        }

        public static void Fill(byte r, byte g, byte b)
        {
            Fill(r, g, b, 255);
        }

        public static void Fill(byte gray, byte a)
        {
            Fill(gray, gray, gray, a);
        }

        public static void Fill(byte gray)
        {
            Fill(gray, gray, gray, 255);
        }

        public static void Fill(PColor color)
        {
            Fill(color.R, color.G, color.B, color.A);
        }

        public static void NoFill()
        {
            fillColor = null;
        }

        #endregion Fill

        #region Stroke

        public static void Stroke(byte r, byte g, byte b, byte a)
        {
            strokeColor = new PColor(r, g, b, a);
        }

        public static void Stroke(byte r, byte g, byte b)
        {
            Stroke(r, g, b, 255);
        }

        public static void Stroke(byte gray, byte a)
        {
            Stroke(gray, gray, gray, a);
        }

        public static void Stroke(byte gray)
        {
            Stroke(gray, gray, gray, 255);
        }

        public static void Stroke(PColor color)
        {
            Stroke(color.R, color.G, color.B, color.A);
        }

        public static void NoStroke()
        {
            strokeColor = null;
        }

        #endregion Stroke

        public static void Ellipse(int x, int y, float width, float height)
        {
            DrawFigureInTexture(
                () => Raylib.DrawEllipse(x, y, width / 2, height / 2, fillColor.ToRaylibColor()),
                () =>
                    Raylib.DrawEllipseLines(
                        x,
                        y,
                        width / 2,
                        height / 2,
                        strokeColor.ToRaylibColor()
                    )
            );
        }

        public static void Square(int x, int y, float side)
        {
            var intSide = (int)Math.Round(side);
            DrawFigureInTexture(
                () => Raylib.DrawRectangle(x, y, intSide, intSide, fillColor.ToRaylibColor()),
                () => Raylib.DrawRectangleLines(x, y, intSide, intSide, strokeColor.ToRaylibColor())
            );
        }

        private static void DrawFigureInTexture(Action fill, Action stroke)
        {
            Raylib.BeginTextureMode(RendererTexture);
            if (fillColor is not null)
            {
                fill();
            }
            if (strokeColor is not null)
            {
                stroke();
            }
            Raylib.EndTextureMode();
        }

        public static void Print(object text)
        {
            Console.WriteLine(text.ToString());
        }

        //private void SaveCanvas(string path = "output.png")
        //{
        //    // Saves the RenderTexture2D as an image to disk
        //    Image image = Raylib.LoadImageFromTexture(RendererTexture.Texture);
        //    Raylib.ExportImage(image, StringToSBytePtr(path));
        //}

        //public static sbyte* StringToSBytePtr(string str)
        //{
        //    // Convert the string to a byte array in UTF-8 encoding
        //    byte[] bytes = Encoding.UTF8.GetBytes(str);

        //    // Allocate unmanaged memory and get a pointer to it
        //    IntPtr ptr = Marshal.AllocHGlobal(bytes.Length + 1);

        //    // Copy byte array to unmanaged memory
        //    Marshal.Copy(bytes, 0, ptr, bytes.Length);

        //    // Set the last byte to 0 to null-terminate the string
        //    Marshal.WriteByte(ptr + bytes.Length, 0);

        //    // Cast IntPtr to sbyte* if necessary (in an unsafe context)
        //    // sbyte* sbytePtr = (sbyte*)ptr;

        //    return (sbyte*)ptr.ToPointer();
        //}
    }
}
