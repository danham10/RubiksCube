using RubiksCube;
using System.Text;

var cube = new Cube();

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

    Console.WriteLine("Front");
    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int x = 0; x <= 2; x++)
        {
            var cubieFaceColour =
                from c in cube.Cubies
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Y == y
                where cv.Face == Face.Front
                select new { cv.Colour };


            row.Append(cubieFaceColour.First().Colour.ToString().First());
        }

        Console.WriteLine(row);
    }

    Console.WriteLine("Left");

    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int z = 2; z >= 0; z--)
        {
            var cubieFaceColour =
                from c in cube.Cubies
                from cv in c.CubieFaces
                where c.Coordinate.Z == z && c.Coordinate.Y == y
                where cv.Face == Face.Left
                select new { cv.Colour };

            row.Append(cubieFaceColour.First().Colour.ToString().First());
        }

        Console.WriteLine(row);
    }

    Console.WriteLine("Right");

    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int z = 0; z <= 2; z++)
        {
            var cubieFaceColour =
                from c in cube.Cubies
                from cv in c.CubieFaces
                where c.Coordinate.Z == z && c.Coordinate.Y == y
                where cv.Face == Face.Right
                select new { cv.Colour };

            row.Append(cubieFaceColour.First().Colour.ToString().First());
        }

        Console.WriteLine(row);
    }

    Console.WriteLine("Back");

    for (int y = 2; y >= 0; y--)
    {
        row = new StringBuilder();
        for (int x = 2; x >= 0; x--)
        {
            var cubieFaceColour =
                from c in cube.Cubies
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Y == y
                where cv.Face == Face.Back
                select new { cv.Colour };

            row.Append(cubieFaceColour.First().Colour.ToString().First());
        }

        Console.WriteLine(row);
    }

    Console.WriteLine("Up");

    for (int z = 2; z >= 0; z--)
    {
        row = new StringBuilder();
        for (int x = 0; x <= 2; x++)
        {
            var cubieFaceColour =
                from c in cube.Cubies
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Z == z
                where cv.Face == Face.Up
                select new { cv.Colour };

            row.Append(cubieFaceColour.First().Colour.ToString().First());
        }

        Console.WriteLine(row);
    }

    Console.WriteLine("Down");

    for (int z = 0; z <= 2; z++)
    {
        row = new StringBuilder();
        for (int x = 0; x <= 2; x++)
        {
            var cubieFaceColour =
                from c in cube.Cubies
                from cv in c.CubieFaces
                where c.Coordinate.X == x && c.Coordinate.Z == z
                where cv.Face == Face.Down
                select new { cv.Colour };

            row.Append(cubieFaceColour.First().Colour.ToString().First());
        }

        Console.WriteLine(row);
    }
}








