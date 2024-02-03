using System;
using System.Numerics;
using Raylib_cs;

namespace PSharp
{
    public class Window
    {
        private Action setup;
        private Action draw;

        public Window(Action setup = null, Action draw = null)
        {
            this.setup = setup ?? Nothing;
            this.draw = draw ?? Nothing;
        }

        private void Nothing() { }

        public void Run()
        {
            setup();
            if (!Raylib.IsWindowReady())
            {
                Graphics.CreateCanvas(100, 100);
            }
            while (!Raylib.WindowShouldClose())
            {
                var pmousex = Mouse.MouseX;
                var pmousey = Mouse.MouseY;
                // Draw to the texture
                draw();
                // Draw the drawed texture to the screen
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib_cs.Color.White);
                DrawVFlippedTexture();
                Raylib.EndDrawing();
                Mouse.PMouseX = pmousex;
                Mouse.PMouseY = pmousey;
            }
            Raylib.UnloadRenderTexture(Graphics.RendererTexture);
            Raylib.CloseWindow();
            Graphics.FrameCount++;
        }

        private void DrawVFlippedTexture()
        {
            Rectangle sourceRec = new Rectangle(
                0,
                0,
                Graphics.RendererTexture.Texture.Width,
                -Graphics.RendererTexture.Texture.Height
            );
            Rectangle destRec = new Rectangle(
                0,
                0,
                Graphics.RendererTexture.Texture.Width,
                Graphics.RendererTexture.Texture.Height
            );
            Vector2 origin = new Vector2(0, 0);
            Raylib.DrawTexturePro(
                Graphics.RendererTexture.Texture,
                sourceRec,
                destRec,
                origin,
                0.0f,
                Raylib_cs.Color.White
            );
        }
    }
}
