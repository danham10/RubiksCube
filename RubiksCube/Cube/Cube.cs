namespace RubiksCube.Cube;

public class Cube
{
    public List<Cubie> Cubies;

    public Cube()
    {
        Cubies = InitCubies();
    }

    private static List<Cubie> InitCubies()
    {
        ColourFace white = new(Colour.White, FaceName.Up);
        ColourFace yellow = new(Colour.Yellow, FaceName.Down);
        ColourFace red = new(Colour.Red, FaceName.Right);
        ColourFace orange = new(Colour.Orange, FaceName.Left);
        ColourFace green = new(Colour.Green, FaceName.Front);
        ColourFace blue = new(Colour.Blue, FaceName.Back);

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
}
