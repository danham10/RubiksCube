This app models a 3x3 rubiks cube and allows each face to be rotated.

Cube is represented as a 3x3 matrix of Cubies, each of which has a unique id and a color for each external face of the cubie.
Corner cubies have 3 colors, edge cubies have 2 colors, and center cubies have 1 color.

For rotation, the cubies in a face are rotated about said face, then the cubies themselves are rotated.

To run the app, hit play in Visual studio, or publish the app and run the executable.

Features:
Rotation direction is "inverted" for the left, back and down faces. This means that the face is rotated in the opposite direction of the other faces.
Output displays each face as a 3x3 matrix of the first letter of the color of each cubie.
Cubies are deep cloned when rotating to avoid changing the original cubie, since the original cubie may itself be transformed later in the rotation.

Improvements:
- Add logging instead of console.write
- Add tests
- Add a configuration setting to allow N x N cubes. The initCube method would need to be updated to allow for this.
- Add a stopwatch 