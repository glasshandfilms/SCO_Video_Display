using UnityEngine;
using System.Collections;

public class ShowAndHideManager : MonoBehaviour {

	// Use this for initialization
	// set the time to make the canvas dissapear
	public float hideTime=2;
	//this is the canvas that will be hidded
	public Canvas hidShowCanvas;
	private float elapsed;

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		if (Input.GetMouseButtonDown(0)) {
			elapsed = 0;
		} 

		elapsed += Time.fixedDeltaTime;

		if (elapsed > hideTime) {
			hidShowCanvas.enabled = false;
		} else 
		{
			hidShowCanvas.enabled=true;
		}



	}
}
