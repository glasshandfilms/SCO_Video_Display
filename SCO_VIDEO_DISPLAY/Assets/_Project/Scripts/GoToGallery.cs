using UnityEngine;
using System.Collections;

public class GoToGallery : MonoBehaviour {

	// Use this for initialization
	public GameObject deaScene, actScene;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void back()

	{
		deaScene.SetActive(false);
		actScene.SetActive(true);
	}
}
