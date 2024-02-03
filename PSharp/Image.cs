using PSharp.Models;

namespace PSharp
{
    public static class Image
    {
        public static PImage LoadImage(string fileName) => new PImage(fileName);
    }
}
