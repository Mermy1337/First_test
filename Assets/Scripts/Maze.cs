using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

	public float generationStepDelay;
    public MazePassage passagePrefab;
    public MazeWall wallPrefab;
	public MazeCell cellPrefab;
	public Vector2 size;
	public Vector2 RandomCoordinates{
		get{
			return new Vector2(Random.Range(0, size.x), Random.Range (0, size.y));
		}
	}

	public bool ContainsCoordinates(Vector2 coordinate){
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.y >=0 && coordinate.y < size.y;
	}

	private MazeCell[,] cells;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public MazeCell GetCell (Vector2 coordinates) {
		return cells[(int)coordinates.x, (int)coordinates.y];
	}


	public IEnumerator Generate(){
		WaitForSeconds delay = new WaitForSeconds (generationStepDelay);
		cells = new MazeCell[(int)size.x, (int)size.y];
		List<MazeCell> activeCells = new List<MazeCell>();
		DoFirstGenerationStep (activeCells);
		Vector2 coordinates = RandomCoordinates;
		while(activeCells.Count > 0){
			yield return delay;
			DoNextGenerationStep(activeCells);
		}
	}

	private void DoNextGenerationStep (List<MazeCell> activeCells) {
		int currentIndex = activeCells.Count - 1;
		MazeCell currentCell = activeCells[currentIndex];
		MazeDirection direction = MazeDirections.RandomValue;
		Vector2 coordinates = currentCell.coordinates + direction.ToVector2();
        if (ContainsCoordinates(coordinates))
        {
            MazeCell neighbor = GetCell(coordinates);
            if (neighbor == null)
            {
                neighbor = CreateCell(coordinates);
                CreatePassage(currentCell, neighbor, direction);
                activeCells.Add(neighbor);
            }
            else
            {
                CreateWall(currentCell, neighbor, direction);
                activeCells.RemoveAt(currentIndex);
            }
        }
        else
        {
            CreateWall(currentCell, null, direction);
            activeCells.RemoveAt(currentIndex);
        }
	}

    private void CreatePassage(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazePassage passage = Instantiate(passagePrefab) as MazePassage;
        passage.Initialize(cell, otherCell, direction);
        passage = Instantiate(passagePrefab) as MazePassage;
        passage.Initialize(otherCell, cell, direction.GetOpposite());
    }

    private void CreateWall(MazeCell cell, MazeCell otherCell, MazeDirection direction)
    {
        MazeWall wall = Instantiate(wallPrefab) as MazeWall;
        wall.Initialize(cell, otherCell, direction);
        if (otherCell != null)
        {
            wall = Instantiate(wallPrefab) as MazeWall;
            wall.Initialize(otherCell, cell, direction.GetOpposite());
        }
    }

	private void DoFirstGenerationStep (List<MazeCell> activeCells) {
		activeCells.Add(CreateCell(RandomCoordinates));
	}

	private MazeCell CreateCell (Vector2 coordinates)
	{
		MazeCell newCell = Instantiate (cellPrefab) as MazeCell;
		cells [(int)coordinates.x, (int)coordinates.y] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.y;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3 (coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.y - size.y *0.5f + 0.5f);

		return newCell;
	}
}
