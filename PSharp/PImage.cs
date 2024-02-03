using System;
using Raylib_cs;
using static PSharp.Static.Color;

namespace PSharp
{
    public class PImage : IDisposable
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        public PColor[] Pixels { get; internal set; }
        internal Texture2D Texture { get; init; }

        public PImage(int width, int height)
        {
            Width = width;
            Height = height;
            Image image = Raylib.GenImageColor(width, height, WHITE.ToRaylibColor());
            Texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image); // Is ti ok
        }

        internal PImage(string path)
        {
            this.Texture = Raylib.LoadTexture(path);
            this.Width = Texture.Width;
            this.Height = Texture.Height;
        }

        internal PImage(Texture2D texture)
        {
            Texture = texture;
            Width = texture.Width;
            Height = texture.Height;
        }

        public void LoadPixels()
        {
            Image image = Raylib.LoadImageFromTexture(Texture);
            unsafe
            {
                Color* colors = Raylib.LoadImageColors(image);
                Pixels = new PColor[image.Width * image.Height];
                for (int i = 0; i < image.Width * image.Height; i++)
                {
                    Pixels[i] = new PColor(colors[i].R, colors[i].G, colors[i].B, colors[i].A);
                }
            }
            Raylib.UnloadImage(image);
        }

        public void UpdatePixels()
        {
            Raylib.UpdateTexture(Texture, GetPixelsAsByteArray());
        }

        public PImage Get(int x, int y, int w, int h)
        {
            Image sourceImage = Raylib.LoadImageFromTexture(Texture);
            Raylib.ImageCrop(ref sourceImage, new Rectangle(x, y, w, h));
            Texture2D croppedTexture = Raylib.LoadTextureFromImage(sourceImage);
            return new PImage(croppedTexture);
        }

        public void Set(int x, int y, PImage image)
        {
            Raylib.UpdateTextureRec(
                Texture,
                new Rectangle(x, y, image.Width, image.Height),
                image.GetPixelsAsByteArray()
            );
        }

        public void Save(string path = "output.png")
        {
            Image image = Raylib.LoadImageFromTexture(this.Texture);
            Raylib.ExportImage(image, path);
        }

        private byte[] GetPixelsAsByteArray()
        {
            if (Pixels is null)
            {
                LoadPixels();
            }
            byte[] bytes = new byte[Width * Height * 4];
            for (int i = 0; i < Width * Height; i++)
            {
                bytes[i * 4] = Pixels[i].R;
                bytes[i * 4 + 1] = Pixels[i].G;
                bytes[i * 4 + 2] = Pixels[i].B;
                bytes[i * 4 + 3] = Pixels[i].A;
            }
            return bytes;
        }

        public void Dispose()
        {
            Raylib.UnloadTexture(Texture);
        }
    }
}
