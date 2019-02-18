using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderFunctions : MonoBehaviour {

	//Reference to the video that is playing
	public MediaPlayerCtrl videoScript;
	// reference to the slider
	Slider slider;
	// this is necesary to be able to seek the video position
	bool pointerEnter=false;

	//variables that show the video time
	public float duration, videoTime;

	// Use this for initialization
	void Start () {
		slider=GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		duration=videoScript.GetDuration ();
		videoTime=videoScript.GetSeekPosition ();

		if (videoScript.GetDuration () != 0) {
			slider.value =videoTime /duration ;
		}
	}

	public void changeValue ()
	{
		int value = (int)(duration * slider.value);
		videoScript.SeekTo (value);

	}

	/* OLD CODING public void changeValue ()
	{
		
		pointerEnter=true;
		Invoke("setClickedValue",0.2f);
		//we set it to false some miliseconds after
		Invoke("setFalsePointer",0.5f);

	}

	public void setClickedValue ()
	{
		int value = (int)(duration * slider.value);
		videoScript.SeekTo (value);
	}

	public void setFalsePointer ()
	{
		pointerEnter=false;
	}*/
}
