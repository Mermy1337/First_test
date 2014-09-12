using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	public float PlayerSpeed = 1;

	public Animator anim;

	// Use this for initialization

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		Debug.Log("hello world");
	}


	
	// Update is called once per frame
	void Update () {

		// just a simple movement. see http://docs.unity3d.com/ScriptReference/Input.GetAxis.html
		transform.Translate(Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime,0,0);
		transform.Translate(0,Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime,0);
	}
}
