using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	private void Move (string direction) {
		switch (direction)
		{
		case "North":
			rigidbody2D.AddForce(new Vector2(0,0.32f));

			break;
		case "South":
			break;
		case "East":
			break;
		case "West":
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Move("North");
		}
		else if (Input.GetKeyDown(KeyCode.RightArrow)) {
			Move("East");
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			Move("South");
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			Move("West");
		}
	
	}
}
