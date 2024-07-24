namespace RubiksCube;

public struct Coordinate(int x, int y, int z) : ICloneable
{
    public int X = x;
    public int Y = y;
    public int Z = z;

    public override string ToString() => $"X: {X}, Y: {Y}, Z: {Z}";

    public object Clone() => new Coordinate(X, Y, Z);
}