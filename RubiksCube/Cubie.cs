﻿namespace RubiksCube;

public class Cubie : ICloneable
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public List<ColourFace> CubieFaces;
    public Coordinate Coordinate;

    public Cubie(Coordinate location, params ColourFace[] colourVertices)
    {
        Coordinate = location;
        CubieFaces = [.. colourVertices];
    }

    public object Clone()
    {
        var cubie = new Cubie((Coordinate)Coordinate.Clone(), CubieFaces.Select(cv => (ColourFace)cv.Clone()).ToArray());
        cubie.Id = Id;

        return cubie;
    }

    public override string ToString()
    {
        return $"{string.Join(", ", CubieFaces.Select(cv => cv.ToString()))}, Coord: {Coordinate}";
    }
}