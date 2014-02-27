using UnityEngine;
using System.Collections;

public class keyv : MonoBehaviour {


	// Use this for initialization
	void Start () {
		

		
	}
	
	// Update is called once per frame
	void Update () {


		if(UnityEngine.Input.GetKeyDown(KeyCode.W)) {
			gameObject.rigidbody.velocity=new Vector3(0.0f,0.0f,500f);
		}
		
		if(UnityEngine.Input.GetKeyDown(KeyCode.A)) {
			gameObject.rigidbody.velocity= new Vector3(-500.0f, 0.0f, 0.0f);
		}
		
		if(UnityEngine.Input.GetKeyDown(KeyCode.S)) {
			gameObject.rigidbody.velocity= new Vector3(0.0f, 0.0f, -500.0f);
		}
		
		if(UnityEngine.Input.GetKeyDown(KeyCode.D)) {
			gameObject.rigidbody.velocity= new Vector3(500.0f, 0.0f, 0.0f);
		}
		
		if(UnityEngine.Input.GetKeyDown(KeyCode.Space)) {
			gameObject.rigidbody.velocity= new Vector3(0.0f, 100.0f, 0.0f);
		}
	}
}
