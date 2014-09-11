using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	// Use this for initialization

	public Animator anim;
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		Debug.Log("hello world");
	}


	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow)) {
			rigidbody2D.AddForce(new Vector2(0,0.32f));
		}
		else if (Input.GetKey(KeyCode.DownArrow)) {
			rigidbody2D.AddForce(new Vector2(0,-0.32f));
			anim.SetTrigger("TurnDown");
		}
	
	}
}
