namespace PSharp.Static
{
    public static class Color
    {
        public static readonly PColor WHITE = new PColor(255, 255, 255, 255);
        public static readonly PColor BLACK = new PColor(0, 0, 0, 255);
        public static readonly PColor RED = new PColor(255, 0, 0, 255);
        public static readonly PColor GREEN = new PColor(0, 255, 0, 255);
        public static readonly PColor BLUE = new PColor(0, 0, 255, 255);
        public static readonly PColor YELLOW = new PColor(255, 255, 0, 255);
        public static readonly PColor MAGENTA = new PColor(255, 0, 255, 255);
        public static readonly PColor CYAN = new PColor(0, 255, 255, 255);
        public static readonly PColor PURPLE = new PColor(128, 0, 128, 255);
        public static readonly PColor ORANGE = new PColor(255, 165, 0, 255);
        public static readonly PColor BROWN = new PColor(165, 42, 42, 255);
        public static readonly PColor PINK = new PColor(255, 192, 203, 255);
        public static readonly PColor GRAY = new PColor(128, 128, 128, 255);
        public static readonly PColor DARK_GRAY = new PColor(64, 64, 64, 255);
        public static readonly PColor LIGHT_GRAY = new PColor(211, 211, 211, 255);
        public static readonly PColor TRANSPARENT = new PColor(0, 0, 0, 0);
        public static readonly PColor VIOLET = new PColor(238, 130, 238, 255);
        public static readonly PColor BEIGE = new PColor(245, 245, 220, 255);
        public static readonly PColor MAROON = new PColor(128, 0, 0, 255);
        public static readonly PColor OLIVE = new PColor(128, 128, 0, 255);
        public static readonly PColor TEAL = new PColor(0, 128, 128, 255);
        public static readonly PColor NAVY = new PColor(0, 0, 128, 255);

        public static int Red(PColor color)
        {
            return color.R;
        }

        public static int Green(PColor color)
        {
            return color.G;
        }

        public static int Blue(PColor color)
        {
            return color.B;
        }

        public static int Alpha(PColor color)
        {
            return color.A;
        }
    }
}
