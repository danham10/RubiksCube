using RubiksCube.Cube;
using System.Text;

namespace RubiksCube.Faces;

public class Back : FaceTemplate
{
    protected override Rotation NormaliseRotation(Rotation rotation) => ReverseRotation(rotation);

    protected override ICollection<Cubie> RelocateCubie(ICollection<Cubie> cubies, Rotation rotation)
    {
        for (int x = 0; x <= CubeSize; x++)
        {
            for (int y = 0; y <= CubeSize; y++)
            {
                Cubie? transformedCubie = SelectCubie(cubies, x, y, CubeSize);
                    
                transformedCubie.Coordinate = NormalisedRotation == Rotation.Clockwise ?
                    new Coordinate(transformedCubie.Coordinate.Y, CubeSize - transformedCubie.Coordinate.X, CubeSize) :
                    new Coordinate(CubeSize - transformedCubie.Coordinate.Y, transformedCubie.Coordinate.X, CubeSize);

                transformedCubies.Add(transformedCubie);
            }
        }

        return transformedCubies;
    }

    protected override FaceName RotateCubieFace(FaceName cubeFace, FaceName colourFace, Rotation rotation)
    {
        return RotateAxis(ZAxis, colourFace, rotation);
    }

    public override string Display(List<Cubie> cubies)
    {
        StringBuilder row;
        StringBuilder column = new();

        for (int y = CubeSize; y >= 0; y--)
        {
            row = new StringBuilder();
            for (int x = CubeSize; x >= 0; x--)
            {
                var cubieFaceColour =
                    (from c in cubies
                     from cf in c.CubieFaces
                     where c.Coordinate.X == x && c.Coordinate.Y == y
                     where cf.FaceName == FaceName.Back
                     select cf.Colour).First();


                row.Append(ColourChar(cubieFaceColour));
            }

            column.AppendLine(row.ToString());
        }
        return column.ToString();
    }
}