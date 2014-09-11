﻿using UnityEngine;
using System.Collections.Generic;

public class Dungeon : MonoBehaviour {

	public Sprite[] sprites;

	private SpriteRenderer spriteRenderer;
	private List<char> world;
	private Vector2 position = new Vector2(-0.32f * 6.5f, 0.32f * 6.5f);
	private GameObject walls, floors, dungeon;


	// Use this for initialization
	void Start () {
	
		walls = new GameObject("Walls");
		floors = new GameObject("Floors");
		dungeon = GameObject.Find("Dungeon");

		walls.transform.parent = dungeon.transform;
		floors.transform.parent = dungeon.transform;

		world = new List<char>();
		for(int y = 0; y <= 14; y++){
			for( int x = 0; x <= 14; x++)
			{
				if(y == 0 || y == 14 || x == 0 || x == 14 )
				{
					world.Add('x');
				}

				else 
				{
					world.Add('o');
				}

			
			}


		}


		foreach( char x in world)
		{
			if (x == 'x')
			{
				GameObject wall = new GameObject("Wall" );
				wall.transform.parent = walls.transform;
				wall.transform.position = position;
				wall.AddComponent<SpriteRenderer>();
				wall.GetComponent<SpriteRenderer>().sprite = sprites[0];
				wall.AddComponent<BoxCollider2D>();
			}
			else if (x == 'o'){
				GameObject floor  = new GameObject("Floor");
				floor.transform.parent = floors.transform;
				floor.transform.position = position;
				floor.AddComponent<SpriteRenderer>();
				floor.GetComponent<SpriteRenderer>().sprite = sprites[1];
			}

			if( position.x >= 0.32f * 6.5f	)
			{
				position.x = -0.32f * 6.5f;
				position.y += -0.32f;
			}
			else{
				position.x += 0.32f;
			}

		} 

	}
	
	// Update is called once per frame
	void Update () {

	}
}
