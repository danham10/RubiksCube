using RubiksCube.Cube;
using System.Text;

namespace RubiksCube.Faces;

public class Right : FaceTemplate
{
    protected override ICollection<Cubie> RelocateCubie(ICollection<Cubie> cubies, Rotation rotation)
    {
        for (int y = 0; y <= CubeSize; y++)
        {
            for (int z = 0; z <= CubeSize; z++)
            {
                Cubie? transformedCubie = SelectCubie(cubies, CubeSize, y, z);

                transformedCubie.Coordinate = NormalisedRotation == Rotation.Clockwise ?
                    new Coordinate(CubeSize, CubeSize - transformedCubie.Coordinate.Z, transformedCubie.Coordinate.Y) :
                    new Coordinate(CubeSize, transformedCubie.Coordinate.Z, CubeSize - transformedCubie.Coordinate.Y);

                transformedCubies.Add(transformedCubie);
            }
        }

        return transformedCubies;
    }

    protected override FaceName RotateCubieFace(FaceName cubeFace, FaceName colourFace, Rotation rotation)
    {
        return RotateAxis(XAxis, colourFace, rotation);
    }

    public override string Display(List<Cubie> cubies)
    {
        StringBuilder row;
        StringBuilder column = new();

        for (int y = CubeSize; y >= 0; y--)
        {
            row = new StringBuilder();
            for (int z = 0; z <= CubeSize; z++)
            {
                var cubieFaceColour =
                    (from c in cubies
                     from cf in c.CubieFaces
                     where c.Coordinate.Z == z && c.Coordinate.Y == y
                     where cf.FaceName == FaceName.Right
                     select cf.Colour).First();

                row.Append(ColourChar(cubieFaceColour));
            }

            column.AppendLine(row.ToString());
        }
        return column.ToString();
    }
}