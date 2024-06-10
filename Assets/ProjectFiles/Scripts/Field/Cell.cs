
public class Cell
{
    public readonly bool Occupied;
    public readonly int X;
    public readonly int Y;

    public Cell(bool occupied, int x, int y) 
    {
        Occupied = occupied;
        X = x; 
        Y = y;
    }
}
