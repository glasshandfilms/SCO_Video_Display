using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour {

	// Use this for initialization
	// this is the reference to the videos script
	public MediaPlayerCtrl videoScript;
	// reference to the slider
	Slider slider;

	void Start () {
		slider=GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	// this is called in the onChangedValue in the slider
	public void changeValue ()
	{
		videoScript.SetVolume(slider.value);
	}
}
