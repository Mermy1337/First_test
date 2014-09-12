using UnityEngine;
using System.Collections.Generic;

public class WorldGenerator : MonoBehaviour {
	
	[System.Serializable]
	public class Dungeon{

		public int DungeonHeight, DungeonWidth;
		public Sprite wallTexture, floorTexture;

		private Vector2 DungeonStartPos, DungeonEndPos;

		public void setDungeonStartPos(Vector2 pos)
		{
			this.DungeonStartPos = pos;
		}

		public void setDungeonEndPos(Vector2 pos)
		{
			this.DungeonEndPos = pos;
		}

		public Vector2 getDungeonStartPos(){
			return this.DungeonStartPos;
		}

		public Vector2 getDungeonEndPos(){
			return this.DungeonEndPos;
		}

	}

	public Dungeon[] dungeons;
	

	private SpriteRenderer spriteRenderer;
	private Vector2 position = new Vector2(0, 0);
	private float posXOld, posYOld ,posXMax;
	private GameObject walls, floors,dungeon, world;
	private float tileSize = 0.32f;
	



	// Use this for initialization
	void Start () {
	
		world = GameObject.Find("World");

		Debug.Log (Random.Range(0f, 10f));

		foreach(Dungeon dg in dungeons){
			dungeon = new GameObject("Dungeon");
			walls = new GameObject("Walls");
			floors = new GameObject("Floors");
			dungeon.transform.parent = world.transform;

			walls.transform.parent = dungeon.transform;
			floors.transform.parent = dungeon.transform;
			posYOld = position.y;
			for(int y = 0; y <= dg.DungeonHeight; y++){
				posXOld = position.x;
				for( int x = 0; x <= dg.DungeonWidth; x++){

					if(y == 0 || y == dg.DungeonHeight || x == 0 || x == dg.DungeonWidth )
					{

						GameObject wall = new GameObject("Wall" );
						wall.transform.parent = walls.transform;
						wall.transform.position = position;
						wall.AddComponent<SpriteRenderer>();
						wall.GetComponent<SpriteRenderer>().sprite = dg.wallTexture;
						wall.AddComponent<BoxCollider2D>();
					}
					
					else 
					{
						
						
						GameObject floor  = new GameObject("Floor");
						floor.transform.parent = floors.transform;
						floor.transform.position = position;
						floor.AddComponent<SpriteRenderer>();
						floor.GetComponent<SpriteRenderer>().sprite = dg.floorTexture;
					}
					posXMax = position.x;
					position.x += tileSize;
				}
				position.y += -tileSize;
				position.x = posXOld;

			}
			/*
			position.y += Random.Range(0f,-2f);
			position.x += Random.Range(0f,2f); */

			int randomChooser = Random.Range(0,2);

			switch (randomChooser){
			case 1:
				position.x = posXOld;
				position.y += Random.Range(-tileSize *2,-tileSize * 6);
				break;
			case 0:
				position.y = posYOld;
				position.x = posXMax;
				position.x += Random.Range(tileSize * 2,tileSize *6 );
				break;
			}



		}

	
	}
	
	// Update is called once per frame
	void Update () {

	}

	
}
