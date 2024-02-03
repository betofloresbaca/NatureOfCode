using PSharp;
using static PSharp.Static.Color;
using static PSharp.Static.Graphics;
using static PSharp.Static.Image;
using static PSharp.Static.Mouse;

PImage barrelRoll = null;
PImage run = null;
PImage fragment = null;

void Setup()
{
    Size(800, 800);
    Background(100);
    NoStroke();
    barrelRoll = LoadImage("Images/BarrelRoll.png");
    run = LoadImage("Images/Run.png");
    barrelRoll.Set(0, 0, run);
    barrelRoll.LoadPixels();
    for (int i = 0; i < barrelRoll.Width; i++)
    {
        for (int j = 0; j < barrelRoll.Height; j++)
        {
            if (j % 10 == 0)
            {
                barrelRoll.Pixels[j * barrelRoll.Width + i] = WHITE;
            }
            if (j % 10 == 1 || j % 10 == 9)
            {
                barrelRoll.Pixels[j * barrelRoll.Width + i] = BLACK;
            }
        }
    }
    barrelRoll.UpdatePixels();
    fragment = barrelRoll.Get(50, 50, 200, 150);
    fragment.Save();
}

void Draw()
{
    Background(BLACK);
    Image(fragment, MouseX, MouseY, 400, 400);
}

new Window(Setup, Draw).Run();
