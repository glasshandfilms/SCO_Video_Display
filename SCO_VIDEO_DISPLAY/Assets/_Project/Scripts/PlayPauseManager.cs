using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayPauseManager : MonoBehaviour {

	// Use this for initialization
	//these are the two sprites used (pause and play)
	public Sprite playSpr, pauseSpr;
	// this is the button used for the interaction
	public Image playPauseButon;
	// this is the reference to the videos script
	public MediaPlayerCtrl videoScript;
	// the video starts playing and we need to control when it is paused:
	public bool isPlaying=true;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// this is the part where we check if the video is playing and we choose the action to perform
	public void playPause ()
	{
		if (isPlaying) {
			videoScript.Pause();
			playPauseButon.sprite=playSpr;
			isPlaying=false;
		} else {
			videoScript.Play();
			playPauseButon.sprite=pauseSpr;
			isPlaying=true;
		}
	}
}
