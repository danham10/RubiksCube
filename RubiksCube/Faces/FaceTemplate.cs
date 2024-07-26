
using RubiksCube;
using RubiksCube.Cube;
using System.Collections.ObjectModel;
using System.Diagnostics;

public abstract class FaceTemplate
{
    protected const int CubeSize = 2;
    protected ICollection<Cubie> transformedCubies = new Collection<Cubie>();
    protected FaceName Face;
    protected Rotation NormalisedRotation;

    protected static FaceName[] XAxis = [FaceName.Up, FaceName.Back, FaceName.Down, FaceName.Front];
    protected static FaceName[] ZAxis = [FaceName.Up, FaceName.Right, FaceName.Down, FaceName.Left];
    protected static FaceName[] YAxis = [FaceName.Front, FaceName.Left, FaceName.Back, FaceName.Right];

    public void Transform(ICollection<Cubie> cubies, Rotation rotation)
    {
        NormalisedRotation = NormaliseRotation(rotation);
        var transformedCubies = RelocateCubie(cubies, rotation).ToList();
        RotateCubies(cubies, transformedCubies, Face);
    }

    protected abstract ICollection<Cubie> RelocateCubie(ICollection<Cubie> Cubies, Rotation rotation);


    /// <summary>
    /// Rotate the cubie face based on the colour face and rotation
    /// </summary>
    /// <param name="cubeFace">Face of the parent cube</param>
    /// <param name="colourFace">A face of the cubie</param>
    /// <param name="rotation"></param>
    /// <returns></returns>
    protected abstract FaceName RotateCubieFace(FaceName cubeFace, FaceName colourFace, Rotation rotation);

    protected virtual Rotation NormaliseRotation(Rotation rotation) => rotation;

    /// <summary>
    /// Rotate the faces of the cubies
    /// </summary>
    /// <param name="cubeFace"></param>
    /// <param name="transformedCubies"></param>
    protected void RotateCubies(ICollection<Cubie> originalCubies, ICollection<Cubie> transformedCubies, FaceName cubeFace)
    {
        foreach (Cubie transformedCubie in transformedCubies)
        {

            foreach (var colourFace in transformedCubie.CubieFaces)
            {
                colourFace.FaceName = RotateCubieFace(cubeFace, colourFace.FaceName, NormalisedRotation);
            }

            var originalCubie = originalCubies.Where(c => c.Id == transformedCubie.Id).First();


            originalCubies.Remove(originalCubie);
            originalCubies.Add(transformedCubie);

            Debug.WriteLine($"Cubie {originalCubie} becomes {transformedCubie}");
        }
    }

    protected FaceName RotateAxis(FaceName[] axis, FaceName direction, Rotation rotation)
    {
        var index = Array.FindIndex(axis, t => t == direction);
        if (index == -1)
            return direction;

        int newIndex = 0;

        switch (rotation)
        {
            case Rotation.Clockwise:
                newIndex = index == axis.Length - 1 ? 0 : index + 1;
                break;
            case Rotation.AntiClockwise:
                newIndex = index == 0 ? axis.Length - 1 : index - 1;
                break;
        }

        return axis[newIndex];
    }

    protected Cubie SelectCubie(ICollection<Cubie> Cubies, int x, int y, int z)
    {
        var cubie = Cubies.Where(c => c.Coordinate.X == x && c.Coordinate.Y == y && c.Coordinate.Z == z);
        return (Cubie)cubie.First().Clone();
    }

    /// <summary>
    /// Reversed faces need to be rotated in the opposite direction
    /// </summary>
    /// <param name="rotation"></param>
    /// <returns></returns>
    protected Rotation ReverseRotation(Rotation rotation) => rotation == Rotation.Clockwise ? Rotation.AntiClockwise : Rotation.Clockwise;

    protected static char ColourChar(Colour cubieFaceColour) => cubieFaceColour.ToString().First();

    public abstract string Display(List<Cubie> cubies);
}