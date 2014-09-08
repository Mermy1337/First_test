using UnityEngine;
using System.Collections;

public class SphereTestScript : MonoBehaviour {

	#region Public Variables
	public  float RotationSpeed;
	#endregion
	
	#region Methoden
	void Update () {
		//transform.Translate(5f * Time.deltaTime, 0f, 0f);
		transform.Rotate(0, 0, RotationSpeed*  Time.deltaTime, Space.World);
		
	}
	#endregion
}
