using UnityEngine;
using System.Collections;

public class FPSHud : MonoBehaviour {

	public  float updateInterval = 0.5F;
	
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval


	// Use this for initialization
	void Start () {

		if( !guiText )
		{
			Debug.Log("UtilityFramesPerSecond needs a GUIText component!");
			enabled = false;
			return;
		}
		timeleft = updateInterval; 
	
	}
	
	// Update is called once per frame
	void Update () {

		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		// Interval ended - update GUI text and start new interval
		if( timeleft <= 0.0 )
		{
			// display two fractional digits (f2 format)
			float fps = accum/frames;
			string format = System.String.Format("{0:F2} FPS",fps);
			guiText.text = format;
			
			if(fps < 30)
				guiText.material.color = Color.yellow;
			else 
				if(fps < 10)
					guiText.material.color = Color.red;
			else
				guiText.material.color = Color.green;
			//	DebugConsole.Log(format,level);
			timeleft = updateInterval;
			accum = 0.0F;
			frames = 0;
		}
	
	}

	void onGUI()
	{
		GUI.TextArea(new Rect(0,0,Screen.width / 2,10),guiText.text);
	}
}
