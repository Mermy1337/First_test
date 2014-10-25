using UnityEngine;

public enum MazeDirection {
	North,
	East,
	South,
	West
}



public static class MazeDirections {
	public const int Count = 4;

	public static MazeDirection RandomValue{
		get {
			return (MazeDirection)Random.Range (0, Count);
		}
	}

	private static Vector2[] vectors = {
		new Vector2 (0, 1),
		new Vector2 (1, 0),
		new Vector2 (0, -1),
		new Vector2 (-1, 0)
	};

	public static Vector2 ToVector2 (this MazeDirection direction) {
		return vectors[(int)direction];
	}

}


