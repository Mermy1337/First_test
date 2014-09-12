using UnityEngine;
using System.Collections.Generic;

public class Dungeon : MonoBehaviour {

	public Sprite[] sprites;

	private SpriteRenderer spriteRenderer;
	private List<char> world;
	private Vector2 position = new Vector2(0, 0);
	private GameObject walls, floors, dungeon;

	// width und height in tiles
	private int DungeonHeight = 50;
	private int DungeonWidth = 50;



	// Use this for initialization
	void Start () {
	
		walls = new GameObject("Walls");
		floors = new GameObject("Floors");
		dungeon = GameObject.Find("Dungeon");

		walls.transform.parent = dungeon.transform;
		floors.transform.parent = dungeon.transform;

		world = new List<char>();
		for(int y = 0; y <= DungeonHeight; y++){
			for( int x = 0; x <= DungeonWidth; x++)
			{
				if(y == 0 || y == DungeonHeight || x == 0 || x == DungeonWidth )
				{
					world.Add('x');
					GameObject wall = new GameObject("Wall" );
					wall.transform.parent = walls.transform;
					wall.transform.position = position;
					wall.AddComponent<SpriteRenderer>();
					wall.GetComponent<SpriteRenderer>().sprite = sprites[0];
					wall.AddComponent<BoxCollider2D>();
				}

				else 
				{
					world.Add('o');

					GameObject floor  = new GameObject("Floor");
					floor.transform.parent = floors.transform;
					floor.transform.position = position;
					floor.AddComponent<SpriteRenderer>();
					floor.GetComponent<SpriteRenderer>().sprite = sprites[1];
				}

				position.x += 0.32f;
			}

			position.y += 0.32f;
			position.x = 0.00f;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	
}
