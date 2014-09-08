using UnityEngine;
using System.Collections.Generic;

public class CreatePlanet : MonoBehaviour {

	public int planetSize;
	public Vector3 startPosition;
	public float blockSize, minY, maxY;

	public Sprite[] sprites;
	
	private Vector3 nextPosition;

	void Start () {
		GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Cube);
		planet.transform.position = startPosition;
		planet.transform.localScale = new Vector2(blockSize,blockSize);
		Destroy(planet.GetComponent<MeshFilter>());
		SpriteRenderer renderer = planet.AddComponent<SpriteRenderer>();
		SphereTestScript pRotation = planet.AddComponent<SphereTestScript>();
		pRotation.RotationSpeed = 5f;
		renderer.sprite = sprites[0];
	}


	void Update () {

	}
	

}
