namespace PSharp.Static
{
    public static class Image
    {
        public static PImage LoadImage(string fileName) => new PImage(fileName);

        public static PImage CreateImage(int width, int height) => new PImage(width, height);
    }
}
