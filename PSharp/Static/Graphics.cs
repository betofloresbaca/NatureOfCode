using System;
using System.Numerics;
using Raylib_cs;

namespace PSharp.Static
{
    public static class Graphics
    {
        // FrameCount
        public static int FrameCount { get; internal set; }

        internal static RenderTexture2D RendererTexture;
        private static PColor fillColor = Color.WHITE;
        private static PColor strokeColor = Color.BLACK;

        public static void Size(int width, int height)
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

        #region Figures

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

        #endregion Figures

        #region Image


        public static void Image(PImage image, int x, int y, int w, int h)
        {
            Raylib.BeginTextureMode(RendererTexture);
            Rectangle sourceRec = new Rectangle(0, 0, image.Width, image.Height);
            Rectangle destRec = new Rectangle(x, y, w, h);
            Vector2 origin = new Vector2(0, 0);
            Raylib.DrawTexturePro(
                image.Texture,
                sourceRec,
                destRec,
                origin,
                0.0f,
                Color.WHITE.ToRaylibColor()
            );
            Raylib.EndTextureMode();
        }

        public static void Image(PImage image, int x, int y)
        {
            Image(image, x, y, image.Width, image.Height);
        }

        #endregion Image

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
    }
}
