using RubiksCube.Cube;
using System.Text;

namespace RubiksCube.Faces;

public class Front : FaceTemplate
{
    protected override ICollection<Cubie> RelocateCubie(ICollection<Cubie> cubies, Rotation rotation)
    {
        for (int x = 0; x <= CubeSize; x++)
        {
            for (int y = 0; y <= CubeSize; y++)
            {
                Cubie? transformedCubie = SelectCubie(cubies, x, y, 0);

                transformedCubie.Coordinate = NormalisedRotation == Rotation.Clockwise ?
                    new Coordinate(transformedCubie.Coordinate.Y, CubeSize - transformedCubie.Coordinate.X, 0) :
                    new Coordinate(CubeSize - transformedCubie.Coordinate.Y, transformedCubie.Coordinate.X, 0);

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
            for (int x = 0; x <= CubeSize; x++)
            {
                var cubieFaceColour =
                    (from c in cubies
                     from cf in c.CubieFaces
                     where c.Coordinate.X == x && c.Coordinate.Y == y
                     where cf.FaceName == FaceName.Front
                     select cf.Colour).First();


                row.Append(ColourChar(cubieFaceColour));
            }

            column.AppendLine(row.ToString());
        }
        return column.ToString();
    }
}