using RubiksCube;

public class ColourFace : ICloneable
{
    public Colour Colour;
    public FaceName FaceName;

    public ColourFace(Colour colour, FaceName direction)
    {
        Colour = colour;
        FaceName = direction;
    }

    public override string ToString() => $"{Colour} {FaceName}";

    public object Clone() => new ColourFace(Colour, FaceName);
}