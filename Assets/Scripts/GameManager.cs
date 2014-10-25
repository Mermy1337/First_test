using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Maze mazePrefab;

	private Maze mazeInstant;

	// Use this for initialization
	void Start () {
		BeginGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Backspace)){
			RestartGame();
		}
	}

	void BeginGame ()
	{
		mazeInstant = Instantiate (mazePrefab) as Maze;
		StartCoroutine(mazeInstant.Generate ());
	}

	void RestartGame ()
	{
		StopAllCoroutines ();
		Destroy (mazeInstant.gameObject);
		BeginGame ();
	}
}
