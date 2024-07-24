using System.Text;

namespace RubiksCube.Test
{
    [TestClass]
    public class Cube
    {
        [TestMethod]
        public void Initialised_cube_renders_correct_faces()
        {
            var cube = new RubiksCube.Cube();
            
            var frontCubies = cube.Cubies.Where(c => c.Coordinate.Z == 0).ToList();
            var upCubies = cube.Cubies.Where(c => c.Coordinate.Y == 2).ToList();
            var leftCubies = cube.Cubies.Where(c => c.Coordinate.X == 0).ToList();
            var rightCubies = cube.Cubies.Where(c => c.Coordinate.X == 2).ToList();
            var backCubies = cube.Cubies.Where(c => c.Coordinate.Z == 2).ToList();
            var downCubies = cube.Cubies.Where(c => c.Coordinate.Y == 0).ToList();

            var frontGreenCount = ColourCount(frontCubies, Face.Front, Colour.Green);
            var upWhiteCount = ColourCount(upCubies, Face.Up, Colour.White);
            var leftOrangeCount = ColourCount(leftCubies, Face.Left, Colour.Orange);
            var rightRedCount = ColourCount(rightCubies, Face.Right, Colour.Red);
            var backBlueCount = ColourCount(backCubies, Face.Back, Colour.Blue);
            var downYellowCount = ColourCount(downCubies, Face.Down, Colour.Yellow);

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

            var cube = new RubiksCube.Cube();
            
            //Rotate according to the coding challenge
            cube.Rotate(Face.Front, Rotation.Clockwise)
                .Rotate(Face.Right, Rotation.AntiClockwise)
                .Rotate(Face.Up, Rotation.Clockwise)
                .Rotate(Face.Back, Rotation.AntiClockwise)
                .Rotate(Face.Left, Rotation.Clockwise)
                .Rotate(Face.Down, Rotation.AntiClockwise);

            StringBuilder row = new StringBuilder();

            Console.WriteLine(Face.Front);
            for (int y = 2; y >= 0; y--)
            {
                
                for (int x = 0; x <= 2; x++)
                {
                    var cubieFaceColour =
                        (from c in cube.Cubies
                         from cv in c.CubieFaces
                         where c.Coordinate.X == x && c.Coordinate.Y == y
                         where cv.Face == Face.Front
                         select cv.Colour).First();


                    row.Append(cubieFaceColour);
                }

            }

            Assert.AreEqual(expectedFront, row.ToString());
        }

        private int ColourCount(List<Cubie> cubies, Face face, Colour colour) => 
            cubies.Select(c => c.CubieFaces.Where(cv => cv.Face == face && cv.Colour == colour).First().Colour).Count();
    }
}