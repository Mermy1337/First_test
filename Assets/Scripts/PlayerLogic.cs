using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {

	public float PlayerSpeed = 1;
	public  int jumpHigh = 100;

	protected Animator anim;

	private bool touchingPlatform;


		

	// Use this for initialization

	void Start () {
		//Debug.Log("hello world");

		// Get the Animator component from your gameObject
		//anim = GetComponent<Animator>();
	}


	
	// Update is called once per frame
	void Update () {

		// just a simple movement. see http://docs.unity3d.com/ScriptReference/Input.GetAxis.html



		/* Player Direction for animating. must be improved!:
			0 = idle
			1 = right
			2 = down
			3 = left
			4 = top
		*/
		/*
		if (Input.GetAxis ("Horizontal") > 0) {
			anim.SetInteger("PlayerDirection", 1);
		} else if(Input.GetAxis ("Horizontal") < 0){
			anim.SetInteger("PlayerDirection", 3);
		} else if (Input.GetAxis ("Vertical") > 0) {
			anim.SetInteger("PlayerDirection", 4);
		} else if(Input.GetAxis ("Vertical") < 0){
			anim.SetInteger("PlayerDirection", 2);
		} else {
			anim.SetInteger("PlayerDirection", 0);
		} */


	}

	void FixedUpdate () {
			//rigidbody.AddForce(acceleration, 0f, 0f, ForceMode.Acceleration);

			transform.Translate(Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime,0,0);
			//transform.Translate(0,Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime,0);
			
			transform.Translate(0,0,Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime);

            if (touchingPlatform &&Input.GetKey("space"))
            {
                rigidbody.AddForce(Vector3.up * jumpHigh, ForceMode.Force);

			}

            
		


	}

	void OnCollisionEnter () {
		touchingPlatform = true;
	}
	
	void OnCollisionExit () {
		touchingPlatform = false;
	}
}
