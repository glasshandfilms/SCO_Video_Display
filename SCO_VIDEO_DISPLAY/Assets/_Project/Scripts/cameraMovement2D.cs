using UnityEngine;
using System.Collections;

public class cameraMovement2D : MonoBehaviour {

	// Use this for initialization
	public Transform camTransform;
	public float imposedPosition;
	CoverManager covMangScript;

	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// we use a raycast in order to get the position where the player is looking at
		RaycastHit hit;

		if (Physics.Raycast(camTransform.position, camTransform.forward, out hit))
		{
			if(hit.collider.tag=="cover")
			{
				// get the new coordinate point by setting the plane distance
				//check zoom
				Vector3 newCamPos= new Vector3(0,0,0);

				//set the value for the cover in order to make it look at the user: and
				// get the covermanager script form the given raycast
				covMangScript=hit.transform.parent.transform.GetComponent<CoverManager>();
				covMangScript.actualCover=hit.transform.GetComponent<CoverEvents>().covNum;
				covMangScript.ResetPositions();


				newCamPos = new Vector3 (imposedPosition,0, 0);
				
					
				transform.position = Vector3.Lerp (transform.position, newCamPos, 0.5f);

			}
			else
			{


			}

		}
	
	}



	public void goLeft ()
	{
		if(imposedPosition-covMangScript.distance>=0)
		{
			imposedPosition-=covMangScript.distance;
		}
	}

	public void goRight ()
	{
		if (imposedPosition < covMangScript.distance*(covMangScript.coverSprites.Length-1)) {
			imposedPosition += covMangScript.distance;
		}
	}

}
