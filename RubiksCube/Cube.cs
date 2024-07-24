namespace RubiksCube;

internal class Cube
{
    public List<Cubie> Cubies;

    public Cube()
    {
        Cubies = InitCubies();
    }

    private static List<Cubie> InitCubies()
    {
        ColourFace white = new(Colour.White, Face.Up);
        ColourFace yellow = new(Colour.Yellow, Face.Down);
        ColourFace red = new(Colour.Red, Face.Right);
        ColourFace orange = new(Colour.Orange, Face.Left);
        ColourFace green = new(Colour.Green, Face.Front);
        ColourFace blue = new(Colour.Blue, Face.Back);

        return
        [
            new Cubie(new Coordinate(0, 0, 0), green, yellow, orange),
            new Cubie(new Coordinate(1, 0, 0), green, yellow),
            new Cubie(new Coordinate(2, 0, 0), green, yellow, red),

            new Cubie(new Coordinate(0, 1, 0), green, orange),
            new Cubie(new Coordinate(1, 1, 0), green),
            new Cubie(new Coordinate(2, 1, 0), green, red),

            new Cubie(new Coordinate(0, 2, 0), green, white, orange),
            new Cubie(new Coordinate(1, 2, 0), green, white),
            new Cubie(new Coordinate(2, 2, 0), green, white, red),

            new Cubie(new Coordinate(0, 0, 1), yellow, orange),
            new Cubie(new Coordinate(1, 0, 1), yellow),
            new Cubie(new Coordinate(2, 0, 1), yellow, red),

            new Cubie(new Coordinate(0, 1, 1), orange),
            new Cubie(new Coordinate(1, 1, 1)),
            new Cubie(new Coordinate(2, 1, 1), red),

            new Cubie(new Coordinate(0, 2, 1), white, orange),
            new Cubie(new Coordinate(1, 2, 1), white),
            new Cubie(new Coordinate(2, 2, 1), white, red),

            new Cubie(new Coordinate(0, 0, 2), blue, yellow, orange),
            new Cubie(new Coordinate(1, 0, 2), blue, yellow),
            new Cubie(new Coordinate(2, 0, 2), blue, yellow, red),

            new Cubie(new Coordinate(0, 1, 2), blue, orange),
            new Cubie(new Coordinate(1, 1, 2), blue),
            new Cubie(new Coordinate(2, 1, 2), blue, red),

            new Cubie(new Coordinate(0, 2, 2), blue, white, orange),
            new Cubie(new Coordinate(1, 2, 2), blue, white),
            new Cubie(new Coordinate(2, 2, 2), blue, white, red)
        ];
    }

    public Cube Rotate(Face cubeFace, Rotation rotation)
    {
        Cubie transformingCubie;
        List<Cubie> transformedCubies = [];
        Rotation normalisedRotation = rotation;

        Console.WriteLine($"Direction {cubeFace} rotating {rotation}");


        switch (cubeFace)
        {
            case Face.Down:
            case Face.Back:
            case Face.Left:
                normalisedRotation = rotation == Rotation.Clockwise ? Rotation.AntiClockwise : Rotation.Clockwise;
                Console.WriteLine($"Direction inverted to {normalisedRotation}");
            break;
        }

        for (int x = 0; x <= 2; x++)
        {
            for (int y = 0; y <= 2; y++)
            {
                for (int z = 0; z <= 2; z++)
                {
                    transformingCubie = SelectCubie(x, y, z);

                    switch (cubeFace)
                    {
                        case Face.Up:
                        case Face.Down:
                            switch (cubeFace)
                            {
                                case Face.Up:
                                    if (y != 2)
                                        continue;
                                    break;
                                case Face.Down:
                                    if (y != 0)
                                        continue;
                                    break;
                            }

                            transformingCubie.Coordinate = normalisedRotation == Rotation.Clockwise ?
                                new Coordinate(transformingCubie.Coordinate.Z, transformingCubie.Coordinate.Y, 2 - transformingCubie.Coordinate.X) :
                                new Coordinate(2 - transformingCubie.Coordinate.Z, transformingCubie.Coordinate.Y, transformingCubie.Coordinate.X);
                            break;
                        case Face.Left:
                        case Face.Right:
                            switch (cubeFace)
                            {
                                case Face.Left:
                                    if (x != 0)
                                        continue;
                                    break;
                                case Face.Right:
                                    if (x != 2)
                                        continue;
                                    break;
                            }

                            transformingCubie.Coordinate = normalisedRotation == Rotation.Clockwise ?
                                new Coordinate(transformingCubie.Coordinate.X, 2 - transformingCubie.Coordinate.Z, transformingCubie.Coordinate.Y) :
                                new Coordinate(transformingCubie.Coordinate.X, transformingCubie.Coordinate.Z, 2 - transformingCubie.Coordinate.Y);
                            break;

                        case Face.Front:
                        case Face.Back:
                            switch (cubeFace)
                            {
                                case Face.Front:
                                    if (z != 0)
                                        continue;
                                    break;
                                case Face.Back:
                                    if (z != 2)
                                        continue;
                                    break;
                            }

                            transformingCubie.Coordinate = normalisedRotation == Rotation.Clockwise ?
                                new Coordinate(transformingCubie.Coordinate.Y, 2 - transformingCubie.Coordinate.X, transformingCubie.Coordinate.Z) :
                                new Coordinate(2 - transformingCubie.Coordinate.Y, transformingCubie.Coordinate.X, transformingCubie.Coordinate.Z);
                            break;
                    }

                    transformedCubies.Add(transformingCubie);
                }
            }
        }

        foreach (Cubie transformedCubie in transformedCubies)
        {

            foreach (var colourFace in transformedCubie.CubieFaces)
            {
                colourFace.Face = CubieRotation.Rotate(cubeFace, colourFace.Face, normalisedRotation);
            }

            var originalCubie = Cubies.Where(c => c.Id == transformedCubie.Id).First();


            Cubies.Remove(originalCubie);
            Cubies.Add(transformedCubie);

            Console.WriteLine($"Cubie {transformedCubie.Id} from {originalCubie} to {transformedCubie}");
        }

        return this;
    }

    private Cubie SelectCubie(int x, int y, int z)
    {
        var cubie = Cubies.Where(c => c.Coordinate.X == x && c.Coordinate.Y == y && c.Coordinate.Z == z);
        return (Cubie)cubie.First().Clone();
    }
}
