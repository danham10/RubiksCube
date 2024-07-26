using RubiksCube.Cube;
using System.Text;

namespace RubiksCube.Faces;

public class Down : FaceTemplate
{
    protected override Rotation NormaliseRotation(Rotation rotation) => ReverseRotation(rotation);

    protected override ICollection<Cubie> RelocateCubie(ICollection<Cubie> cubies, Rotation rotation)
    {
        for (int x = 0; x <= CubeSize; x++)
        {
            for (int z = 0; z <= CubeSize; z++)
            {
                Cubie? transformedCubie = SelectCubie(cubies, x, 0, z);

                transformedCubie.Coordinate = NormalisedRotation == Rotation.Clockwise ?
                    new Coordinate(transformedCubie.Coordinate.Z, 0, CubeSize - transformedCubie.Coordinate.X) :
                    new Coordinate(CubeSize - transformedCubie.Coordinate.Z, 0, transformedCubie.Coordinate.X);

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

        for (int z = 0; z <= CubeSize; z++)
        {
            row = new StringBuilder();
            for (int x = 0; x <= CubeSize; x++)
            {
                var cubieFaceColour =
                    (from c in cubies
                     from cf in c.CubieFaces
                     where c.Coordinate.X == x && c.Coordinate.Z == z
                     where cf.FaceName == FaceName.Down
                     select cf.Colour).First();

                row.Append(ColourChar(cubieFaceColour));
            }

            column.AppendLine(row.ToString());
        }
        return column.ToString();
    }
}