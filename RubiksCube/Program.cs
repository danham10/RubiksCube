using RubiksCube;
using RubiksCube.Cube;
using RubiksCube.Faces;

var cube = new Cube();

var front = new Front();
front.Transform(cube.Cubies, Rotation.Clockwise);

var right = new Right();
right.Transform(cube.Cubies, Rotation.AntiClockwise);

var up = new Up();
up.Transform(cube.Cubies, Rotation.Clockwise);

var back = new Back();
back.Transform(cube.Cubies, Rotation.AntiClockwise);

var left = new Left();
left.Transform(cube.Cubies, Rotation.Clockwise);

var down = new Down();
down.Transform(cube.Cubies, Rotation.AntiClockwise);

Console.WriteLine(FaceName.Front);
Console.WriteLine(front.Display(cube.Cubies));

Console.WriteLine(FaceName.Left);
Console.WriteLine(left.Display(cube.Cubies));

Console.WriteLine(FaceName.Right);
Console.WriteLine(right.Display(cube.Cubies));

Console.WriteLine(FaceName.Back);
Console.WriteLine(back.Display(cube.Cubies));

Console.WriteLine(FaceName.Up);
Console.WriteLine(up.Display(cube.Cubies));

Console.WriteLine(FaceName.Down);
Console.WriteLine(down.Display(cube.Cubies));









