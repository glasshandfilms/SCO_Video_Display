using UnityEngine;
using System.Collections;

public class CoverManager : MonoBehaviour {

	// Use this for initialization
	//this is the number of covers, given by the textures
	public Sprite[] coverSprites;
	//this is the prefab cover gameobjec
	public GameObject coverPrefab;
	//this is the actual cover
	public int actualCover;
	//this is the distance between covers
	[Range(0.2f,5.5f)]
	public float distance=1.5f;
	//this is cover rotation when idle
	[Range(30f,70f)]
	public float coverRotation=60f;

	//these are the covers referenced as gameobjects
	GameObject[] go;

	//these are the script of the covers
	CoverEvents[] coverScript;

	// these are the url associated to each video and the description texts
	public string[] url;
	public string[] title;
	public string[] descrip;
	public string[] time;

	// this is the video scenee
	public GameObject videoScene,galleryScene;
	public MediaPlayerCtrl videoScript;




	void Start ()
	{
		Create();
	}


	public void Create ()
	{
		//give initial size to the arrays
		go =new GameObject[coverSprites.Length];
		coverScript =new CoverEvents[coverSprites.Length];


		for (int i = 0; i < coverSprites.Length; i++) 
		{
			go[i] = GameObject.Instantiate(coverPrefab,new Vector3(i*distance,0,0)+transform.position, Quaternion.Euler(0,0,0)) as GameObject;

			go[i].transform.SetParent(transform);
			coverScript[i]=go[i].GetComponent<CoverEvents>();

			// set the sprite and the number of the cover for future reference
			coverScript[i].setSprite(coverSprites[i]);
			coverScript[i].covNum=i;

			//update description using the string arrays
			coverScript[i].updateDescription(title[i],descrip[i],time[i]);
		}
	}

	public void ResetPositions ()
	{

		for (int i = 0; i < actualCover; i++) 
		{
			//go[i].transform.rotation= Quaternion.Euler(0,-coverRotation,0);
			coverScript[i].imposedRotation=-coverRotation;
			coverScript[i].hideDescription();

		}

		//go[actualCover].transform.rotation= Quaternion.Euler(0,0,0);
		coverScript[actualCover].imposedRotation=0;
		coverScript[actualCover].showDescritpion();

		for (int i = actualCover+1; i < coverSprites.Length; i++) 
		{
			//go[i].transform.rotation= Quaternion.Euler(0,coverRotation,0);
			coverScript[i].imposedRotation=coverRotation;
			coverScript[i].hideDescription();
		}

	}

	public void goToVideoScene (int a)
	{
		if(url[a]!="")
		{
			videoScene.SetActive(true);


			videoScript.UnLoad();
			videoScript.m_strFileName=url[a];
			videoScript.Load(url[a]);

			galleryScene.SetActive(false);
		}
	}
}
