using RubiksCube;
using System.Text;

var cube = new Cube();

// Replicates the steps in the coding exercise
cube.Rotate(Face.Front, Rotation.Clockwise)
    .Rotate(Face.Right, Rotation.AntiClockwise)
    .Rotate(Face.Up, Rotation.Clockwise)
    .Rotate(Face.Back, Rotation.AntiClockwise)
    .Rotate(Face.Left, Rotation.Clockwise)
    .Rotate(Face.Down, Rotation.AntiClockwise);

DisplayCube();


void DisplayCube()
{
    StringBuilder row;

    Console.WriteLine(Face.Front);
    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int x = 0; x <= 2; x++)
        {
            var cubieFaceColour =
                (from c in cube.Cubies
                from cf in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Y == y
                where cf.Face == Face.Front
                select cf.Colour).First();


            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    Console.WriteLine(Face.Left);

    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int z = 2; z >= 0; z--)
        {
            var cubieFaceColour =
                (from c in cube.Cubies
                from cf in c.CubieFaces
                where c.Coordinate.Z == z && c.Coordinate.Y == y
                where cf.Face == Face.Left
                select cf.Colour).First();

            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    Console.WriteLine(Face.Right);

    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int z = 0; z <= 2; z++)
        {
            var cubieFaceColour =
                (from c in cube.Cubies
                from cf in c.CubieFaces
                where c.Coordinate.Z == z && c.Coordinate.Y == y
                where cf.Face == Face.Right
                select cf.Colour).First();

            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    Console.WriteLine(Face.Back);

    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int x = 2; x >= 0; x--)
        {
            var cubieFaceColour =
                (from c in cube.Cubies
                from cf in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Y == y
                where cf.Face == Face.Back
                select cf.Colour).First();

            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    Console.WriteLine(Face.Up);

    for (int z = 2; z >= 0; z--)
    {
        row = new StringBuilder();
        for (int x = 0; x <= 2; x++)
        {
            var cubieFaceColour =
                (from c in cube.Cubies
                from cf in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Z == z
                where cf.Face == Face.Up
                select cf.Colour).First();

            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    Console.WriteLine(Face.Down);

    for (int z = 0; z <= 2; z++)
    {
        row = new StringBuilder();
        for (int x = 0; x <= 2; x++)
        {
            var cubieFaceColour =
                (from c in cube.Cubies
                from cf in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Z == z
                where cf.Face == Face.Down
                select cf.Colour).First();

            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    static char ColourChar(Colour cubieFaceColour) => cubieFaceColour.ToString().First();
}








