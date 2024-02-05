using Raylib_cs;

namespace PSharp.Static
{
    public static class Mouse
    {
        public static int PMouseX { get; internal set; } = 0;

        public static int PMouseY { get; internal set; } = 0;

        public static int MouseX => Raylib.GetMouseX();

        public static int MouseY => Raylib.GetMouseY();

        public static bool MousePressed => MouseButton is not null;

        public enum MouseButtonEnum
        {
            LEFT,
            RIGHT,
            CENTER
        }

        public static MouseButtonEnum LEFT = MouseButtonEnum.LEFT;
        public static MouseButtonEnum RIGHT = MouseButtonEnum.RIGHT;
        public static MouseButtonEnum CENTER = MouseButtonEnum.CENTER;

        public static MouseButtonEnum? MouseButton
        {
            get
            {
                if (Raylib.IsMouseButtonPressed(Raylib_cs.MouseButton.Left))
                {
                    return LEFT;
                }
                if (Raylib.IsMouseButtonPressed(Raylib_cs.MouseButton.Right))
                {
                    return RIGHT;
                }
                if (Raylib.IsMouseButtonPressed(Raylib_cs.MouseButton.Middle))
                {
                    return CENTER;
                }
                return null;
            }
        }
    }
}
