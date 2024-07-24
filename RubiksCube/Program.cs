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
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Y == y
                where cv.Face == Face.Front
                select cv.Colour).First();


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
                from cv in c.CubieFaces
                where c.Coordinate.Z == z && c.Coordinate.Y == y
                where cv.Face == Face.Left
                select cv.Colour).First();

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
                from cv in c.CubieFaces
                where c.Coordinate.Z == z && c.Coordinate.Y == y
                where cv.Face == Face.Right
                select cv.Colour).First();

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
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Y == y
                where cv.Face == Face.Back
                select cv.Colour).First();

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
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Z == z
                where cv.Face == Face.Up
                select cv.Colour).First();

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
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Z == z
                where cv.Face == Face.Down
                select cv.Colour).First();

            row.Append(ColourChar(cubieFaceColour));
        }

        Console.WriteLine(row);
    }

    static char ColourChar(Colour cubieFaceColour) => cubieFaceColour.ToString().First();
}








