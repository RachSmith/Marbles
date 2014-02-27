using UnityEngine;
using System.Collections;
using Leap;


public class Keymap : MonoBehaviour {
	Controller myController;
	Leap.Vector previous= new Leap.Vector(0,0,0);

	// Use this for initialization
	void Start () {
	
		myController= new Controller();
	
	}

   
	
	// Update is called once per frame
	void Update () {
		Frame myFrame = myController.Frame();
		HandList myHands = myFrame.Hands;
		Hand rightHand = myHands.Rightmost;
		//float roll = rightHand.PalmNormal;
		Vector position = rightHand.PalmPosition;
		bool play = false;
		float avgx = 0f;
		float avgy = 0f;
		float avgz = 0f;

		//if (!myFrame.Hands.IsEmpty) {
			//gameObject.rigidbody.AddForce(new Vector3(0.0f, 50000.0f, 0.0f));
				//}

		if (myHands.Count == 0) {
			Debug.Log("NOTHING HERE");
				}
		else if (myHands.Count> 1) {
						Debug.Log ("TWO HANDS DETECTED");
				}
		else {
			play=true;
				}
	
		if (play == true) {
			//float difference=0;
			float totalx=0,totaly=0, totalz=0;


				/*
			/*for (int i=0; i<60; i++)
			{
				previous = myController.Frame(i).Hands.Rightmost.PalmNormal;
				totalx+= previous.x;
				totaly+= previous.y;
				totalz+= previous.z;
			}

			avgx= totalx/60;
			avgy=totaly/60;
			avgz=totalz/60;

			Vector current = myController.Frame().Hands.Rightmost.PalmNormal;
			float diffx = (current.x - avgx)*100000;
			float diffy = (current.y - avgy)*100000;
			float diffz = (current.z - avgz)*100000;

			Debug.Log("diff   "+ diffx +"    " + diffy+ "   " + diffz );
			//Debug.Log("current:   "+ current.x+"    " + current.y+ "   " + current.z);
*/
						//gameObject.rigidbody.AddForce (new Vector3 (0.0f, 0.0f, 50.0f));
				}
		/*if(UnityEngine.Input.GetKeyDown(KeyCode.W)) {
			gameObject.rigidbody.AddForce(new Vector3(0.0f, 0.0f, 500.0f));
	}

		if(UnityEngine.Input.GetKeyDown(KeyCode.A)) {
			gameObject.rigidbody.AddForce(new Vector3(-500.0f, 0.0f, 0.0f));
		}

		if(UnityEngine.Input.GetKeyDown(KeyCode.S)) {
			gameObject.rigidbody.AddForce(new Vector3(0.0f, 0.0f, -500.0f));
		}

		if(UnityEngine.Input.GetKeyDown(KeyCode.D)) {
			gameObject.rigidbody.AddForce(new Vector3(500.0f, 0.0f, 0.0f));
		}

		if(UnityEngine.Input.GetKeyDown(KeyCode.Space)) {
			gameObject.rigidbody.AddForce(new Vector3(0.0f, 100.0f, 0.0f));
		}*/



	}}

