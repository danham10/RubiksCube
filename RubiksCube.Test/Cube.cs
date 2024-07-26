using System.Security.Claims;
using System.Text;
using RubiksCube.Cube;
using RubiksCube.Faces;

namespace RubiksCube.Test
{
    [TestClass]
    public class Cube
    {
        [TestMethod]
        public void Initialised_cube_renders_correct_faces()
        {
            var cube = new RubiksCube.Cube.Cube();
            
            var frontCubies = cube.Cubies.Where(c => c.Coordinate.Z == 0).ToList();
            var upCubies = cube.Cubies.Where(c => c.Coordinate.Y == 2).ToList();
            var leftCubies = cube.Cubies.Where(c => c.Coordinate.X == 0).ToList();
            var rightCubies = cube.Cubies.Where(c => c.Coordinate.X == 2).ToList();
            var backCubies = cube.Cubies.Where(c => c.Coordinate.Z == 2).ToList();
            var downCubies = cube.Cubies.Where(c => c.Coordinate.Y == 0).ToList();

            var frontGreenCount = ColourCount(frontCubies, FaceName.Front, Colour.Green);
            var upWhiteCount = ColourCount(upCubies, FaceName.Up, Colour.White);
            var leftOrangeCount = ColourCount(leftCubies, FaceName.Left, Colour.Orange);
            var rightRedCount = ColourCount(rightCubies, FaceName.Right, Colour.Red);
            var backBlueCount = ColourCount(backCubies, FaceName.Back, Colour.Blue);
            var downYellowCount = ColourCount(downCubies, FaceName.Down, Colour.Yellow);

            Assert.AreEqual(9, frontGreenCount);
            Assert.AreEqual(9, upWhiteCount);
            Assert.AreEqual(9, leftOrangeCount);
            Assert.AreEqual(9, rightRedCount);
            Assert.AreEqual(9, backBlueCount);
            Assert.AreEqual(9, downYellowCount);
        }

        [TestMethod]
        public void Coding_challenge_renders_correct_frontface()
        {
            const string expectedFront = "OrangeRedRedOrangeGreenWhiteWhiteWhiteWhite";

            var cube = new RubiksCube.Cube.Cube();

            //Rotate according to the coding challenge

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

            StringBuilder row = new StringBuilder();

            Console.WriteLine(FaceName.Front);
            for (int y = 2; y >= 0; y--)
            {
                
                for (int x = 0; x <= 2; x++)
                {
                    var cubieFaceColour =
                        (from c in cube.Cubies
                         from cf in c.CubieFaces
                         where c.Coordinate.X == x && c.Coordinate.Y == y
                         where cf.FaceName == FaceName.Front
                         select cf.Colour).First();


                    row.Append(cubieFaceColour);
                }

            }

            Assert.AreEqual(expectedFront, row.ToString());
        }

        private int ColourCount(List<Cubie> cubies, FaceName face, Colour colour) =>
            (from c in cubies
             from cf in c.CubieFaces
             where cf.FaceName == face && cf.Colour == colour
             select cf.Colour).Count();
    }
}