using System;
using Raylib_cs;

namespace PSharp.Models
{
    public class PImage : IDisposable
    {
        public int Width { get; internal set; }
        public int Height { get; internal set; }

        public PColor[] Pixels { get; internal set; }
        private Texture2D Texture { get; init; }

        public PImage(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            Raylib_cs.Image image = Raylib.GenImageColor(
                width,
                height,
                Color.WHITE.ToRaylibColor()
            );
            this.Texture = Raylib.LoadTextureFromImage(image);
            Raylib.UnloadImage(image); // Is ti ok
        }

        internal PImage(string path)
        {
            this.Texture = Raylib.LoadTexture(path);
        }

        internal PImage(Texture2D texture)
        {
            this.Texture = texture;
            this.Width = texture.Width;
            this.Height = texture.Height;
        }

        public void LoadPixels()
        {
            Raylib_cs.Image image = Raylib.LoadImageFromTexture(this.Texture);
            unsafe
            {
                Raylib_cs.Color* colors = Raylib.LoadImageColors(image);
                this.Pixels = new PColor[image.Width * image.Height];
                for (int i = 0; i < image.Width * image.Height; i++)
                {
                    this.Pixels[i] = new PColor(colors[i].R, colors[i].G, colors[i].B, colors[i].A);
                }
            }
            Raylib.UnloadImage(image);
        }

        public void UpdatePixels()
        {
            Raylib.UpdateTexture(this.Texture, GetPixelsAsByteArray());
        }

        public PImage Get(int x, int y, int w, int h)
        {
            Raylib_cs.Image sourceImage = Raylib.LoadImageFromTexture(this.Texture);
            Raylib.ImageCrop(ref sourceImage, new Rectangle(x, y, w, h));
            Texture2D croppedTexture = Raylib.LoadTextureFromImage(sourceImage);
            return new PImage(croppedTexture);
        }

        public void Set(int x, int y, PImage image)
        {
            Raylib.UpdateTextureRec(
                this.Texture,
                new Rectangle(x, y, image.Width, image.Height),
                image.GetPixelsAsByteArray()
            );
        }

        private byte[] GetPixelsAsByteArray()
        {
            if (this.Pixels is null)
            {
                this.LoadPixels();
            }
            byte[] bytes = new byte[this.Width * this.Height * 4];
            for (int i = 0; i < this.Width * this.Height; i++)
            {
                bytes[i * 4] = this.Pixels[i].R;
                bytes[i * 4 + 1] = this.Pixels[i].G;
                bytes[i * 4 + 2] = this.Pixels[i].B;
                bytes[i * 4 + 3] = this.Pixels[i].A;
            }
            return bytes;
        }

        public void Dispose()
        {
            Raylib.UnloadTexture(this.Texture);
        }
    }
}
