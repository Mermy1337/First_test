using UnityEngine;

public class Runner : MonoBehaviour {


	#region Public Variables
	public static float distanceTraveled;
	public float accleration;
	public Vector3 jumpVelocity;
	public Vector3 speed;
	#endregion

	#region Private Variable
	private bool touchingPlatform;
	#endregion
	
	#region Methoden
	void Update () {
		if(touchingPlatform && Input.GetKeyDown(KeyCode.Space)){
			rigidbody.AddForce(jumpVelocity,ForceMode.VelocityChange);
			touchingPlatform = false;
		}
		if(Input.GetKeyDown(KeyCode.A)){
			rigidbody.AddForce(-1f,0f,0f,ForceMode.VelocityChange);

		}
		if(Input.GetButton("Horizontal")){
			//rigidbody.AddForce(1f,0f,0f,ForceMode.VelocityChange);
			rigidbody.MovePosition(rigidbody.position +  Input.GetAxis("Horizontal") * speed * Time.deltaTime);

		}
		distanceTraveled = transform.localPosition.x;
	
	}

	/*
	void FixedUpdate(){
		if(touchingPlatform)
		{
			rigidbody.AddForce(accleration,0f,0f,ForceMode.Acceleration);
		}
	} */

	void OnCollisionEnter () {
		touchingPlatform = true;
	}
	
	void OnCollisionExit () {
		touchingPlatform = false;
	}
	#endregion
}
