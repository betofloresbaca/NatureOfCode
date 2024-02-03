using static PSharp.Static.Graphics;

namespace CellularAutomata
{
    internal class Automata
    {
        private byte ruleset;
        private byte[] cells;

        public Automata(byte ruleset, int numberCells)
        {
            this.ruleset = ruleset;
            this.cells = new byte[numberCells];
            this.cells[cells.Length / 2] = 1;
        }

        public void ComputeNextGen()
        {
            byte[] nextGen = new byte[cells.Length];
            for (int i = 0; i < cells.Length; i++)
            {
                // Warp to get left and right nighbours
                int left = cells[(cells.Length + i - 1) % cells.Length];
                int center = cells[i];
                int right = cells[(cells.Length + i + 1) % cells.Length];
                // Get the index to query the ruleset
                int index = (left << 2) | (center << 1) | right;
                // Get the bit in the ruleset index
                nextGen[i] = (byte)((ruleset & (1 << index)) >> index);
            }
            cells = nextGen;
        }

        public void Draw(int xStart, int y, int cellSide)
        {
            for (int i = 0; i < cells.Length; i++)
            {
                var x = xStart + i * cellSide;
                Fill((byte)(255 - cells[i] * 255));
                Square(x, y, cellSide);
            }
        }
    }
}
