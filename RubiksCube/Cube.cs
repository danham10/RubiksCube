using System.Diagnostics;

namespace RubiksCube;

public class Cube
{
    public List<Cubie> Cubies;

    /// <summary>
    /// From a 0 index
    /// </summary>
    private const int CubeSize = 2; 

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

    /// <summary>
    /// Rotate a face of the cube in the specified direction
    /// </summary>
    /// <param name="cubeFace"></param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    public Cube Rotate(Face cubeFace, Rotation rotation)
    {
        List<Cubie> transformedCubies = [];

        Debug.WriteLine($"Direction {cubeFace} rotating {rotation}");

        Rotation normalisedRotation = NormaliseRotation(cubeFace, rotation);
        RelocateCubies(cubeFace, transformedCubies, normalisedRotation);
        RotateCubies(cubeFace, transformedCubies, normalisedRotation);

        return this;
    }

    /// <summary>
    /// Rotate the faces of the cubies
    /// </summary>
    /// <param name="cubeFace"></param>
    /// <param name="transformedCubies"></param>
    /// <param name="normalisedRotation"></param>
    private void RotateCubies(Face cubeFace, List<Cubie> transformedCubies, Rotation normalisedRotation)
    {
        foreach (Cubie transformedCubie in transformedCubies)
        {

            foreach (var colourFace in transformedCubie.CubieFaces)
            {
                colourFace.Face = CubieRotation.Rotate(cubeFace, colourFace.Face, normalisedRotation);
            }

            var originalCubie = Cubies.Where(c => c.Id == transformedCubie.Id).First();


            Cubies.Remove(originalCubie);
            Cubies.Add(transformedCubie);

            Debug.WriteLine($"Cubie {originalCubie} becomes {transformedCubie}");
        }
    }

    /// <summary>
    /// Relocate the cubies to their new positions
    /// </summary>
    /// <param name="cubeFace"></param>
    /// <param name="transformedCubies"></param>
    /// <param name="normalisedRotation"></param>
    /// <exception cref="Exception"></exception>
    private void RelocateCubies(Face cubeFace, List<Cubie> transformedCubies, Rotation normalisedRotation)
    {
        for (int x = 0; x <= CubeSize; x++)
        {
            for (int y = 0; y <= CubeSize; y++)
            {
                for (int z = 0; z <= CubeSize; z++)
                {
                    Cubie? transformedCubie = SelectCubie(x, y, z);
                    switch (cubeFace)
                    {
                        case Face.Up:
                        case Face.Down:
                            switch (cubeFace)
                            {
                                case Face.Up:
                                    if (y != CubeSize)
                                        continue;
                                    break;
                                case Face.Down:
                                    if (y != 0)
                                        continue;
                                    break;
                            }

                            transformedCubie.Coordinate = normalisedRotation == Rotation.Clockwise ?
                                new Coordinate(transformedCubie.Coordinate.Z, transformedCubie.Coordinate.Y, CubeSize - transformedCubie.Coordinate.X) :
                                new Coordinate(CubeSize - transformedCubie.Coordinate.Z, transformedCubie.Coordinate.Y, transformedCubie.Coordinate.X);
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
                                    if (x != CubeSize)
                                        continue;
                                    break;
                            }

                            transformedCubie.Coordinate = normalisedRotation == Rotation.Clockwise ?
                                new Coordinate(transformedCubie.Coordinate.X, CubeSize - transformedCubie.Coordinate.Z, transformedCubie.Coordinate.Y) :
                                new Coordinate(transformedCubie.Coordinate.X, transformedCubie.Coordinate.Z, CubeSize - transformedCubie.Coordinate.Y);
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
                                    if (z != CubeSize)
                                        continue;
                                    break;
                            }

                            transformedCubie.Coordinate = normalisedRotation == Rotation.Clockwise ?
                                new Coordinate(transformedCubie.Coordinate.Y, CubeSize - transformedCubie.Coordinate.X, transformedCubie.Coordinate.Z) :
                                new Coordinate(CubeSize - transformedCubie.Coordinate.Y, transformedCubie.Coordinate.X, transformedCubie.Coordinate.Z);
                            break;
                    }

                    transformedCubies.Add(transformedCubie);
                }
            }
        }

        if (!transformedCubies.Any())
            throw new Exception("No cubies to transform");
    }

    private Cubie SelectCubie(int x, int y, int z)
    {
        var cubie = Cubies.Where(c => c.Coordinate.X == x && c.Coordinate.Y == y && c.Coordinate.Z == z);
        return (Cubie)cubie.First().Clone();
    }

    private static Rotation NormaliseRotation(Face cubeFace, Rotation rotation)
    {
        Rotation normalisedRotation = rotation;

        switch (cubeFace)
        {
            case Face.Down:
            case Face.Back:
            case Face.Left:
                normalisedRotation = rotation == Rotation.Clockwise ? Rotation.AntiClockwise : Rotation.Clockwise;
                Debug.WriteLine($"Direction inverted to {normalisedRotation}");
                break;
        }

        return normalisedRotation;
    }

}
