using Raylib_cs;

namespace PSharp.Static
{
    public static class Mouse
    {
        public static int PMouseX { get; internal set; } = 0;

        public static int PMouseY { get; internal set; } = 0;

        public static int MouseX => Raylib.GetMouseX();

        public static int MouseY => Raylib.GetMouseY();

        public static bool MouseIsPressed => Raylib.IsMouseButtonDown(MouseButton.Left);
    }
}
