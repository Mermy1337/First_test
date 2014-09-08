using UnityEngine;
using System.Collections.Generic;

public class CreatePlanet : MonoBehaviour {

	public int planetSize;
	public Vector3 startPosition;
	public float blockSize, minY, maxY;

	public Sprite[] sprites;
	
	private Vector3 nextPosition;

	void Start () {

		GameObject go = new GameObject("Planet");
		go.transform.localPosition = startPosition;
		go.transform.localScale = new Vector2(blockSize,blockSize);
		SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
		SphereTestScript pRotation = go.AddComponent<SphereTestScript>();
		pRotation.RotationSpeed = 5f;
		renderer.sprite = sprites[0];
	}


	void Update () {

	}
	

}
