namespace RubiksCube;
internal class CubieRotation
{
    public static Face[] XAxis = [Face.Up, Face.Back, Face.Down, Face.Front];
    public static Face[] ZAxis = [Face.Up, Face.Right, Face.Down, Face.Left];
    public static Face[] YAxis = [Face.Front, Face.Left, Face.Back, Face.Right];

    public static Face Rotate(Face cubieFace, Face colourFace, Rotation rotation)
    {
        switch (cubieFace)
        {
            case Face.Up:
            case Face.Down:
                return RotateAxis(YAxis, colourFace, rotation);
            case Face.Left:
            case Face.Right:
                return RotateAxis(XAxis, colourFace, rotation);
            case Face.Front:
            case Face.Back:
                return RotateAxis(ZAxis, colourFace, rotation);
            default:
                return colourFace;
        }
    }

    private static Face RotateAxis(Face[] axis, Face direction, Rotation rotation)
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
}
