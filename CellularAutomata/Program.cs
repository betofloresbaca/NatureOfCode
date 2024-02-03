using CellularAutomata;
using PSharp;
using static PSharp.Static.Graphics;
using static PSharp.Static.Math;

const int ruleset = 22; // Change this to change the patttern
const int cellSide = 1;
const int totalCells = 2251;
const int width = totalCells * cellSide;
const int height = width / 2;

Automata automata = new Automata(ruleset, totalCells);
int generation = 0;

void Setup()
{
    Size(width, height);
    RandomSeed(0);
    NoStroke();
    Background(155);
}

void Draw()
{
    // Avoid calculationn when over the height
    if (generation > height / cellSide)
        return;
    automata.Draw(0, generation * cellSide, cellSide);
    automata.ComputeNextGen();
    generation++;
}

new Window(Setup, Draw).Run();
