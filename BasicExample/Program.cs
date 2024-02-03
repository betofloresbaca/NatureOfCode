using PSharp;
using static PSharp.Graphics;
using static PSharp.Mouse;

void Setup()
{
    CreateCanvas(400, 400);
    Background(100);
    NoStroke();
}

void Draw()
{
    //Print($"{MouseX} -- {MouseY}");
    if (MouseIsPressed)
    {
        Print("Pressed");
        Fill(0);
    }
    else
    {
        Fill(255);
    }
    Square(MouseX, MouseY, 80);
}

new Window(Setup, Draw).Run();
