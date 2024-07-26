using RubiksCube.Cube;
using System.Text;

namespace RubiksCube.Faces;

public class Up : FaceTemplate
{
    protected override ICollection<Cubie> RelocateCubie(ICollection<Cubie> cubies, Rotation rotation)
    {
        for (int x = 0; x <= CubeSize; x++)
        {
            for (int z = 0; z <= CubeSize; z++)
            {
                Cubie? transformedCubie = SelectCubie(cubies, x, CubeSize, z);

                transformedCubie.Coordinate = NormalisedRotation == Rotation.Clockwise ?
                    new Coordinate(transformedCubie.Coordinate.Z, CubeSize, CubeSize - transformedCubie.Coordinate.X) :
                    new Coordinate(CubeSize - transformedCubie.Coordinate.Z, CubeSize, transformedCubie.Coordinate.X);

                transformedCubies.Add(transformedCubie);
            }
        }

        return transformedCubies;
    }

    protected override FaceName RotateCubieFace(FaceName cubeFace, FaceName colourFace, Rotation rotation)
    {
        return RotateAxis(YAxis, colourFace, rotation);
    }

    public override string Display(List<Cubie> cubies)
    {
        StringBuilder row;
        StringBuilder column = new();

        for (int z = CubeSize; z >= 0; z--)
        {
            row = new StringBuilder();
            for (int x = 0; x <= CubeSize; x++)
            {
                var cubieFaceColour =
                    (from c in cubies
                     from cf in c.CubieFaces
                     where c.Coordinate.X == x && c.Coordinate.Z == z
                     where cf.FaceName == FaceName.Up
                     select cf.Colour).First();

                row.Append(ColourChar(cubieFaceColour));
            }

            column.AppendLine(row.ToString());
        }
        return column.ToString();
    }
}