using RubiksCube;

public class ColourFace : ICloneable
{
    public Colour Colour;
    public Face Face;

    public ColourFace(Colour colour, Face direction)
    {
        Colour = colour;
        Face = direction;
    }

    public override string ToString() => $"{Colour} {Face}";

    public object Clone() => new ColourFace(Colour, Face);
}