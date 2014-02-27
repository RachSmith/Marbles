using UnityEngine;
using System.Collections;
using Leap;


public class Controls : MonoBehaviour {

	// Global Variables // 
	Controller myController;
	Vector3 zero = new Vector3(0.0f,0.0f,0.0f);
	GameObject cam;
	float jumpTime = 0;
	float frameNum = 0; 

	// Use this for initialization
	void Start () {
		myController= new Controller();
		Leap.Vector previous= new Leap.Vector(0,0,0);
		cam = GameObject.Find ("Camera");
	}
	
	// Update is called once per frame
	void Update () {

		//  Local Variables, updated each frame //
		Frame myFrame = myController.Frame();
		HandList myHands = myFrame.Hands;
		Hand rightHand = myHands.Rightmost;
		Vector3 movement = (rightHand.PalmNormal.ToUnity ()); 
		float totalMoveZ = 0f;	
		float zForce;

		// Comamand to exit to menu at anypoint, works //
		if(UnityEngine.Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("Startscreen");
		}

		//  Reset jump timer //
		if (frameNum > 250) {
			frameNum = 0; 
			jumpTime = 0; 
		}

		// Average filter //
		for (int i=0; i<200; i++)
		{
			Vector3 lastMove =  myController.Frame(i).Hands.Rightmost.PalmNormal.ToUnity();
			totalMoveZ += lastMove.z; 
		}
		totalMoveZ = totalMoveZ / 200;

		// Debug , should use for user feedback //
		if (myHands.Count == 0) {
			//Debug.Log ("NOTHING HERE");
		}

		// Jump Command- still testing //
		else if (movement.y > .2) {
			if (jumpTime < 10) {
				gameObject.rigidbody.AddForce(0.0f, 15.0f, 0.0f); 
				jumpTime++;     
			}
		} 

		else {

			// code for movment //
			if (Mathf.Abs(rigidbody.velocity.z) > 100) {
				zForce = 0f;
			} else {
				zForce = movement.z * -13f;
			}

			// weird math that works //
			Quaternion forceAngle = Quaternion.Euler (new Vector3(0.0f,cam.transform.rotation.eulerAngles.y,0.0f));

			// Command to move game object //
			gameObject.rigidbody.AddForce( forceAngle*Vector3.forward*zForce);
			//Debug.Log ("X:" + movement.x + "\tZ:" + movement.z);  
		}
		frameNum++; 
	}
}


// Code that might be usefull //
/*if (Mathf.Abs(rigidbody.velocity.x) > 100) {
	xVel = -100;
} else {
	//xVel = (zero.x - movement.x) * -.000005f;
	//xVel = movement.x * -50f;
}
*/